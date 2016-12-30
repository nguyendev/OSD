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
    [Area("Quanly")]

    public class LoaiMonAnController : Controller
    {
        private readonly IGenericRepository<LOAIMONAN> _context;

        public LoaiMonAnController(IGenericRepository<LOAIMONAN> context)
        {
            _context = context;    
        }

        //search
        private async Task<List<LOAIMONAN>> GetResult(string maloaimon = null,
            string tenloaimon = null)
        {
            IQueryable<LOAIMONAN> result = _context.GetList().Where(c =>
           (maloaimon == null || c.MaLoaiMon == maloaimon) && (tenloaimon == null || c.TenLoaiMon == tenloaimon)
            && c.TrangThai == "1");
            return await result.ToListAsync();
        }
        // GET: LoaiMonAn
        public async Task<IActionResult> Index(string maloaimon = null,
            string tenloaimon = null)
        {
            return View(await GetResult(maloaimon, tenloaimon));
        }

        // GET: LoaiMonAn/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaimonan = await _context.Get(id);
            if (loaimonan == null)
            {
                return NotFound();
            }

            return View(loaimonan);
        }

        // GET: LoaiMonAn/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LoaiMonAn/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LOAIMONAN loaimonan)
        {
            if (ModelState.IsValid)
            {
                loaimonan.NgayTao = DateTime.Now;
                loaimonan.TrangThai = "1";
                loaimonan.TrangThaiDuyet = "U";
                await _context.Add(loaimonan);
                return RedirectToAction("Index");
            }
            return View(loaimonan);
        }

        // GET: LoaiMonAn/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaimonan = await _context.Get(id);
            if (loaimonan == null)
            {
                return NotFound();
            }
            return View(loaimonan);
        }

        // POST: LoaiMonAn/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LOAIMONAN loaimonan)
        {
            if (id != loaimonan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    loaimonan.TrangThaiDuyet = "U";
                    await _context.Update(loaimonan);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiMonAnExists(loaimonan.Id))
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
            return View(loaimonan);
        }

        private bool LoaiMonAnExists(int id)
        {
            return _context.Exists(id);
        }

        // GET: LoaiMonAn/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaimonan = await _context.Get(id);
            if (loaimonan == null)
            {
                return NotFound();
            }

            return View(loaimonan);
        }

        // POST: LoaiMonAn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loaimon = await _context.Get(id);
            if (ModelState.IsValid)
            {
                if (loaimon.TrangThaiDuyet == "A")
                {
                    loaimon.TrangThai = "0";
                    loaimon.TrangThaiDuyet = "U";
                    await _context.Update(loaimon);
                }
                else
                    await _context.Delete(id);
            }
            return RedirectToAction("Index");
        }
    }
}
