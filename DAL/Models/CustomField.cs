using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class CustomField
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Product? Product { get; set; }
        public int? CustomFieldDataId { get; set; }
        [ForeignKey(nameof(CustomFieldDataId))]
        public virtual CustomFieldData? CustomFieldData { get; set; }
    }
}
