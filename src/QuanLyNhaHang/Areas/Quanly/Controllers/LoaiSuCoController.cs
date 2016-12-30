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

    public class LoaiSuCoController : Controller
    {
        private readonly IGenericRepository<LOAISUCO> _context;

        public LoaiSuCoController(IGenericRepository<LOAISUCO> context)
        {
            _context = context;
        }

        public async Task<List<LOAISUCO>> GetResult(string sortOrder, string maloaisuco = null,
           string tenloaisuco = null)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.MaLoaiSuCo = string.IsNullOrEmpty(sortOrder) ? "MaLoaiSuCoGiam" : "MaLoaiSuCo";
            ViewBag.TenLoaiSuCo = string.IsNullOrEmpty(sortOrder) ? "TenLoaiSuCoGiam" : "TenLoaiSuCo";
            IQueryable<LOAISUCO> result = _context.GetList().Where(c =>
           (maloaisuco == null || c.MaLoaiSuCo == maloaisuco) && (tenloaisuco == null || c.TenLoaiSuCo == tenloaisuco)
            && c.TrangThai == "1");
            switch (sortOrder)
            {
                case "TenLoaiSuCoGiam":
                    {
                        result.OrderByDescending(c => c.TenLoaiSuCo);
                        break;
                    }
                case "TenLoaiSuCo":
                    {
                        result.OrderBy(c => c.TenLoaiSuCo);
                        break;
                    }
                case "MaLoaiSuCoGiam":
                    {
                        result.OrderByDescending(c => c.MaLoaiSuCo);
                        break;
                    }
                default:
                    {
                        result.OrderBy(c => c.MaLoaiSuCo);
                        break;
                    }
            }
            return await result.ToListAsync();
        }
        // GET: LoaiSuCo
        public async Task<IActionResult> Index(string sortOrder, string maloaisuco = null,
           string tenloaisuco = null)
        {
            return View(await GetResult(sortOrder, maloaisuco, tenloaisuco));
        }

        // GET: LoaiSuCo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaisuco = await _context.Get(id);
            if (loaisuco == null)
            {
                return NotFound();
            }

            return View(loaisuco);
        }

        // GET: LoaiSuCo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LoaiSuCo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaBoPhanXuLy,MaLoaiSuCo,TenLoaiSuCo")] LOAISUCO loaisuco)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(loaisuco);
                return RedirectToAction("Index");
            }
            return View(loaisuco);
        }

        // GET: LoaiSuCo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaisuco = await _context.Get(id);
            if (loaisuco == null)
            {
                return NotFound();
            }
            return View(loaisuco);
        }

        // POST: LoaiSuCo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaBoPhanXuLy,MaLoaiSuCo,TenLoaiSuCo")] LOAISUCO loaisuco)
        {
            if (id != loaisuco.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(loaisuco);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiSuCoExists(loaisuco.Id))
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
            return View(loaisuco);
        }

        private bool LoaiSuCoExists(int id)
        {
            return _context.Exists(id);
        }

        // GET: LoaiSuCo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaisuco = await _context.Get(id);
            if (loaisuco == null)
            {
                return NotFound();
            }

            return View(loaisuco);
        }

        // POST: LoaiSuCo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _context.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
