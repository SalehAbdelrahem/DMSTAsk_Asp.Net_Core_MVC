using System.ComponentModel;

namespace BLL.DTOs.CustomData
{
    public class CustomFieldViewModel
    {
        [DisplayName("Custom Field")]
        public string Name { get; set; }

        [DisplayName("Custom Field Data value")]

        public string Value { get; set; }

        [DisplayName("Product")]
        public int ProductId { get; set; }

    }
}
