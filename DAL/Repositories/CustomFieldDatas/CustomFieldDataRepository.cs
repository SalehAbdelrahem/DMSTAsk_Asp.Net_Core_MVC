using DAL.Contacts.CustomFieldDatas;
using DAL.Contacts.CustomFields;
using DAL.Data;
using DAL.Models;

namespace DAL.Repositories.CustomFieldDatas
{
    public class CustomFieldDataRepository : Repository<CustomFieldData, int>, ICustomFieldDataRepository
    {

        public CustomFieldDataRepository(AppDBContext context) : base(context)
        {

        }
    }
}
