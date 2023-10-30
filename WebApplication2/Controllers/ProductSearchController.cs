using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data; 
using WebApplication2.Models; 

namespace WebApplication2.Controllers

{
    [Authorize]
    public class ProductSearchController : Controller
   {
       private readonly ProductDbContext _context;

       public ProductSearchController(ProductDbContext context)
       {
           _context = context;
       }

       public IActionResult Index()
       {
           return View();
       }

       [HttpPost]
       public IActionResult Search(string query)
       {
           if (string.IsNullOrEmpty(query))
           {
               return BadRequest("Query parameter is required.");
           }

           var results = _context.Stock
               .Where(p => p.Stkid.Contains(query) || p.StkDesc.Contains(query))
               .ToList();

			return PartialView("_SearchResults", results);
		}

   }
}