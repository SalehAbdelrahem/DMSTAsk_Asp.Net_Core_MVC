using System.ComponentModel;

namespace BLL.DTOs.CustomData
{
    public class ShowAllCustomDataViewModel
    {
        public int Id { get; set; }

        [DisplayName("Product Name")]
        public string? ProductName { get; set; }

        [DisplayName("Filed Name")]

        public string? CustomFieldName { get; set; }
        [DisplayName("Filed Value")]

        public string? CustomFieldDataValue { get; set; }
    }
}
