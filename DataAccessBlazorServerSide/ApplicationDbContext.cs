using BlazorApp3.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp3
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {

        }

        public DbSet<Product> products { get; set; }
    }
}
