using System;
using System.Threading.Tasks;

namespace eCommerce.api.search.Interfaces
{
    public interface ISearchService
    {
        Task<(bool IsSuccess, dynamic SearchResult)>  SearchAsync(int customerId);
    }
}
