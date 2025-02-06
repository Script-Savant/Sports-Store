namespace Sports_Store.Models
{
    public interface IStoreRepository
    {
        IQueryable<Product> Products { get; }
    }
}