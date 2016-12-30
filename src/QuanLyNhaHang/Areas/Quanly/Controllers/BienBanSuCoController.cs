using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Models;
using QuanLyNhaHang.Infrastructure;

namespace QuanLyNhaHang.Areas.Quanly.Controllers
{
    [Area("Quanly")]
    public class BienBanSuCoController : Controller
    {
        private readonly IGenericRepository<BIENBANSUCO> _context;

        public BienBanSuCoController(IGenericRepository<BIENBANSUCO> context)
        {
            _context = context;    
        }

        private async Task<List<BIENBANSUCO>> GetResult(string mabienban = null,
            string maloaisuco = null, string manv = null, DateTime? thoigian = null)
        {
            IQueryable<BIENBANSUCO> result = _context.GetList().Where(c =>
            (mabienban == null || c.MaBienBan == mabienban) && (maloaisuco == null || c.MaLoaiSuCo == maloaisuco)
            && (manv == null || c.MaNV == manv) 
            && (thoigian == null || DateTime.Compare(Convert.ToDateTime(c.ThoiGian),thoigian.Value) == 0)
            && c.TrangThai == "1");
            return await result.ToListAsync();

        }
        // GET: BienBanSuCo
        public async Task<IActionResult> Index(string mabienban = null,
            string maloaisuco = null, string manv = null, DateTime? thoigian = null)
        {
            return View(await GetResult(mabienban, maloaisuco, manv, thoigian = null));
        }

        // GET: BienBanSuCo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bienbansuco = await _context.Get(id);
            if (bienbansuco == null)
            {
                return NotFound();
            }
            return View(bienbansuco);
        }

        // GET: BienBanSuCo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BienBanSuCo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BIENBANSUCO bienbansuco)
        {
            if (ModelState.IsValid)
            {
                bienbansuco.NgayTao = DateTime.Now;
                bienbansuco.TrangThai = "1";
                bienbansuco.TrangThaiDuyet = "U";
                await _context.Add(bienbansuco);
                return RedirectToAction("Index");
            }
            return View(bienbansuco);
        }

        // GET: BienBanSuCo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bienbansuco = await _context.Get(id);
            if (bienbansuco == null)
            {
                return NotFound();
            }
            return View(bienbansuco);
        }

        // POST: BienBanSuCo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BIENBANSUCO bienbansuco)
        {
            if (id != bienbansuco.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    bienbansuco.TrangThaiDuyet = "U";
                    await _context.Update(bienbansuco);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BienBanSuCoExists(bienbansuco.Id))
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
            return View(bienbansuco);
        }

        // GET: BienBanSuCo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bienbansuco = await _context.Get(id);
            if (bienbansuco == null)
            {
                return NotFound();
            }

            return View(bienbansuco);
        }

        // POST: BienBanSuCo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bienbansuco = await _context.Get(id);
            if (ModelState.IsValid)
            {
                if (bienbansuco.TrangThaiDuyet == "A")
                {
                    bienbansuco.TrangThai = "0";
                    bienbansuco.TrangThaiDuyet = "U";
                    await _context.Update(bienbansuco);
                }
                else
                    await _context.Delete(id);
            }
            return RedirectToAction("Index");
        }

        private bool BienBanSuCoExists(int id)
        {
            return _context.Exists(id);
        }
    }
}
