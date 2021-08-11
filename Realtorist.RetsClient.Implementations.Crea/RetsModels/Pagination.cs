using Realtorist.Models.Pagination;

namespace Realtorist.RetsClient.Implementations.Crea.RetsModels
{
    public class Pagination
    {
        /// <summary>
        /// Number of the total records
        /// </summary>
        public int TotalRecords { get; set; }

        /// <summary>
        /// Number of the returned records
        /// </summary>
        public int RecordsReturned { get; set; }

        /// <summary>
        /// Number of the total pages
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// Number of the first element in result. Starting from 1
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// Number of the max records requested
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// Converts RETS response to <see cref="PaginationResult{T}">PaginationResult{T}</see>
        /// </summary>
        /// <typeparam name="T">Type of results</typeparam>
        /// <param name="results">Results</param>
        /// <returns><see cref="PaginationResult{T}">PaginationResult{T}</see></returns>
        public PaginationResult<T> ToPaginationResult<T>(T[] results)
        {
            return new PaginationResult<T>
            {
                TotalRecords = TotalRecords,
                Limit = Limit,
                Offset = Offset,
                Results = results
            };
        }
    }
}
