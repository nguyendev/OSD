using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Models;
using QuanLyNhaHang.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System;

namespace QuanLyNhaHang.Areas.QuanLyWebsite.Controllers
{
    public class ThuChiController : Controller
    {
        private readonly IGenericRepository<THUCHI> _context;

        public ThuChiController(IGenericRepository<THUCHI> context)
        {
            _context = context;    
        }

        private async Task<List<THUCHI>> GetResult(DateTime? ngaylap = null,
          string nguoilap = null)
        {
            IQueryable<THUCHI> result = _context.GetList().Where(c =>
           (ngaylap == null || DateTime.Compare(Convert.ToDateTime(c.NgayTao), ngaylap.Value) == 0)
           && (nguoilap == null || c.NguoiLap == nguoilap) && c.TrangThai == "1");
            return await result.ToListAsync();
        }
        // GET: ThuChi
        public async Task<IActionResult> Index(DateTime? ngaylap = null,
          string nguoilap = null)
        {
            return View(await GetResult(ngaylap, nguoilap));
        }

        // GET: ThuChi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thuchi = await _context.Get(id);
            if (thuchi == null)
            {
                return NotFound();
            }

            return View(thuchi);
        }

        // GET: ThuChi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ThuChi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(THUCHI thuchi)
        {
            if (ModelState.IsValid)
            {
                thuchi.NgayTao = DateTime.Now;
                thuchi.TrangThai = "1";
                thuchi.TrangThaiDuyet = "U";
                await _context.Add(thuchi);
                return RedirectToAction("Index");
            }
            return View(thuchi);
        }

        // GET: ThuChi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thuchi = await _context.Get(id);
            if (thuchi == null)
            {
                return NotFound();
            }
            return View(thuchi);
        }

        // POST: ThuChi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, THUCHI thuchi)
        {
            if (id != thuchi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    thuchi.TrangThaiDuyet = "U";
                    await _context.Update(thuchi);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThuChiExists(thuchi.Id))
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
            return View(thuchi);
        }

        private bool ThuChiExists(int id)
        {
            return _context.Exists(id);
        }

        // GET: ThuChi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thuchi = await _context.Get(id);
            if (thuchi == null)
            {
                return NotFound();
            }

            return View(thuchi);
        }

        // POST: ThuChi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var thuchi = await _context.Get(id);
            if (ModelState.IsValid)
            {
                if (thuchi.TrangThaiDuyet == "A")
                {
                    thuchi.TrangThai = "0";
                    thuchi.TrangThaiDuyet = "U";
                    await _context.Update(thuchi);
                }
                else
                    await _context.Delete(id);
            }
            return RedirectToAction("Index");
        }
    }
}
