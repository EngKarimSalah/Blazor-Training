using BlazorApp3.Data.Models;

namespace BlazorApp3.Data.Repositories
{
    public interface IProductRepository
    {
        int AddProduct(Product pr);
        int DeleteProduct(int id);
        List<Product> GetAllProducts();
        Product GetByID(int id);
        Product GetByName(string name);
        List<Product> GetPriceRange(decimal minPrice, decimal maxPrice);
        int UpdateProduct(Product pr);
    }
}