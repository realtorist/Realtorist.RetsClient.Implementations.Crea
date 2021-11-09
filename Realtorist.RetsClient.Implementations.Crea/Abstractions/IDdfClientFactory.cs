using System.Threading.Tasks;
using Realtorist.Models.Settings;

namespace Realtorist.RetsClient.Implementations.Crea.Abstractions
{
    /// <summary>
    /// Describes factory for the DDF client
    /// </summary>
    public interface IDdfClientFactory
    {
        /// <summary>
        /// Creates new DDF client
        /// </summary>
        /// <returns>DDF client</returns>
        Task<IDdfClient> CreateAsync(ListingsFeed configuration);
    }
}
