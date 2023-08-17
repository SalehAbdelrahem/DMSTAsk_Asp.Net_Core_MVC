using DAL.Models;

namespace DAL.Contacts.Products
{
    public interface IProductRepository : IRepository<Product, int>
    {
        Task<IEnumerable<Product>> FilterByAsync(string? filter = null, int? fromPrice = null, int? toPric = null, int? categoryId = null);
        Task<Product?> GetDetailsAsync(int id);

    }
}
