using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class ComplaintsDbContext: DbContext
    {
        public ComplaintsDbContext(DbContextOptions<ComplaintsDbContext> options) : base(options)
        {
        }

        // DbSet for the "Complaints" model
        public DbSet<cmplnt_base> cmplnt_base { get; set; }

        // DbSet for the "Complaints" model
        public DbSet<WebApplication2.Models.cmplnt_base>? cmplnt_base_1 { get; set; }

    }
}
