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
    public class YeuCauMonAnController : Controller
    {
        private readonly IGenericRepository<YEUCAUMONAN> _context;

        public YeuCauMonAnController(IGenericRepository<YEUCAUMONAN> context)
        {
            _context = context;    
        }

        private async Task<List<YEUCAUMONAN>> GetResult(string maluot = null,
     string mamon = null)
        {
            IQueryable<YEUCAUMONAN> result = _context.GetList().Where(c =>
           (maluot == null || c.MaLuot == maluot) && (mamon == null || c.MaMon == mamon)
           && c.TrangThai == "1");
            return await result.ToListAsync();
        }
        // GET: YeuCauMonAn
        public async Task<IActionResult> Index(string maluot = null, string mamon = null)
        {
            return View(await GetResult(maluot, mamon));
        }

        // GET: YeuCauMonAn/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yeucaumonan = await _context.Get(id);
            if (yeucaumonan == null)
            {
                return NotFound();
            }

            return View(yeucaumonan);
        }

        // GET: YeuCauMonAn/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: YeuCauMonAn/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(YEUCAUMONAN yeucaumonan)
        {
            if (ModelState.IsValid)
            {
                yeucaumonan.NgayTao = DateTime.Now;
                yeucaumonan.TrangThai = "1";
                yeucaumonan.TrangThaiDuyet = "U";
                await _context.Add(yeucaumonan);
                return RedirectToAction("Index");
            }
            return View(yeucaumonan);
        }

        // GET: YeuCauMonAn/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yeucaumonan = await _context.Get(id);
            if (yeucaumonan == null)
            {
                return NotFound();
            }
            return View(yeucaumonan);
        }

        // POST: YeuCauMonAn/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, YEUCAUMONAN yeucaumonan)
        {
            if (id != yeucaumonan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    yeucaumonan.TrangThaiDuyet = "U";
                    await _context.Update(yeucaumonan);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YeuCauMonAnExists(yeucaumonan.Id))
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
            return View(yeucaumonan);
        }

        private bool YeuCauMonAnExists(int id)
        {
            return _context.Exists(id);
        }

        // GET: YeuCauMonAn/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yeucaumonan = await _context.Get(id);
            if (yeucaumonan == null)
            {
                return NotFound();
            }

            return View(yeucaumonan);
        }

        // POST: YeuCauMonAn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yeucaumonan = await _context.Get(id);
            if (ModelState.IsValid)
            {
                if (yeucaumonan.TrangThaiDuyet == "A")
                {
                    yeucaumonan.TrangThai = "0";
                    yeucaumonan.TrangThaiDuyet = "U";
                    await _context.Update(yeucaumonan);
                }
                else
                    await _context.Delete(id);
            }
            return RedirectToAction("Index");
        }
    }
}
