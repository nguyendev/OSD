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
    public class NhanVienController : Controller
    {
        private readonly IGenericRepository<NHANVIEN> _context;

        public NhanVienController(IGenericRepository<NHANVIEN> context)
        {
            _context = context;    
        }

        public async Task<List<NHANVIEN>> GetResult(string sortOrder, string manv = null,
      string tennv = null, string mabp = null)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.MaNV = string.IsNullOrEmpty(sortOrder) ? "MaNVGiam" : "MaNV";
            ViewBag.TenNV = string.IsNullOrEmpty(sortOrder) ? "TenNVGiam" : "TenNV";
            IQueryable<NHANVIEN> result = _context.GetList().Where(c =>
           (manv == null || c.MaNV == manv) && (tennv == null || c.TenNV == tennv)
           && (mabp == null || c.MaBP == mabp) && c.TrangThai == "1");
            switch (sortOrder)
            {
                case "TenNVGiam":
                    {
                        result.OrderByDescending(c => c.TenNV);
                        break;
                    }
                case "TenNV":
                    {
                        result.OrderBy(c => c.TenNV);
                        break;
                    }
                case "MaNVGiam":
                    {
                        result.OrderByDescending(c => c.MaNV);
                        break;
                    }
                default:
                    {
                        result.OrderBy(c => c.MaNV);
                        break;
                    }
            }
            return await result.ToListAsync();
        }
        // GET: NhanVien
        public async Task<IActionResult> Index(string sortOrder, string manv = null,
      string tennv = null, string mabp = null)
        {
            return View(await GetResult(sortOrder, manv,tennv, mabp));
        }

        // GET: NhanVien/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Get(id);
            if (nhanvien == null)
            {
                return NotFound();
            }

            return View(nhanvien);
        }

        // GET: NhanVien/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NhanVien/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaNV,TenNV,MaBP,CMND,DiaChi,SoDT")] NHANVIEN nhanvien)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(nhanvien);
                return RedirectToAction("Index");
            }
            return View(nhanvien);
        }

        // GET: NhanVien/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Get(id);
            if (nhanvien == null)
            {
                return NotFound();
            }
            return View(nhanvien);
        }

        // POST: NhanVien/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaNV,TenNV,MaBP,CMND,DiaChi,SoDT")] NHANVIEN nhanvien)
        {
            if (id != nhanvien.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(nhanvien);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhanVienExists(nhanvien.Id))
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
            return View(nhanvien);
        }

        private bool NhanVienExists(int id)
        {
            return _context.Exists(id);
        }

        // GET: NhanVien/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Get(id);
            if (nhanvien == null)
            {
                return NotFound();
            }

            return View(nhanvien);
        }

        // POST: NhanVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _context.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
