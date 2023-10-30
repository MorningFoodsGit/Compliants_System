using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Views.cmplnt_base;

namespace WebApplication2.Controllers
{
    [Authorize]
    public class cmplnt_baseController : Controller
    {
        private readonly ComplaintsDbContext _context;

        public cmplnt_baseController(ComplaintsDbContext context)
        {
            _context = context;
        }

        // GET: cmplnt_base
        // GET: Complaints
        public async Task<IActionResult> Index(
          string sortOrder,
          string currentFilter,
          string searchString,
          string filterString,
          bool? sortComplainantName,
          string filterComplainantName,
          string filterComplainantDescription,
          string filterComplainantRefrence,
          string filterComplainantMF,
          string filterComplainantRetailer,
          string filterComplainantSite,
          string filterProductDes,
          string filterProductCat,
          string filterProductMf,
          string filterComplaintCat,
          int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["SiteSortParm"] = sortOrder == "Site" ? "site_desc" : "Site";
            ViewData["RetailerSortParm"] = sortOrder == "Retailer" ? "retailer_desc" : "Retailer";
            ViewData["ProductCategorySortParm"] = sortOrder == "ProductCategory" ? "product_category_desc" : "ProductCategory";
            ViewData["ComplaintCategorySortParm"] = sortOrder == "ComplaintCategory" ? "complaint_category_desc" : "ComplaintCategory";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var complaints = _context.cmplnt_base.AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
                complaints = complaints.Where(c =>
                    c.cstmr_nme.Contains(searchString) ||
                    c.rtlr.Contains(searchString) ||
                    c.Site.Contains(searchString) ||
                    c.Actn.Contains(searchString) ||
                    c.cmplnt_desc.Contains(searchString) ||
                    c.cmplnt_dte.ToString().Contains(searchString)); // Assuming cmplnt_dte is of DateTime type
            }

            // Apply sorting based on checkboxes and sort parameters
            if (sortComplainantName == true)
            {
                complaints = complaints.OrderBy(c => c.cstmr_nme);
            }
            else if (sortComplainantName == false)
            {
                complaints = complaints.OrderByDescending(c => c.cstmr_nme);
            }


            // Apply filtering based on checkboxes
            if (!string.IsNullOrEmpty(filterComplainantName))
            {
                complaints = complaints.Where(c => c.cstmr_nme == filterComplainantName);
            }
            if (!string.IsNullOrEmpty(filterComplainantDescription))
            {
                complaints = complaints.Where(c => c.cmplnt_desc == filterComplainantDescription);
            }
            if (!string.IsNullOrEmpty(filterComplainantRefrence))
            {
                complaints = complaints.Where(c => c.cstmr_ref_rtlr == filterComplainantRefrence);
            }
            if (!string.IsNullOrEmpty(filterComplainantMF))
            {
                complaints = complaints.Where(c => c.cstmr_ref_mf == filterComplainantMF);
            }
            if (!string.IsNullOrEmpty(filterComplainantRetailer))
            {
                complaints = complaints.Where(c => c.rtlr == filterComplainantRetailer);
            }
            if (!string.IsNullOrEmpty(filterComplainantSite))
            {
                complaints = complaints.Where(c => c.Site == filterComplainantSite);
            }
            if (!string.IsNullOrEmpty(filterProductDes))
            {
                complaints = complaints.Where(c => c.prdct_desc == filterProductDes);
            }
            if (!string.IsNullOrEmpty(filterProductCat))
            {
                complaints = complaints.Where(c => c.prdct_ctgry == filterProductCat);
            }
            if (!string.IsNullOrEmpty(filterProductMf))
            {
                complaints = complaints.Where(c => c.prdct_cde_mf == filterProductMf);
            }
            if (!string.IsNullOrEmpty(filterComplaintCat))
            {
                complaints = complaints.Where(c => c.cmplnt_ctgry == filterComplaintCat);
            }



            switch (sortOrder)
            {
                case "name_desc":
                    complaints = complaints.OrderByDescending(c => c.cstmr_nme);
                    break;
                case "Date":
                    complaints = complaints.OrderBy(c => c.cmplnt_dte);
                    break;
                case "date_desc":
                    complaints = complaints.OrderByDescending(c => c.cmplnt_dte);
                    break;
                case "Site":
                    complaints = complaints.OrderBy(c => c.Site);
                    break;
                case "site_desc":
                    complaints = complaints.OrderByDescending(c => c.Site);
                    break;
                case "Retailer":
                    complaints = complaints.OrderBy(c => c.rtlr);
                    break;
                case "retailer_desc":
                    complaints = complaints.OrderByDescending(c => c.rtlr);
                    break;
                case "ProductCategory":
                    complaints = complaints.OrderBy(c => c.prdct_ctgry);
                    break;
                case "product_category_desc":
                    complaints = complaints.OrderByDescending(c => c.prdct_ctgry);
                    break;
                case "ComplaintCategory":
                    complaints = complaints.OrderBy(c => c.cmplnt_ctgry);
                    break;
                case "complaint_category_desc":
                    complaints = complaints.OrderByDescending(c => c.cmplnt_ctgry);
                    break;
                default:
                    // Exclude items where cmplnt_ID is null, then sort by cmplnt_ID
                    complaints = complaints.Where(c => c.cmplnt_ID != null).OrderByDescending(c => c.cmplnt_ID);
                    break;

            }

            // Retrieve all complaints and store them in ViewBag
            ViewBag.AllComplaints = await _context.cmplnt_base.ToListAsync();

            int pageSize = 10;
            return View(await PaginatedList<cmplnt_base>.CreateAsync(complaints.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: cmplnt_base/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.cmplnt_base == null)
            {
                return NotFound();
            }

            var cmplnt_base = await _context.cmplnt_base
                .FirstOrDefaultAsync(m => m.cmplnt_ID == id);
            if (cmplnt_base == null)
            {
                return NotFound();
            }

            return View(cmplnt_base);
        }

        // GET: cmplnt_base/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: cmplnt_base/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cmplnt_ID,cstmr_nme,cstmr_ref_rtlr,cstmr_ref_mf,rtlr,Site,prdct_ctgry,prdct_cde_rtlr,prdct_cde_mf,bbe_info,cmplnt_ctgry,cmplnt_src,cmplnt_desc,jlenne_cde,prdct_desc,Actn,bbe_dte,cmplnt_dte,tdy_dte")] cmplnt_base cmplnt_base)
        {
            if (ModelState.IsValid)
            {
				// Set the date fields if needed
				cmplnt_base.tdy_dte = DateTime.Today;

				_context.Add(cmplnt_base);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cmplnt_base);
        }

        // GET: cmplnt_base/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.cmplnt_base == null)
            {
                return NotFound();
            }

            var cmplnt_base = await _context.cmplnt_base.FindAsync(id);
            if (cmplnt_base == null)
            {
                return NotFound();
            }
            return View(cmplnt_base);
        }

        // POST: cmplnt_base/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("cmplnt_ID,cstmr_nme,cstmr_ref_rtlr,cstmr_ref_mf,rtlr,Site,prdct_ctgry,prdct_cde_rtlr,prdct_cde_mf,bbe_info,cmplnt_ctgry,cmplnt_src,cmplnt_desc,jlenne_cde,prdct_desc,Actn,bbe_dte,cmplnt_dte,tdy_dte")] cmplnt_base cmplnt_base)
        {
            if (id != cmplnt_base.cmplnt_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cmplnt_base);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!cmplnt_baseExists(cmplnt_base.cmplnt_ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cmplnt_base);
        }

        // GET: cmplnt_base/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.cmplnt_base == null)
            {
                return NotFound();
            }

            var cmplnt_base = await _context.cmplnt_base
                .FirstOrDefaultAsync(m => m.cmplnt_ID == id);
            if (cmplnt_base == null)
            {
                return NotFound();
            }

            return View(cmplnt_base);
        }

        // POST: cmplnt_base/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.cmplnt_base == null)
            {
                return Problem("Entity set 'ComplaintsDbContext.cmplnt_base'  is null.");
            }
            var cmplnt_base = await _context.cmplnt_base.FindAsync(id);
            if (cmplnt_base != null)
            {
                _context.cmplnt_base.Remove(cmplnt_base);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool cmplnt_baseExists(int id)
        {
          return (_context.cmplnt_base?.Any(e => e.cmplnt_ID == id)).GetValueOrDefault();
        }
        [HttpGet]
        
        public IActionResult GetActionCount(string actionName)
        {
            // Fetch the count of the specified action from the database
            int count = _context.cmplnt_base.Count(c => c.Actn == actionName);

            return Json(count);
        }

        [HttpGet]

        public IActionResult GetTotalComplaintCount()

        {

            // Fetch the total count of complaints from the database

            int count = _context.cmplnt_base.Count();


            return Json(count);

        }

        [HttpGet]
        public IActionResult GetRetailerQuantities()
        {
            var retailerQuantities = _context.cmplnt_base
                .GroupBy(c => c.rtlr)
                .Select(group => new
                {
                    Retailer = group.Key,
                    Quantity = group.Count() // Count the number of complaints for each retailer
                })
                .ToList();

            return View("GetRetailerQuantities", retailerQuantities);
        }

        [HttpGet]
        public IActionResult GetRetailerQuantities2()
        {
            var retailerQuantities = _context.cmplnt_base
                .GroupBy(c => c.rtlr)
                .Select(group => new
                {
                    Retailer = group.Key,
                    Quantity = group.Count() // Count the number of complaints for each retailer
                })
                .ToList();

            return Json(retailerQuantities);
        }



        [HttpGet]
        public IActionResult GetRetailerCount()
        {
            // Fetch the count of unique retailers from the database
            int count = _context.cmplnt_base.Select(c => c.rtlr).Distinct().Count();

            return Json(count);
        }
        public IActionResult test()
        {
            return View();
        }

    }
}
