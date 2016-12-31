using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Infrastructure;
using QuanLyNhaHang.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace QuanLyNhaHang.Areas.QuanLyWebsite.Controllers
{
    [Area("Quan-ly")]
    [Authorize]
    public class YeuCauMonAnController : Controller
    {
        private readonly IGenericRepository<YEUCAUMONAN> _context;
        private readonly IGenericRepository<MONAN> _monancontext;
        private readonly IGenericRepository<LUOTKHACH> _luotkhachcontext;

        private SignInManager<AppUser> SignInManager;
        private UserManager<AppUser> UserManager;

        public YeuCauMonAnController(IGenericRepository<YEUCAUMONAN> context,
            IGenericRepository<MONAN> monancontext, IGenericRepository<LUOTKHACH> luotkhachcontext)
        {
            _context = context;
            _monancontext = monancontext;
            _luotkhachcontext = luotkhachcontext;  
        }

        private async Task<IActionResult> GetResult(string maluot = null,
     string mamon = null)
        {
            var monanlist = _monancontext.GetList().Where(c => c.TrangThai == "1");
            ViewData["MaMon"] = new SelectList(monanlist, "MaMon", "TenMon", mamon);
            var nguoilaplist = _luotkhachcontext.GetList().Where(c => c.TrangThai == "1");
            ViewData["MaLuot"] = new SelectList(nguoilaplist, "MaLuot", "MaLuot", maluot);
            IQueryable<YEUCAUMONAN> result = _context.GetList().Where(c =>
           (maluot == null || c.MaLuot == maluot) && (mamon == null || c.MaMon == mamon)
           && c.TrangThai == "1");
            return View(await result.ToListAsync());
        }
        // GET: YeuCauMonAn
        public async Task<IActionResult> Index(string maluot = null, string mamon = null)
        {
            return await GetResult(maluot, mamon);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(int? id, string trangthaiduyet,
        string maluot = null, string mamon = null)
        {
            if (id == null)
                return NotFound();
            var yeucau = await _context.Get(id);
            if (yeucau == null)
                return NotFound();
            if (ModelState.IsValid)
            {
                _context.SetState(yeucau, EntityState.Modified);
                await _context.Update(yeucau, trangthaiduyet, "1", UserManager.GetUserId(User));
            }
            return await GetResult(maluot, mamon);
        }
        // GET: YeuCauMonAn/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();
            var yeucaumonan = await _context.Get(id);
            if (yeucaumonan == null)
                return NotFound();
            return View(yeucaumonan);
        }

        // GET: YeuCauMonAn/Create
        public IActionResult Create()
        {
            var monanlist = _monancontext.GetList().Where(c => c.TrangThai == "1");
            ViewData["MaMon"] = new SelectList(monanlist, "MaMon", "TenMon");
            var nguoilaplist = _luotkhachcontext.GetList().Where(c => c.TrangThai == "1");
            ViewData["MaLuot"] = new SelectList(nguoilaplist, "MaLuot", "MaLuot");
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
                await _context.Add(yeucaumonan, UserManager.GetUserId(User));
                return RedirectToAction("Index");
            }
            return View(yeucaumonan);
        }

        // GET: YeuCauMonAn/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var yeucaumonan = await _context.Get(id);
            if (yeucaumonan == null)
                return NotFound();
            var monanlist = _monancontext.GetList().Where(c => c.TrangThai == "1");
            ViewData["MaMon"] = new SelectList(monanlist, "MaMon", "TenMon");
            var nguoilaplist = _luotkhachcontext.GetList().Where(c => c.TrangThai == "1");
            ViewData["MaLuot"] = new SelectList(nguoilaplist, "MaLuot", "MaLuot");
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
                return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(yeucaumonan);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YeuCauMonAnExists(yeucaumonan.Id))
                        return NotFound();
                    else
                        throw;
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
                return NotFound();
            var yeucaumonan = await _context.Get(id);
            if (yeucaumonan == null)
                return NotFound();
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
                    await _context.Update(yeucaumonan,"U","0");
                else
                    await _context.Delete(id);
            }
            return RedirectToAction("Index");
        }
    }
}
