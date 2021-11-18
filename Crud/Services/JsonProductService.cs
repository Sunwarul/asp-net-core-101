using Crud.Models;
using System.Text.Json;

namespace Crud.Services
{
    public class JsonProductService
    {
        public JsonProductService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }
        public IWebHostEnvironment WebHostEnvironment { get; set; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json"); }
        }

        public IEnumerable<Product> GetProducts()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                var products = JsonSerializer.Deserialize<Product[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                if (products != null)
                {
                    return products;
                }
                return new List<Product>();
            }
        }

        public void AddRatings(int productId, int rating)
        {
            IEnumerable<Product> products = GetProducts();
            Product product = products.First(x => x.Id == productId);

            if (product.Ratings == null)
            {
                product.Ratings = new int[] { rating };
            }
            else
            {
                List<int> ratings = product.Ratings.ToList();
                ratings.Add(rating);
                product.Ratings = ratings.ToArray();
            }

            using (var outputStream = File.OpenWrite(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<Product>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    products
                );
            }
        }
    }
}
