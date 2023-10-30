using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Models;
using Microsoft.AspNetCore.Http;

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
            // Replace this with your actual data retrieval logic
            List<cmplnt_base> cmplnt_baseData = GetComplaintsData();

            ViewBag.Complaints = cmplnt_baseData;

            return View();
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

        // GET: Analysis/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Analysis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Analysis/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Analysis/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Analysis/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Analysis/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Analysis/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

