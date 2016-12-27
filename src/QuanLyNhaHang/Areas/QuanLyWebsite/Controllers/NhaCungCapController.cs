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
    public class NhaCungCapController : Controller
    {
        private readonly IGenericRepository<NHACUNGCAP> _context;

        public NhaCungCapController(IGenericRepository<NHACUNGCAP> context)
        {
            _context = context;    
        }

        public async Task<List<NHACUNGCAP>> GetResult(string sortOrder, string mancc = null,
      string tenncc = null)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.MaNL = string.IsNullOrEmpty(sortOrder) ? "MaNCCGiam" : "MaNCC";
            ViewBag.TenNL = string.IsNullOrEmpty(sortOrder) ? "TenNCCGiam" : "TenNCC";
            IQueryable<NHACUNGCAP> result = _context.GetList().Where(c =>
           (mancc == null || c.MaNCC == mancc) && (tenncc == null || c.TenNCC == tenncc)
           && c.TrangThai == "1");
            switch (sortOrder)
            {
                case "TenNCCGiam":
                    {
                        result.OrderByDescending(c => c.TenNCC);
                        break;
                    }
                case "TenNCC":
                    {
                        result.OrderBy(c => c.TenNCC);
                        break;
                    }
                case "MaNCCGiam":
                    {
                        result.OrderByDescending(c => c.MaNCC);
                        break;
                    }
                default:
                    {
                        result.OrderBy(c => c.MaNCC);
                        break;
                    }
            }
            return await result.ToListAsync();
        }

        // GET: NhaCungCap
        public async Task<IActionResult> Index(string sortOrder, string mancc = null,
      string tenncc = null)
        {
            return View(await GetResult(sortOrder, mancc, tenncc));
        }

        // GET: NhaCungCap/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhacungcap = await _context.Get(id);
            if (nhacungcap == null)
            {
                return NotFound();
            }

            return View(nhacungcap);
        }

        // GET: NhaCungCap/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NhaCungCap/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DiaChi,MaNCC,TenNCC,SoDT,SoNo")] NHACUNGCAP nhacungcap)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(nhacungcap);
                return RedirectToAction("Index");
            }
            return View(nhacungcap);
        }

        // GET: NhaCungCap/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhacungcap = await _context.Get(id);
            if (nhacungcap == null)
            {
                return NotFound();
            }
            return View(nhacungcap);
        }

        // POST: NhaCungCap/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DiaChi,MaNCC,TenNCC,SoDT,SoNo")] NHACUNGCAP nhacungcap)
        {
            if (id != nhacungcap.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(nhacungcap);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhaCungCapExists(nhacungcap.Id))
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
            return View(nhacungcap);
        }

        private bool NhaCungCapExists(int id)
        {
            return _context.Exists(id);
        }

        // GET: NhaCungCap/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhacungcap = await _context.Get(id);
            if (nhacungcap == null)
            {
                return NotFound();
            }

            return View(nhacungcap);
        }

        // POST: NhaCungCap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _context.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
