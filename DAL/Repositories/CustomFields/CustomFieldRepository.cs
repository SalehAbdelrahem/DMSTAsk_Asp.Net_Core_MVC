using DAL.Contacts.CustomFields;
using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.CustomFields
{
    public class CustomFieldRepository : Repository<CustomField, int>, ICustomFieldRepository
    {

        public CustomFieldRepository(AppDBContext context) : base(context)
        {

        }
        public async Task<CustomField?> GetDetailsAsync(int id)
        {
            var CustumDetails = await _context.CustomFields
               .Include(a => a.Product)
               .ThenInclude(d => d.CustomFields)
               .ThenInclude(v=>v.CustomFieldData)
              .FirstOrDefaultAsync(a => a.Id == id);

            return CustumDetails;
        }

        public override async Task<IEnumerable<CustomField>> GetAllAsync()
        {
            var AllCustoms = await _context.CustomFields
                .Include(a => a.Product)
                .ThenInclude(d => d.CustomFields)
                .ThenInclude(v => v.CustomFieldData)
                .OrderBy(a => a.Product.Id)
                .ToListAsync();
            return AllCustoms;
        }
    }

}

