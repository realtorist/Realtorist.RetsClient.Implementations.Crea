using Realtorist.Models.Pagination;
using Realtorist.RetsClient.Implementations.Crea.Models;
using System;
using System.Threading.Tasks;

namespace Realtorist.RetsClient.Implementations.Crea.Abstractions
{
    /// <summary>
    /// Describes methods to interact with DDF
    /// </summary>
    public interface IDdfClient : IDisposable
    {
        Task LoginAsync();

        Task LogoutAsync();

        Task<Property[]> GetMasterListAsync();

        Task<PaginationResult<PropertyDetails>> GetPropertiesAsync(DateTime lastUpdated, PaginationRequest paginationRequest);
    }
}
