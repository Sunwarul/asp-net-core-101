using Crud.Models;
using Crud.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Crud.Pages.Products
{
    public class IndexModel : PageModel
    {
        private JsonProductService JsonProductService { get; set; }
        public IEnumerable<Product> Products;
        public IndexModel(JsonProductService jsonProductService)
        {
            JsonProductService = jsonProductService;
        }

        [HttpGet]
        public void OnGet([FromQuery] int productId,[FromQuery] int rating)
        {
            //ViewData["productId"] = productId;
            //ViewData["rating"] = rating;

            JsonProductService.AddRatings(productId, rating);
        }
    }
}
