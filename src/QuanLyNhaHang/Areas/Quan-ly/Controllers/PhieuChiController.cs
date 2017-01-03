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
using System.Collections.Generic;

namespace QuanLyNhaHang.Areas.QuanLyWebsite.Controllers
{
    [Area("quan-ly")]
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
            IGenericRepository<NHANVIEN> nhanviencontext, UserManager<AppUser> userMgr,
        SignInManager<AppUser> signinMgr)
        {
            _context = context;
            _hoadoncontext = hoadoncontext;
            _nhanviencontext = nhanviencontext;
            SignInManager = signinMgr;
            UserManager = userMgr;
        }

        private void AllViewBag()
        {
            var hoadonlist = _hoadoncontext.GetList().Where(c => c.TrangThai == "1");
            ViewData["MaHD"] = new SelectList(hoadonlist, "MaHD", "MaHD");
            var nguoilaplist = _nhanviencontext.GetList().Where(c => c.TrangThai == "1");
            ViewData["NguoiLap"] = new SelectList(nguoilaplist, "MaNV", "MaNV");

        }

        private async Task<IActionResult> GetResult(string mapc = null, string mahd = null, string ngaylap = null,
            string nguoilap = null)
        {
            var hoadonlist = _hoadoncontext.GetList().Where(c => c.TrangThai == "1");
            ViewData["mahd"] = new SelectList(hoadonlist, "MaHD", "MaHD", mahd);
            var nguoilaplist = _nhanviencontext.GetList().Where(c => c.TrangThai == "1");
            ViewData["nguoilap"] = new SelectList(nguoilaplist, "MaNV", "MaNV", nguoilap);
            IQueryable<PHIEUCHI> result = _context.GetList().Where(c =>
           (mapc == null || c.MaPC == mapc) && (mahd == null || c.MaHD == mahd)
           && (ngaylap == null || DateTime.Compare(Convert.ToDateTime(c.NgayTao) , Convert.ToDateTime(ngaylap)) == 0) 
           && (nguoilap == null || c.NguoiLap == nguoilap) && c.TrangThai == "1");
            return View(await result.ToListAsync());
        }
        // GET: PhieuChi
        [Route("quan-ly/phieu-chi")]
        public async Task<IActionResult> Search(string mapc = null, string mahd = null, string ngaylap = null,
            string nguoilap = null)
        {
            List<SelectListItem> listTrangThaiDuyet = new List<SelectListItem>();
            listTrangThaiDuyet.Add(new SelectListItem { Text = "Đã duyệt", Value = "A" });
            listTrangThaiDuyet.Add(new SelectListItem { Text = "Chưa duyệt", Value = "U" });
            return await GetResult(mapc, mahd, ngaylap, nguoilap);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/phieu-chi")]
        public async Task<IActionResult> Search(int? id, string trangthaiduyet,
  string mapc = null, string mahd = null, string ngaylap = null,
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
            return await Search(mapc, mahd, ngaylap, nguoilap);
        }
        // GET: PhieuChi/Details/5
        [Route("quan-ly/phieu-chi/chi-tiet/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();
            var phieuchi = await _context.Get(id);
            if (phieuchi == null)
                return NotFound();
            AllViewBag();
            return View(phieuchi);
        }

        // GET: PhieuChi/Create
        [Route("quan-ly/phieu-chi/tao-moi")]
        public IActionResult Create()
        {
            AllViewBag();
            return View();
        }

        // POST: PhieuChi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/phieu-chi/tao-moi")]
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
        [Route("quan-ly/phieu-chi/chinh-sua/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var phieuchi = await _context.Get(id);
            if (phieuchi == null)
                return NotFound();
            AllViewBag();
            return View(phieuchi);
        }

        // POST: PhieuChi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/phieu-chi/chinh-sua/{id}")]
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
        [Route("quan-ly/phieu-chi/xoa/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var phieuchi = await _context.Get(id);
            if (phieuchi == null)
                return NotFound();
            AllViewBag();
            return View(phieuchi);
        }

        // POST: PhieuChi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/phieu-chi/xoa/{id}")]
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
