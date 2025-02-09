using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Sports_Store.Data;
using Sports_Store.Models.ModelInterfaces;

namespace Sports_Store.Models.ModelRepositories
{
    public class IStoreRepository : IStoreInterface
    {
        private readonly StoreDbContext context;

        public IStoreRepository(StoreDbContext _context)
        {
            context = _context;
        }

        public IQueryable<Product> Products => context.Products;

        public Product GetProductById(long id)
        {
            var product = context.Products
                .Include(p => p.ProductImages)
                .FirstOrDefault(p => p.Id == id)!;
                
            return product;
        }
    }
}