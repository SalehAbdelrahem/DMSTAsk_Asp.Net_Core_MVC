using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs.Categories
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        [DisplayName("Category Name")]
        public string Name { get; set; }
    }
}
