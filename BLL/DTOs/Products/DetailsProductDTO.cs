using BLL.DTOs.Categories;
using BLL.DTOs.CustomFields;
using System.ComponentModel;

namespace BLL.DTOs.Products
{
    public class DetailsProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        [DisplayName("Custum Fileds")]
        public List<CustomFieldDTO> CustomFields { get; set; }

        [DisplayName("Categories")]

        public List<CategoryDTO> Categories { get; set; }
    }
}
