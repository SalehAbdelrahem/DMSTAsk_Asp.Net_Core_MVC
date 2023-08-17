using BLL.DTOs.CustomFieldDatas;

namespace BLL.DTOs.CustomFields
{
    public class CustomFieldDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CustomFieldDataDTO? CustomFieldsData { get; set; }
    }
}
