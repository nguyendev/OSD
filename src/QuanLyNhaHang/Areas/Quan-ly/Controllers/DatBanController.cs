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
    public class DatBanController : Controller
    {
        private readonly IGenericRepository<DATBAN> _context;

        public DatBanController(IGenericRepository<DATBAN> context)
        {
            _context = context;    
        }

        private async Task<List<DATBAN>> GetResult(string ngay = null,
            string gio = null, string sodt = null)
        {
            IQueryable<DATBAN> result = _context.GetList().Where(c =>
            (gio == null || c.Gio == gio) && (ngay == null || c.Ngay == ngay)
            && (sodt == null || c.SoDT == sodt) && c.TrangThai == "1");
            return await result.ToListAsync();

        }

        // GET: DatBan
        public async Task<IActionResult> Index(string ngay = null,
            string gio = null, string sodt = null)
        {
            return View(await GetResult(ngay, gio, sodt));
        }

        // GET: DatBan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datban = await _context.Get(id);
            if (datban == null)
            {
                return NotFound();
            }

            return View(datban);
        }

        // GET: DatBan/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DatBan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DATBAN datban)
        {
            if (ModelState.IsValid)
            {
                datban.NgayTao = DateTime.Now;
                datban.TrangThai = "1";
                datban.TrangThaiDuyet = "U";
                await _context.Add(datban);
                return RedirectToAction("Index");
            }
            return View(datban);
        }

        // GET: DatBan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datban = await _context.Get(id);
            if (datban == null)
            {
                return NotFound();
            }
            return View(datban);
        }

        // POST: DatBan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DATBAN datban)
        {
            if (id != datban.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    datban.TrangThaiDuyet = "U";
                    await _context.Update(datban);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DatBanExists(datban.Id))
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
            return View(datban);
        }

        private bool DatBanExists(int id)
        {
            return _context.Exists(id);
        }

        // GET: DatBan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datban = await _context.Get(id);
            if (datban == null)
            {
                return NotFound();
            }

            return View(datban);
        }

        // POST: DatBan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var datban = await _context.Get(id);
            if (ModelState.IsValid)
            {
                if (datban.TrangThaiDuyet == "A")
                {
                    datban.TrangThai = "0";
                    datban.TrangThaiDuyet = "U";
                    await _context.Update(datban);
                }
                else
                    await _context.Delete(id);
            }
            return RedirectToAction("Index");
        }
    }
}
