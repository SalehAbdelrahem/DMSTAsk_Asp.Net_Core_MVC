using DAL.Contacts.Categories;
using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Categories
{
    public class CategoryRepository : Repository<Category, int>, ICategoryRepository
    {


        public CategoryRepository(AppDBContext context) : base(context)
        {

        }


        //public async Task<IEnumerable<Category>> FilterByAsync(string? filter = null)
        //{
        //    return _context.Categories
        //      .Where(a => filter == null || a.Name.ToLower().Contains(filter.ToLower()));
        //}
       

    }
}
