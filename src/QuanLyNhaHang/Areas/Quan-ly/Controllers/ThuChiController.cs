using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Models;
using QuanLyNhaHang.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace QuanLyNhaHang.Areas.QuanLyWebsite.Controllers
{
    public class ThuChiController : Controller
    {
        private readonly IGenericRepository<THUCHI> _context;
        private readonly IGenericRepository<NHANVIEN> _nhanviencontext;

        private SignInManager<AppUser> SignInManager;
        private UserManager<AppUser> UserManager;

        public ThuChiController(IGenericRepository<THUCHI> context,
            IGenericRepository<NHANVIEN> nhanviencontext)
        {
            _context = context;
            _nhanviencontext = nhanviencontext;
        }

        private async Task<IActionResult> GetResult(DateTime? ngaylap = null,
          string nguoilap = null)
        {
            var nguoilaplist = _nhanviencontext.GetList().Where(c => c.TrangThai == "1");
            ViewData["NguoiLap"] = new SelectList(nguoilaplist, "MaNV", "MaNV", nguoilap);
            IQueryable<THUCHI> result = _context.GetList().Where(c =>
           (ngaylap == null || DateTime.Compare(Convert.ToDateTime(c.NgayTao), ngaylap.Value) == 0)
           && (nguoilap == null || c.NguoiLap == nguoilap) && c.TrangThai == "1");
            return View(await result.ToListAsync());
        }
        // GET: ThuChi
        public async Task<IActionResult> Index(DateTime? ngaylap = null,
          string nguoilap = null)
        {
            return await GetResult(ngaylap, nguoilap);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(int? id, string trangthaiduyet,
DateTime? ngaylap = null, string nguoilap = null)
        {
            if (id == null)
                return NotFound();
            var thuchi = await _context.Get(id);
            if (thuchi == null)
                return NotFound();
            if (ModelState.IsValid)
            {
                _context.SetState(thuchi, EntityState.Modified);
                await _context.Update(thuchi, trangthaiduyet, "1", UserManager.GetUserId(User));
            }
            return await GetResult(ngaylap, nguoilap);
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
            var nguoilaplist = _nhanviencontext.GetList().Where(c => c.TrangThai == "1");
            ViewData["NguoiLap"] = new SelectList(nguoilaplist, "MaNV", "MaNV");
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
                await _context.Add(thuchi, UserManager.GetUserId(User));
                return RedirectToAction("Index");
            }
            return View(thuchi);
        }

        // GET: ThuChi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var thuchi = await _context.Get(id);
            if (thuchi == null)
                return NotFound();
            var nguoilaplist = _nhanviencontext.GetList().Where(c => c.TrangThai == "1");
            ViewData["NguoiLap"] = new SelectList(nguoilaplist, "MaNV", "MaNV");
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
                return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(thuchi);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThuChiExists(thuchi.Id))
                        return NotFound();
                    else
                        throw;
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
                return NotFound();
            var thuchi = await _context.Get(id);
            if (thuchi == null)
                return NotFound();
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
                    await _context.Update(thuchi,"U","0");
                else
                    await _context.Delete(id);
            }
            return RedirectToAction("Index");
        }
    }
}
