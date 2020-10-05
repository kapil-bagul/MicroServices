using System;
using System.Threading.Tasks;
using eCommerce.api.search.Interfaces;
using eCommerce.api.search.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.api.search.Controllers
{
    [ApiController]
    [Route("api/search")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        [HttpPost]
        public async Task<IActionResult> SearchAsync( SearchTerm searchTerm)
        {
            var result = await searchService.SearchAsync(searchTerm.CustomerId);
            if (result.IsSuccess)
            {
                return Ok(result.SearchResult);
            }

            return BadRequest();
        }
    }
}
