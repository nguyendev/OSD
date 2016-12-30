using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Models;
using QuanLyNhaHang.Infrastructure;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace QuanLyNhaHang.Areas.QuanLyWebsite.Controllers
{
    [Area("Quan-ly")]
    [Authorize]
    public class PhieuChiController : Controller
    {
        private readonly IGenericRepository<PHIEUCHI> _context;

        public PhieuChiController(IGenericRepository<PHIEUCHI> context)
        {
            _context = context;    
        }

        private async Task<List<PHIEUCHI>> GetResult(string mapc = null, string mahd = null, DateTime? ngaylap = null,
            string nguoilap = null)
        {
            IQueryable<PHIEUCHI> result = _context.GetList().Where(c =>
           (mapc == null || c.MaPC == mapc) && (mahd == null || c.MaHD == mahd)
           && (ngaylap == null || DateTime.Compare(Convert.ToDateTime(c.NgayTao) , ngaylap.Value) == 0) 
           && (nguoilap == null || c.NguoiLap == nguoilap) && c.TrangThai == "1");
            return await result.ToListAsync();
        }
        // GET: PhieuChi
        public async Task<IActionResult> Index(string mapc = null, string mahd = null, DateTime? ngaylap = null,
            string nguoilap = null)
        {
            return View(await GetResult(mapc, mahd, ngaylap, nguoilap));
        }

        // GET: PhieuChi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieuchi = await _context.Get(id);
            if (phieuchi == null)
            {
                return NotFound();
            }

            return View(phieuchi);
        }

        // GET: PhieuChi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PhieuChi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PHIEUCHI phieuchi)
        {
            if (ModelState.IsValid)
            {
                phieuchi.NgayTao = DateTime.Now;
                phieuchi.TrangThai = "1";
                phieuchi.TrangThaiDuyet = "U";
                await _context.Add(phieuchi);
                return RedirectToAction("Index");
            }
            return View(phieuchi);
        }

        // GET: PhieuChi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieuchi = await _context.Get(id);
            if (phieuchi == null)
            {
                return NotFound();
            }
            return View(phieuchi);
        }

        // POST: PhieuChi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PHIEUCHI phieuchi)
        {
            if (id != phieuchi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    phieuchi.TrangThaiDuyet = "U";
                    await _context.Update(phieuchi);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhieuChiExists(phieuchi.Id))
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
            return View(phieuchi);
        }

        private bool PhieuChiExists(int id)
        {
            return _context.Exists(id);
        }

        // GET: PhieuChi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieuchi = await _context.Get(id);
            if (phieuchi == null)
            {
                return NotFound();
            }

            return View(phieuchi);
        }

        // POST: PhieuChi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phieuchi = await _context.Get(id);
            if (ModelState.IsValid)
            {
                if (phieuchi.TrangThaiDuyet == "A")
                {
                    phieuchi.TrangThai = "0";
                    phieuchi.TrangThaiDuyet = "U";
                    await _context.Update(phieuchi);
                }
                else
                    await _context.Delete(id);
            }
            return RedirectToAction("Index");
        }
    }
}
