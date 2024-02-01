using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace WebApplication2

{

    public class Program

    {

        public static void Main(string[] args)

        {

            var host = CreateHostBuilder(args).Build();


            // Perform any database migration or seed data initialization here

            // ...


            host.Run();

        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>

            Host.CreateDefaultBuilder(args)

                .ConfigureServices((context, services) =>

                {

                    var connectionString = context.Configuration.GetConnectionString("DefaultConnection");

                    services.AddDbContext<ApplicationDbContext>(options =>

                        options.UseSqlServer(connectionString));

                    services.AddDatabaseDeveloperPageExceptionFilter();


                    var complaintsConnectionString = context.Configuration.GetConnectionString("ComplaintsConnection");

                    services.AddDbContext<ComplaintsDbContext>(options =>

                        options.UseSqlServer(complaintsConnectionString));


                    var productConnectionString = context.Configuration.GetConnectionString("ProductConnection");

                    services.AddDbContext<ProductDbContext>(options =>

                        options.UseSqlServer(productConnectionString));


                    services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)

                        .AddEntityFrameworkStores<ApplicationDbContext>();

                    services.AddControllersWithViews();

                });
		

	}

}