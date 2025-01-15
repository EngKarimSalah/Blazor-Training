using BlazorApp3.Data.Models;
using BlazorApp3.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp3.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public List<Product> GetAllProducts()
        {
            return _repository.GetAllProducts();
        }

        public Product GetByID(int id)
        {
            return _repository.GetByID(id);
        }

        public Product GetByName(string name)
        {
            return _repository.GetByName(name);

        }

        public List<Product> GetPriceRange(decimal minPrice, decimal maxPrice)
        {
            return _repository.GetPriceRange(minPrice, maxPrice);
        }

        public int AddProduct(Product pr)
        {

            return _repository.AddProduct(pr);
        }

        public int UpdateProduct(Product pr)
        {
            return _repository.UpdateProduct(pr);
        }

        public int DeleteProduct(int id)
        {
            return _repository.DeleteProduct(id);
        }
    }
}
