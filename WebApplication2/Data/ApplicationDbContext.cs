using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Use your connection string here
            string connectionString = "Server=mf-new-sql2016;Database=Complaints;Trusted_Connection=True;MultipleActiveResultSets=true;User ID=ComplaintUser;Password=B4ckTh3M4ntr4;Integrated Security=False";
            optionsBuilder.UseSqlServer(connectionString);
         
        }
    }
}
