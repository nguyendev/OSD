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
    public class MonAnController : Controller
    {
        private readonly IGenericRepository<MONAN> _context;

        public MonAnController(IGenericRepository<MONAN> context)
        {
            _context = context;
        }

        public async Task<List<MONAN>> GetResult(string mamon = null,
         string tenmon = null, string maloaimon = null)
        {
            IQueryable<MONAN> result = _context.GetList().Where(c =>
           (mamon == null || c.MaMon == mamon) && (tenmon == null || c.TenMon == tenmon)
           && (maloaimon == null || c.MaLoaiMon == mamon) && c.TrangThai == "1");
            return await result.ToListAsync();
        }
        // GET: MonAn
        public async Task<IActionResult> Index(string mamon = null,
         string tenmon = null, string maloaimon = null)
        {
            return View(await GetResult(mamon, tenmon, maloaimon));
        }

        // GET: MonAn/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monan = await _context.Get(id);
            if (monan == null)
            {
                return NotFound();
            }

            return View(monan);
        }

        // GET: MonAn/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MonAn/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MONAN monan)
        {
            if (ModelState.IsValid)
            {
                monan.NgayTao = DateTime.Now;
                monan.TrangThai = "1";
                monan.TrangThaiDuyet = "U";
                await _context.Add(monan);
                return RedirectToAction("Index");
            }
            return View(monan);
        }

        // GET: MonAn/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monan = await _context.Get(id);
            if (monan == null)
            {
                return NotFound();
            }
            return View(monan);
        }

        // POST: MonAn/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaMon,TenMon,MaLoaiMon,Gia")] MONAN monan)
        {
            if (id != monan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    monan.TrangThaiDuyet = "U";
                    await _context.Update(monan);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonAnExists(monan.Id))
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
            return View(monan);
        }

        private bool MonAnExists(int id)
        {
            return _context.Exists(id);
        }

        // GET: MonAn/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monan = await _context.Get(id);
            if (monan == null)
            {
                return NotFound();
            }

            return View(monan);
        }

        // POST: MonAn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var monan = await _context.Get(id);
            if (ModelState.IsValid)
            {
                if (monan.TrangThaiDuyet == "A")
                {
                    monan.TrangThai = "0";
                    monan.TrangThaiDuyet = "U";
                    await _context.Update(monan);
                }
                else
                    await _context.Delete(id);
            }
            return RedirectToAction("Index");
        }
    }
}
