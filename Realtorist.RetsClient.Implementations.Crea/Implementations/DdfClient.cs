using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Realtorist.Models.Listings;
using Realtorist.Models.Helpers;
using Realtorist.Models.Pagination;
using Realtorist.RetsClient.Implementations.Crea.Abstractions;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using Realtorist.RetsClient.Implementations.Crea.Models;
using Realtorist.RetsClient.Implementations.Crea.RetsModels;
using Realtorist.Models.Settings;
using Realtorist.RetsClient.Implementations.Crea.Models.Exceptions;
using Realtorist.RetsClient.Implementations.Crea.Models.Enums;

namespace Realtorist.RetsClient.Implementations.Crea.Implementations
{
    /// <summary>
    /// Implements interaction to the DDF
    /// </summary>
    public class DdfClient : IDdfClient
    {
        private const string Format = "STANDARD-XML-ENCODED";

        private readonly RetsConfiguration _configuration;
        private readonly ILogger _logger;

        private HttpClient _httpClient;

        private string _realm;
        private string _nonce;
        private string _qop;
        private string _cnonce;
        private DateTime _cnonceDate;
        private int _nc;

        /// <summary>
        /// Creates new instance of <see cref="DdfClient">DdfClient</see>
        /// </summary>
        /// <param name="configuration">Configuration options</param>
        /// <param name="httpClient">HTTP Client</param>
        /// <param name="logger">Logger</param>
        public DdfClient(IOptions<RetsConfiguration> configuration, HttpClient httpClient, ILogger<DdfClient> logger)
        {
            _configuration = configuration?.Value ?? throw new ArgumentNullException(nameof(configuration));
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc/>
        public async Task<Property[]> GetMasterListAsync()
        {
            const string service = "/Search.svc/Search";
            var query = $"?Format={Format}&SearchType=Property&Class=Property&QueryType=DMQL2&Query=(ID=*)";

            _logger.LogInformation($"Requesting master list from URI: {service}{query}");

            var content = await GrabResponseAsync(service, query);

            var result = content.FromXml<RetsReply<MasterListResponse>>();

            if (result.ReplyCode != 0)
            {
                var error = $"Operation wasn't successful. Code: {result.ReplyCode}. Status: {result.ReplyText}";
                
                _logger.LogError(error);
                throw new CreaUpdateFlowException((ReplyCode)result.ReplyCode, result.ReplyText);
            }

            _logger.LogInformation($"Operation successful. Total records: {result.Response.Properties.Length}");
            return result.Response.Properties;
        }

        /// <inheritdoc/>
        public async Task<PaginationResult<PropertyDetails>> GetPropertiesAsync(DateTime lastUpdated, PaginationRequest paginationRequest)
        {
            if (paginationRequest is null)
            {
                throw new ArgumentNullException(nameof(paginationRequest));
            }

            if (paginationRequest.Limit > 100)
            {
                throw new ArgumentException("Pagination limit shouldn't exceed 100");
            }

            const string service = "/Search.svc/Search";
            var query = $"?Format={Format}&SearchType=Property&Class=Property&QueryType=DMQL2&Offset={paginationRequest.Offset+1}&Limit={paginationRequest.Limit}&Query=(LastUpdated={lastUpdated:s}Z)";

            _logger.LogInformation($"Requesting {paginationRequest.Limit} properties, starting from number {paginationRequest.Offset+1}, updated later than {lastUpdated} from URI: {service}{query}");

            var content = await GrabResponseAsync(service, query);

            var result = content.FromXml<RetsReply<PropertySearchResponse>>();

            if (result.ReplyCode != 0)
            {
                var error = $"Operation wasn't successful. Code: {result.ReplyCode}. Status: {result.ReplyText}";

                _logger.LogError(error);
                throw new CreaUpdateFlowException((ReplyCode)result.ReplyCode, result.ReplyText);
            }

            _logger.LogInformation($"Operation successful. Total records: {result.Response.Pagination.TotalRecords}. Records returned: {result.Response.Pagination.RecordsReturned}");
            return result.Response.Pagination.ToPaginationResult(result.Response.Properties);
        }

        /// <inheritdoc/>
        public async Task LoginAsync()
        {
            const string service = "/Login.svc/Login";

            _httpClient.BaseAddress = new Uri(_configuration.BaseUrl);
            _httpClient.Timeout = TimeSpan.FromMinutes(1);

            _logger.LogInformation($"Logging into {_configuration.BaseUrl} with username {_configuration.Username} and password {_configuration.Password.Select(x => '*').AsString()}");
            var content = await GrabResponseAsync(service, string.Empty);

            var xml = new XmlDocument();
            xml.LoadXml(content);

            var replyCode = (ReplyCode)int.Parse(xml.GetElementsByTagName("RETS")[0].Attributes["ReplyCode"].Value);

            if (replyCode != ReplyCode.Success)
            {
                var error = $"Operation wasn't successful. Code: {replyCode}";

                _logger.LogError(error);
                throw new CreaUpdateFlowException(replyCode);
            }
        }

        /// <inheritdoc/>
        public async Task LogoutAsync()
        {
            const string service = "/Logout.svc/Logout";

            _logger.LogInformation("Logging out");
            await GrabResponseAsync(service, string.Empty);
            _logger.LogInformation("Successfully logged out");
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            LogoutAsync().Wait();
            _httpClient.Dispose();
        }

        private static string CalculateMd5Hash(string input)
        {
            var inputBytes = Encoding.ASCII.GetBytes(input);
            var hash = MD5.Create().ComputeHash(inputBytes);
            var sb = new StringBuilder();
            foreach (var b in hash)
            {
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }

        private static string GrabHeaderVar(string varName, string header)
        {
            var regHeader = new Regex(string.Format(@"{0}=""([^""]*)""", varName));
            var matchHeader = regHeader.Match(header);
            if (matchHeader.Success)
            {
                return matchHeader.Groups[1].Value;
            }

            throw new ApplicationException(string.Format("Header {0} not found", varName));
        }

        private string GetDigestHeader(string dir)
        {
            _nc = _nc + 1;

            var ha1 = CalculateMd5Hash(string.Format("{0}:{1}:{2}", _configuration.Username, _realm, _configuration.Password));
            var ha2 = CalculateMd5Hash(string.Format("{0}:{1}", "GET", dir));
            var digestResponse = CalculateMd5Hash(string.Format("{0}:{1}:{2:00000000}:{3}:{4}:{5}", ha1, _nonce, _nc, _cnonce, _qop, ha2));

            return string.Format("Digest username=\"{0}\", realm=\"{1}\", nonce=\"{2}\", uri=\"{3}\", " +
                "algorithm=MD5, response=\"{4}\", qop={5}, nc={6:00000000}, cnonce=\"{7}\"",
                _configuration.Username, _realm, _nonce, dir, digestResponse, _qop, _nc, _cnonce);
        }

        private async Task<string> GrabResponseAsync(string dir, string query)
        {
            if (_httpClient.BaseAddress == null)
            {
                throw new InvalidOperationException("HttpClient isn't initialized");
            }

            if (string.IsNullOrEmpty(dir))
            {
                throw new ArgumentException("Dir shouldn't be empty", nameof(dir));
            }

            var uri = dir + query;

            HttpResponseMessage response;
            using (var request = new HttpRequestMessage(HttpMethod.Get, uri))
            {
                // If we've got a recent Auth header, re-use it!
                if (!string.IsNullOrEmpty(_cnonce) && DateTime.Now.Subtract(_cnonceDate).TotalHours < 1.0)
                {
                    request.Headers.Add("Authorization", GetDigestHeader(dir));
                }


                response = await _httpClient.SendAsync(request);
            }

            if (!response.IsSuccessStatusCode && response.StatusCode != HttpStatusCode.Unauthorized)
            {
                throw new HttpRequestException($"Failed to get data from '{uri}': {response.StatusCode}", null, response.StatusCode);
            }

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                var wwwAuthenticateHeader = response.Headers.GetValues("WWW-Authenticate").FirstOrDefault();
                if (string.IsNullOrEmpty(wwwAuthenticateHeader))
                {
                    throw new HttpRequestException($"WWW-Authenticate header wasn't found with 401 response");
                }

                _realm = GrabHeaderVar("realm", wwwAuthenticateHeader);
                _nonce = GrabHeaderVar("nonce", wwwAuthenticateHeader);
                _qop = GrabHeaderVar("qop", wwwAuthenticateHeader);

                _nc = 0;
                _cnonce = new Random().Next(123400, 9999999).ToString();
                _cnonceDate = DateTime.Now;

                using (var request2 = new HttpRequestMessage(HttpMethod.Get, uri))
                {
                    request2.Headers.Add("Authorization", GetDigestHeader(dir));
                    response = await _httpClient.SendAsync(request2);
                }
            }

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            return content;
        }
    }
}
