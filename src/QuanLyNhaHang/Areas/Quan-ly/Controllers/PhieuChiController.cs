using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Models;
using QuanLyNhaHang.Infrastructure;
using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace QuanLyNhaHang.Areas.QuanLyWebsite.Controllers
{
    [Area("Quan-ly")]
    [Authorize]
    public class PhieuChiController : Controller
    {
        private readonly IGenericRepository<PHIEUCHI> _context;
        private readonly IGenericRepository<HOADONNHAPHANG> _hoadoncontext;
        private readonly IGenericRepository<NHANVIEN> _nhanviencontext;
        private SignInManager<AppUser> SignInManager;
        private UserManager<AppUser> UserManager;

        public PhieuChiController(IGenericRepository<PHIEUCHI> context,
            IGenericRepository<HOADONNHAPHANG> hoadoncontext,
            IGenericRepository<NHANVIEN> nhanviencontext)
        {
            _context = context;
            _hoadoncontext = hoadoncontext;
            _nhanviencontext = nhanviencontext;
        }

        private async Task<IActionResult> GetResult(string mapc = null, string mahd = null, DateTime? ngaylap = null,
            string nguoilap = null)
        {
            var hoadonlist = _hoadoncontext.GetList().Where(c => c.TrangThai == "1");
            ViewData["MaHD"] = new SelectList(hoadonlist, "MaHD", "MaHD", mahd);
            var nguoilaplist = _nhanviencontext.GetList().Where(c => c.TrangThai == "1");
            ViewData["NguoiLap"] = new SelectList(nguoilaplist, "MaNV", "MaNV", nguoilap);
            IQueryable<PHIEUCHI> result = _context.GetList().Where(c =>
           (mapc == null || c.MaPC == mapc) && (mahd == null || c.MaHD == mahd)
           && (ngaylap == null || DateTime.Compare(Convert.ToDateTime(c.NgayTao) , ngaylap.Value) == 0) 
           && (nguoilap == null || c.NguoiLap == nguoilap) && c.TrangThai == "1");
            return View(await result.ToListAsync());
        }
        // GET: PhieuChi
        public async Task<IActionResult> Index(string mapc = null, string mahd = null, DateTime? ngaylap = null,
            string nguoilap = null)
        {
            return await GetResult(mapc, mahd, ngaylap, nguoilap);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(int? id, string trangthaiduyet,
  string mapc = null, string mahd = null, DateTime? ngaylap = null,
            string nguoilap = null)
        {
            if (id == null)
                return NotFound();
            var phieuchi = await _context.Get(id);
            if (phieuchi == null)
                return NotFound();
            if (ModelState.IsValid)
            {
                _context.SetState(phieuchi, EntityState.Modified);
                await _context.Update(phieuchi, trangthaiduyet, "1", UserManager.GetUserId(User));
            }
            return await GetResult(mapc, mahd, ngaylap, nguoilap);
        }
        // GET: PhieuChi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();
            var phieuchi = await _context.Get(id);
            if (phieuchi == null)
                return NotFound();
            return View(phieuchi);
        }

        // GET: PhieuChi/Create
        public IActionResult Create()
        {
            var hoadonlist = _hoadoncontext.GetList().Where(c => c.TrangThai == "1");
            ViewData["MaHD"] = new SelectList(hoadonlist, "MaHD", "MaHD");
            var nguoilaplist = _nhanviencontext.GetList().Where(c => c.TrangThai == "1");
            ViewData["NguoiLap"] = new SelectList(nguoilaplist, "MaNV", "MaNV");
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
                await _context.Add(phieuchi, UserManager.GetUserId(User));
                return RedirectToAction("Index");
            }
            return View(phieuchi);
        }

        // GET: PhieuChi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var phieuchi = await _context.Get(id);
            if (phieuchi == null)
                return NotFound();
            var hoadonlist = _hoadoncontext.GetList().Where(c => c.TrangThai == "1");
            ViewData["MaHD"] = new SelectList(hoadonlist, "MaHD", "MaHD");
            var nguoilaplist = _nhanviencontext.GetList().Where(c => c.TrangThai == "1");
            ViewData["NguoiLap"] = new SelectList(nguoilaplist, "MaNV", "MaNV");
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
                return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(phieuchi);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhieuChiExists(phieuchi.Id))
                        return NotFound();
                    else
                        throw;
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
                return NotFound();
            var phieuchi = await _context.Get(id);
            if (phieuchi == null)
                return NotFound();
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
                    await _context.Update(phieuchi,"U","0");
                else
                    await _context.Delete(id);
            }
            return RedirectToAction("Index");
        }
    }
}
