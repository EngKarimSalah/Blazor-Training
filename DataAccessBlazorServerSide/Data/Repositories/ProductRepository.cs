using BlazorApp3.Data.Models;

namespace BlazorApp3.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Product> GetAllProducts()
        {
            return _context.products.ToList();
        }

        public Product GetByID(int id)
        {
            return _context.products.FirstOrDefault(p => p.Id == id);
        }

        public Product GetByName(string name)
        {
            return _context.products.FirstOrDefault(p => p.Name == name);

        }

        public List<Product> GetPriceRange(decimal minPrice, decimal maxPrice)
        {
            return _context.products.Where(p => p.Price > minPrice && p.Price < maxPrice).ToList();
        }

        public int AddProduct(Product pr)
        {

            _context.products.Add(pr);
            _context.SaveChanges();
            return pr.Id;
        }

        public int UpdateProduct(Product pr)
        {
            Product product = GetByID(pr.Id);
            if (product != null)
            {
                product.Name = pr.Name;
                product.Description = pr.Description;
                product.Price = pr.Price;

                _context.products.Update(product);
                _context.SaveChanges(true);
                return 1;
            }

            return -1;

        }

        public int DeleteProduct(int id)
        {
            Product product = GetByID(id);
            if (product != null)
            {
                _context.products.Remove(product);
                _context.SaveChanges();
                return 1;
            }

            return -1;
        }

    }
}
