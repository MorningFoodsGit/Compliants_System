using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data; // Replace with the correct namespace
using WebApplication2.Models; // Replace with the correct namespace

namespace WebApplication2.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
	[ApiController]
	public class ProductApiController : ControllerBase
	{
		private readonly ProductDbContext _context;

		public ProductApiController(ProductDbContext context)
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
				.Select(s => s.Stkid)// You can replace this with other properties you want to display
				.ToListAsync();


			return Ok(results);
		}
	}
}
