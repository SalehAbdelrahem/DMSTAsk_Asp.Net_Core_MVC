using BLL.DTOs.CustomFieldDatas;
using BLL.DTOs.Products;
using System.ComponentModel;

namespace BLL.DTOs.CustomFields
{
    public class DetailscustomFieldDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DisplayName("CustomFieldData")]
        public CustomFieldDataDTO?  customFieldDataDTO{ get; set; }
        [DisplayName("Product")]

        public ProductDTO?  ProductDTO{ get; set; }
    }
}
