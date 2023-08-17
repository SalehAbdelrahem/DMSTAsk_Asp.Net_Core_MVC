namespace DAL.Models
{
    public class CustomFieldData
    {
        public int Id { get; set; }
        public string Value { get; set; }

        public virtual CustomField? CustomField { get; set; }

    }
}
