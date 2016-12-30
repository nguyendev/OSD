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
    public class LuotKhachController : Controller
    {
        private readonly IGenericRepository<LUOTKHACH> _context;

        public LuotKhachController(IGenericRepository<LUOTKHACH> context)
        {
            _context = context;
        }

        private async Task<List<LUOTKHACH>> GetResult(string maluot = null,
           int? soban = null, string thoigianvao = null)
        {
            IQueryable<LUOTKHACH> result = _context.GetList().Where(c =>
          (maluot == null || c.MaLuot == maluot) && (soban == null || c.SoBan == soban.Value)
          && (thoigianvao == null || c.ThoiGianVao == thoigianvao) && c.TrangThai == "1");
            return await result.ToListAsync();
        }
        // GET: LuotKhach
        public async Task<IActionResult> Index(string maluot = null,
           int? soban = null, string thoigianvao = null)
        {
            return View(await GetResult(maluot, soban, thoigianvao));
        }

        // GET: LuotKhach/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var luotkhach = await _context.Get(id);
            if (luotkhach == null)
            {
                return NotFound();
            }

            return View(luotkhach);
        }

        // GET: LuotKhach/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LuotKhach/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LUOTKHACH luotkhach)
        {
            if (ModelState.IsValid)
            {
                luotkhach.NgayTao = DateTime.Now;
                luotkhach.TrangThai = "1";
                luotkhach.TrangThaiDuyet = "U";
                await _context.Add(luotkhach);
                return RedirectToAction("Index");
            }
            return View(luotkhach);
        }

        // GET: LuotKhach/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var luotkhach = await _context.Get(id);
            if (luotkhach == null)
            {
                return NotFound();
            }
            return View(luotkhach);
        }

        // POST: LuotKhach/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LUOTKHACH luotkhach)
        {
            if (id != luotkhach.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    luotkhach.TrangThaiDuyet = "U";
                    await _context.Update(luotkhach);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LuotKhachExists(luotkhach.Id))
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
            return View(luotkhach);
        }

        private bool LuotKhachExists(int id)
        {
            return _context.Exists(id);
        }

        // GET: LuotKhach/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var luotkhach = await _context.Get(id);
            if (luotkhach == null)
            {
                return NotFound();
            }

            return View(luotkhach);
        }

        // POST: LuotKhach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var luotkhach = await _context.Get(id);
            if (ModelState.IsValid)
            {
                if (luotkhach.TrangThaiDuyet == "A")
                {
                    luotkhach.TrangThai = "0";
                    luotkhach.TrangThaiDuyet = "U";
                    await _context.Update(luotkhach);
                }
                else
                    await _context.Delete(id);
            }
            return RedirectToAction("Index");
        }
    }
}
