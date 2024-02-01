using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class SearchExternalDatabaseController : ControllerBase
	{
		private readonly ProductDbContext _context;

        public SearchExternalDatabaseController(ProductDbContext context)
		{
			_context = context;

        }

		[HttpGet]
		public async Task<IActionResult> GetSearchResults(string query)
		{
			// Perform the search query on the database using EF Core
			var results = await _context.Stock
				.Where(s =>
					s.Stkid.Contains(query) ||
					s.StkDesc.Contains(query))
				.Select(s => s.StkDesc)// You can replace this with other properties you want to display
				.ToListAsync();

			return Ok(results);
		}
      
    }
}