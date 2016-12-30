using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Infrastructure;
using QuanLyNhaHang.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;

namespace QuanLyNhaHang.Areas.QuanLyWebsite.Controllers
{
    [Area("Quan-ly")]
    [Authorize]
    public class HoaDonNhapHangController : Controller
    {
        private readonly IGenericRepository<HOADONNHAPHANG> _context;

        public HoaDonNhapHangController(IGenericRepository<HOADONNHAPHANG> context)
        {
            _context = context;    
        }
        
        private async Task<List<HOADONNHAPHANG>> GetResult(string mahd = null,
            string manv = null, string ngaylap = null, string mayc = null)
        {
            IQueryable<HOADONNHAPHANG> result = _context.GetList().Where(c =>
          (mahd == null || c.MaHD == mahd) && (manv == null || c.MaNV == manv)
          && (mahd == null || c.MaHD == mahd) && (manv == null || c.MaNV == manv)
          && c.TrangThai == "1");
            return await result.ToListAsync();
        }
        // GET: HoaDonNhapHang
        public async Task<IActionResult> Index(string mahd = null,
            string manv = null, string ngaylap = null, string mayc = null)
        {
            return View(await GetResult(mahd, manv, ngaylap, mayc));
        }

        // GET: HoaDonNhapHang/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoadonnhaphang = await _context.Get(id);
            if (hoadonnhaphang == null)
            {
                return NotFound();
            }

            return View(hoadonnhaphang);
        }

        // GET: HoaDonNhapHang/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HoaDonNhapHang/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HOADONNHAPHANG hoadonnhaphang)
        {
            if (ModelState.IsValid)
            {
                hoadonnhaphang.NgayTao = DateTime.Now;
                hoadonnhaphang.TrangThai = "1";
                hoadonnhaphang.TrangThaiDuyet = "U";
                await _context.Add(hoadonnhaphang);
                return RedirectToAction("Index");
            }
            return View(hoadonnhaphang);
        }

        // GET: HoaDonNhapHang/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoadonnhaphang = await _context.Get(id);
            if (hoadonnhaphang == null)
            {
                return NotFound();
            }
            return View(hoadonnhaphang);
        }

        // POST: HoaDonNhapHang/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, HOADONNHAPHANG hoadonnhaphang)
        {
            if (id != hoadonnhaphang.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    hoadonnhaphang.TrangThaiDuyet = "U";
                    await _context.Update(hoadonnhaphang);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoaDonNhapHangExists(hoadonnhaphang.Id))
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
            return View(hoadonnhaphang);
        }

        private bool HoaDonNhapHangExists(int id)
        {
            return _context.Exists(id);
        }

        // GET: HoaDonNhapHang/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoadonnhaphang = await _context.Get(id);
            if (hoadonnhaphang == null)
            {
                return NotFound();
            }

            return View(hoadonnhaphang);
        }

        // POST: HoaDonNhapHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hoadon = await _context.Get(id);
            if (ModelState.IsValid)
            {
                if (hoadon.TrangThaiDuyet == "A")
                {
                    hoadon.TrangThai = "0";
                    hoadon.TrangThaiDuyet = "U";
                    await _context.Update(hoadon);
                }
                else
                    await _context.Delete(id);
            }
            return RedirectToAction("Index");
        }
    }
}
