using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Infrastructure;
using QuanLyNhaHang.Models;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyNhaHang.Areas.QuanLyWebsite.Controllers
{
    [Area("Quanly")]
    public class BoPhanController : Controller
    {
        private readonly IGenericRepository<BOPHAN> _context;

        public BoPhanController(IGenericRepository<BOPHAN> context)
        {
            _context = context;    
        }

        //search
        public async Task<List<BOPHAN>> GetResult(string sortOrder, string mabp = null, string tenbp = null,
            string matruongbp = null)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.MaBoPhan = (sortOrder == "MaBoPhan") ? "MaBoPhanGiam" : "MaBoPhan";
            ViewBag.TenBoPhan = (sortOrder == "TenBoPhan") ? "TenBoPhanGiam" : "TenBoPhan";
            IQueryable<BOPHAN> result = _context.GetList().Where(c => 
            (mabp == null || c.MaBP == mabp) && (tenbp == null || c.TenBP == tenbp)
            && (matruongbp == null || c.MaTruongBP == matruongbp) && c.TrangThai == "1");
            switch(sortOrder)
            {
                case "TenBoPhanGiam":
                    {
                        result.OrderByDescending(c => c.TenBP);
                        break;
                    }
                case "TenBoPhan":
                    {
                        result.OrderBy(c => c.TenBP);
                        break;
                    }
                case "MaBoPhanGiam":
                    {
                        result.OrderByDescending(c => c.MaBP);
                        break;
                    }
                default:
                    {
                        result.OrderBy(c => c.MaBP);
                        break;
                    }
            }
            return await result.ToListAsync();

        }

        // GET: BoPhan
        public async Task<IActionResult> Index(string sortOrder, string mabp = null, string tenbp = null,
            string matruongbp = null)
        {
            return View(await GetResult(sortOrder,mabp,tenbp,matruongbp));
        }

        // GET: BoPhan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bophan = await _context.Get(id);
            if (bophan == null)
            {
                return NotFound();
            }

            return View(bophan);
        }

        // GET: BoPhan/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BoPhan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaBP,TenBP,MaTruongBP")] BOPHAN bophan)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(bophan);
                return RedirectToAction("Index");
            }
            return View(bophan);
        }

        // GET: BoPhan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bophan = await _context.Get(id);
            if (bophan == null)
            {
                return NotFound();
            }
            return View(bophan);
        }

        // POST: BoPhan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaBP,TenBP,MaTruongBP")] BOPHAN bophan)
        {
            if (id != bophan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(bophan);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoPhanExists(bophan.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(bophan);
        }

        private bool BoPhanExists(int id)
        {
            return _context.Exists(id);
        }

        // GET: BoPhan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bophan = await _context.Get(id);
            if (bophan == null)
            {
                return NotFound();
            }

            return View(bophan);
        }

        // POST: BoPhan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _context.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
