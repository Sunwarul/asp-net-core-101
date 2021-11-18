using System.Text.Json;

namespace Crud.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description {  get; set; }    
        public decimal Price {  get; set; }
        public int[] Ratings { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize<Product>(this);
        }
    }
}
