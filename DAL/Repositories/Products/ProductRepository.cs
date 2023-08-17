using DAL.Contacts.Products;
using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Products
{
    public class ProductRepository : Repository<Product, int>, IProductRepository
    {

        public ProductRepository(AppDBContext context) : base(context)
        {

        }

        public Task<IEnumerable<Product>> FilterByAsync(string? filter = null, int? fromPrice = null, int? toPric = null, int? categoryId = null)
        {

            IEnumerable<Product> FilterProductsQuery =
                _context.Products.Include(c => c.Categories)
                .Where(a => filter == null || a.Name.ToLower().Contains(filter.ToLower()) || (a.Description != null && a.Description.ToLower().Contains(filter.ToLower())))
                .Where(a => fromPrice == null || a.Price >= fromPrice)
                .Where(a => toPric == null || a.Price <= toPric)
                .Where(a => categoryId == null || a.Categories.Any(b => b.Id == categoryId));
            return Task.FromResult(FilterProductsQuery);

        }
        public async Task<Product?> GetDetailsAsync(int id)
        {
            var product = await _context.Products
            .Include(a => a.Categories)
            .Include(c => c.CustomFields)
            .ThenInclude(d => d.CustomFieldData)
            .FirstOrDefaultAsync(a => a.Id == id);

            return product;
        }
    }
}
