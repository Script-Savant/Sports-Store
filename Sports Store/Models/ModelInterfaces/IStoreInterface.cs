namespace Sports_Store.Models.ModelInterfaces
{
    public interface IStoreInterface
    {
        IQueryable<Product> Products { get; }
    }
}