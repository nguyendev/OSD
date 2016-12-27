using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Infrastructure;
using QuanLyNhaHang.Models;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyNhaHang.Areas.QuanLyWebsite.Controllers
{
    [Area("QuanLyWebsite")]

    public class NguyenLieuController : Controller
    {
        private readonly IGenericRepository<NGUYENLIEU> _context;
        public NguyenLieuController(IGenericRepository<NGUYENLIEU> context)
        {
            _context = context;    
        }

        public async Task<List<NGUYENLIEU>> GetResult(string sortOrder, string manl = null,
        string tennl = null)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.MaNL = string.IsNullOrEmpty(sortOrder) ? "MaNLGiam" : "MaNL";
            ViewBag.TenNL = string.IsNullOrEmpty(sortOrder) ? "TenNLGiam" : "TenNL";
            IQueryable<NGUYENLIEU> result = _context.GetList().Where(c =>
           (manl == null || c.MaNL == manl) && (tennl == null || c.TenNL == tennl)
           && c.TrangThai == "1");
            switch (sortOrder)
            {
                case "TenMonGiam":
                    {
                        result.OrderByDescending(c => c.TenNL);
                        break;
                    }
                case "TenMon":
                    {
                        result.OrderBy(c => c.TenNL);
                        break;
                    }
                case "MaMonGiam":
                    {
                        result.OrderByDescending(c => c.MaNL);
                        break;
                    }
                default:
                    {
                        result.OrderBy(c => c.MaNL);
                        break;
                    }
            }
            return await result.ToListAsync();
        }
        // GET: NguyenLieu
        public async Task<IActionResult> Index(string sortOrder, string manl = null,
        string tennl = null)
        {
            return View(await GetResult(sortOrder, manl,tennl));
        }

        // GET: NguyenLieu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguyenlieu = await _context.Get(id);
            if (nguyenlieu == null)
            {
                return NotFound();
            }

            return View(nguyenlieu);
        }

        // GET: NguyenLieu/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NguyenLieu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaNL,TenNL,DVT,Gia,XuatXu")] NGUYENLIEU nguyenlieu)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(nguyenlieu);
                return RedirectToAction("Index");
            }
            return View(nguyenlieu);
        }

        // GET: NguyenLieu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguyenlieu = await _context.Get(id);
            if (nguyenlieu == null)
            {
                return NotFound();
            }
            return View(nguyenlieu);
        }

        // POST: NguyenLieu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaNL,TenNL,DVT,Gia,XuatXu")] NGUYENLIEU nguyenlieu)
        {
            if (id != nguyenlieu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(nguyenlieu);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NguyenLieuExists(nguyenlieu.Id))
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
            return View(nguyenlieu);
        }

        private bool NguyenLieuExists(int id)
        {
            return _context.Exists(id);
        }

        // GET: NguyenLieu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguyenlieu = await _context.Get(id);
            if (nguyenlieu == null)
            {
                return NotFound();
            }

            return View(nguyenlieu);
        }

        // POST: NguyenLieu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _context.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
