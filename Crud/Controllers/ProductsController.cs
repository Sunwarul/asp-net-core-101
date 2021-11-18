using Crud.Models;
using Crud.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsController(JsonProductService jsonProductService)
        {
            JsonProductService = jsonProductService;
        }
        public JsonProductService JsonProductService { get; }

        [HttpGet]
        public IEnumerable<Product> OnGet()
        {
            return JsonProductService.GetProducts();
        }

        
    }
}
