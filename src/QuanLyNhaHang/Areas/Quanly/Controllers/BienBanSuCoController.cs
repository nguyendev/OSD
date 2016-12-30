using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Data;
using QuanLyNhaHang.Models;

namespace QuanLyNhaHang.Areas.Quanly.Controllers
{
	[Area("Quanly")]
    public class BienBanSuCoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BienBanSuCoController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: BienBanSuCo
        public async Task<IActionResult> Index()
        {
            return View(await _context.BIENBANSUCO.ToListAsync());
        }

        // GET: BienBanSuCo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bIENBANSUCO = await _context.BIENBANSUCO.SingleOrDefaultAsync(m => m.Id == id);
            if (bIENBANSUCO == null)
            {
                return NotFound();
            }

            return View(bIENBANSUCO);
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
        public async Task<IActionResult> Create([Bind("Id,GhiChu,HuongGiaiQuyet,MaBienBan,MaLoaiSuCo,MaNV,NgayDuyet,NgayTao,NguyenNhan,ThoiGian,TrangThai,TrangThaiDuyet")] BIENBANSUCO bIENBANSUCO)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bIENBANSUCO);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(bIENBANSUCO);
        }

        // GET: BienBanSuCo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bIENBANSUCO = await _context.BIENBANSUCO.SingleOrDefaultAsync(m => m.Id == id);
            if (bIENBANSUCO == null)
            {
                return NotFound();
            }
            return View(bIENBANSUCO);
        }

        // POST: BienBanSuCo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GhiChu,HuongGiaiQuyet,MaBienBan,MaLoaiSuCo,MaNV,NgayDuyet,NgayTao,NguyenNhan,ThoiGian,TrangThai,TrangThaiDuyet")] BIENBANSUCO bIENBANSUCO)
        {
            if (id != bIENBANSUCO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bIENBANSUCO);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BIENBANSUCOExists(bIENBANSUCO.Id))
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
            return View(bIENBANSUCO);
        }

        // GET: BienBanSuCo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bIENBANSUCO = await _context.BIENBANSUCO.SingleOrDefaultAsync(m => m.Id == id);
            if (bIENBANSUCO == null)
            {
                return NotFound();
            }

            return View(bIENBANSUCO);
        }

        // POST: BienBanSuCo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bIENBANSUCO = await _context.BIENBANSUCO.SingleOrDefaultAsync(m => m.Id == id);
            _context.BIENBANSUCO.Remove(bIENBANSUCO);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool BIENBANSUCOExists(int id)
        {
            return _context.BIENBANSUCO.Any(e => e.Id == id);
        }
    }
}
