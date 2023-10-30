using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }

        // DbSet for the "Product" model
        public DbSet<Stock> Stock { get; set; }
        public object Stocks { get; internal set; }
    }
}
