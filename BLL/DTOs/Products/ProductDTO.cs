using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs.Products
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        [Display(Name = "Category")]
        public List<int> CategoriesId { get; set; }
    }
}
