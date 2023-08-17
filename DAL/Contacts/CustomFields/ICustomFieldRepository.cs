using DAL.Models;

namespace DAL.Contacts.CustomFields
{
    public interface ICustomFieldRepository : IRepository<CustomField, int>
    {
        Task<CustomField?> GetDetailsAsync(int id);

    }
}
