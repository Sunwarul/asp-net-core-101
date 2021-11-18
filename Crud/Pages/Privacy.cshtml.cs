using Crud.Models;
using Crud.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Crud.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        public JsonProductService JsonProductService {  get; private set; }
        public IEnumerable<Product> Products {  get; set;}
        public PrivacyModel(ILogger<PrivacyModel> logger, JsonProductService jsonProductService)
        {
            _logger = logger;
            JsonProductService = jsonProductService;
        }

        public void OnGet()
        {
            Products = JsonProductService.GetProducts();
        }
    }
}