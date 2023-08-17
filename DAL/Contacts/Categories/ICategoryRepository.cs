using DAL.Models;

namespace DAL.Contacts.Categories
{
    public interface ICategoryRepository : IRepository<Category, int>
    {
        //Task<IEnumerable<Category>> FilterByAsync(string? filter = null, int? parentCatId = null);


    }
}
