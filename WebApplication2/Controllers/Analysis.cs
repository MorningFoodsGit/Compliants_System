using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Models.ViewModels;


namespace WebApplication2.Controllers
{

    public class Analysis : Controller
    {
        private readonly ComplaintsDbContext _context;

        public Analysis(ComplaintsDbContext context)
        {
            _context = context;
        }

        // GET: Analysis
        public IActionResult Index()
        {
            var retailerCategoryCounts = _context.cmplnt_base
                 .GroupBy(c => new { c.rtlr, c.prdct_ctgry })
                 .Select(group => new AnalysisViewModel
                 {
                     Retailer = group.Key.rtlr,
                     Category = group.Key.prdct_ctgry,
                     Count = group.Count()
                 })
                 .ToList();

            return View(retailerCategoryCounts);
        }

        private List<cmplnt_base> GetComplaintsData()
        {

            {
                return _context.cmplnt_base.ToList();
            }
        }

        [HttpGet]
        public IActionResult GetChartData()
        {
            var data = _context.cmplnt_base
                .Select(c => new
                {
                    c.rtlr,
                    c.prdct_cde_mf,
                    c.prdct_desc
                })
                .ToList();

            return Json(data);
        }       

		[HttpGet]
		public IActionResult GetRetailerCategoryCounts()
		{
			var retailerCategoryCounts = _context.cmplnt_base
				.GroupBy(c => new { c.rtlr, c.prdct_ctgry })
				.Select(group => new
				{
					Retailer = group.Key.rtlr,
					Category = group.Key.prdct_ctgry,
					Count = group.Count()
				})
				.ToList();

			return View(retailerCategoryCounts);
		}

		[HttpGet]
		public IActionResult GetRetailers()
		{
			var retailers = _context.cmplnt_base.Select(c => c.rtlr).Distinct().ToList();
			var viewModel = new AnalysisViewModel
			{
				Retailers = retailers
			};
			return View(viewModel);
		}

        [HttpGet]
        public IActionResult GetRetailerCategoryCount()
        {
            var retailerCategoryCounts = _context.cmplnt_base
                .GroupBy(c => new { c.rtlr, c.prdct_ctgry })
                .Select(group => new AnalysisViewModel
                {
                    Retailer = group.Key.rtlr,
                    Category = group.Key.prdct_ctgry,
                    Count = group.Count()
                })
                .ToList();

            return View(retailerCategoryCounts);
        }
    }
}

