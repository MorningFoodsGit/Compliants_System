using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilterController : ControllerBase
    {
        private readonly ComplaintsDbContext _compliantContext;

        public FilterController(ComplaintsDbContext compliantContext)
        {
            _compliantContext = compliantContext;
        }
		[HttpGet]
		[Route("GetComplainantName")]
		public async Task<IActionResult> GetComplainantName(string query)
		{
			var results = await _compliantContext.cmplnt_base
				.Where(s => s.cstmr_nme.Contains(query))
				.Select(s => s.cstmr_nme)
				.Distinct()
				.ToListAsync();

			return Ok(results);
		}
		[HttpGet]
		[Route("GetCompliantDescription")]
		public async Task<IActionResult> GetCompliantDescription(string query3)
		{
			var results = await _compliantContext.cmplnt_base
				.Where(s => s.cmplnt_desc.Contains(query3))
				.Select(s => s.cmplnt_desc)
				.Distinct()
				.ToListAsync();

			return Ok(results);
		}
		[HttpGet]
		[Route("GetProductDescription")]
		public async Task<IActionResult> GetProductDescription(string query4)
		{
			var results = await _compliantContext.cmplnt_base
				.Where(s => s.prdct_desc.Contains(query4))
				.Select(s => s.prdct_desc)
				.Distinct()
				.ToListAsync();

			return Ok(results);
		}
	}
}
