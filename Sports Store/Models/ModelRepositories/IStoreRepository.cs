using Microsoft.EntityFrameworkCore;
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
            return context.Products.FirstOrDefault(p => p.Id == id)!;
        }
    }
}