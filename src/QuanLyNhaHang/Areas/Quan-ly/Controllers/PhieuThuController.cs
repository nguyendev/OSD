using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Models;
using QuanLyNhaHang.Infrastructure;
using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace QuanLyNhaHang.Areas.QuanLyWebsite.Controllers
{
    public class PhieuThuController : Controller
    {
        private readonly IGenericRepository<PHIEUTHU> _context;
        private readonly IGenericRepository<LUOTKHACH> _luotkhachcontext;
        private readonly IGenericRepository<NHANVIEN> _nhanviencontext;
        private SignInManager<AppUser> SignInManager;
        private UserManager<AppUser> UserManager;

        public PhieuThuController(IGenericRepository<PHIEUTHU> context,
            IGenericRepository<LUOTKHACH> luotkhachcontext,
            IGenericRepository<NHANVIEN> nhanviencontext, UserManager<AppUser> userMgr,
        SignInManager<AppUser> signinMgr)
        {
            _context = context;
            _luotkhachcontext = luotkhachcontext;
            _nhanviencontext = nhanviencontext;
            SignInManager = signinMgr;
            UserManager = userMgr;
        }

        private void AllViewBag()
        {
            var luotkhachlist = _luotkhachcontext.GetList().Where(c => c.TrangThai == "1");
            ViewData["MaLuot"] = new SelectList(luotkhachlist, "MaLuot", "MaLuot");
            var nguoilaplist = _nhanviencontext.GetList().Where(c => c.TrangThai == "1");
            ViewData["NguoiLap"] = new SelectList(nguoilaplist, "MaNV", "MaNV");
        }

        private async Task<IActionResult> GetResult(string mapt = null, string maluot = null, string ngaylap = null,
           string nguoilap = null)
        {
            var luotkhachlist = _luotkhachcontext.GetList().Where(c => c.TrangThai == "1");
            ViewData["maluot"] = new SelectList(luotkhachlist, "MaLuot", "MaLuot", maluot);
            var nguoilaplist = _nhanviencontext.GetList().Where(c => c.TrangThai == "1");
            ViewData["nguoilap"] = new SelectList(nguoilaplist, "MaNV", "MaNV", nguoilap);
            IQueryable<PHIEUTHU> result = _context.GetList().Where(c =>
           (mapt == null || c.MaPT == mapt) && (maluot == null || c.MaLuot == maluot)
           && (ngaylap == null || DateTime.Compare(Convert.ToDateTime(c.NgayTao), Convert.ToDateTime(ngaylap)) == 0)
           && (nguoilap == null || c.NguoiLap == nguoilap) && c.TrangThai == "1");
            return View(await result.ToListAsync());
        }
        // GET: PhieuThu
        [Route("quan-ly/phieu-thu")]
        public async Task<IActionResult> Search(string mapt = null, string maluot = null, string ngaylap = null,
           string nguoilap = null)
        {
            List<SelectListItem> listTrangThaiDuyet = new List<SelectListItem>();
            listTrangThaiDuyet.Add(new SelectListItem { Text = "Đã duyệt", Value = "A" });
            listTrangThaiDuyet.Add(new SelectListItem { Text = "Chưa duyệt", Value = "U" });
            return await GetResult(mapt,maluot,ngaylap,nguoilap);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/phieu-thu")]
        public async Task<IActionResult> Search(int? id, string trangthaiduyet,
            string mapt = null, string maluot = null, string ngaylap = null,
           string nguoilap = null)
        {
            if (id == null)
                return NotFound();
            var phieuthu = await _context.Get(id);
            if (phieuthu == null)
                return NotFound();
            if (ModelState.IsValid)
            {
                _context.SetState(phieuthu, EntityState.Modified);
                await _context.Update(phieuthu, trangthaiduyet, "1", UserManager.GetUserId(User));
            }
            return await Search(mapt, maluot, ngaylap, nguoilap);
        }
        // GET: PhieuThu/Details/5
        [Route("quan-ly/phieu-thu/chi-tiet/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();
            var phieuthu = await _context.Get(id);
            if (phieuthu == null)
                return NotFound();
            AllViewBag();
            return View(phieuthu);
        }

        // GET: PhieuThu/Create
        [Route("quan-ly/phieu-thu/tao-moi")]
        public IActionResult Create()
        {
            AllViewBag();
            return View();
        }

        // POST: PhieuThu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/phieu-thu/tao-moi")]
        public async Task<IActionResult> Create(PHIEUTHU phieuthu)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(phieuthu, UserManager.GetUserId(User));
                return RedirectToAction("Search");
            }
            return View(phieuthu);
        }

        // GET: PhieuThu/Edit/5
        [Route("quan-ly/phieu-thu/chinh-sua/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var phieuthu = await _context.Get(id);
            if (phieuthu == null)
                return NotFound();
            AllViewBag();
            return View(phieuthu);
        }

        // POST: PhieuThu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/phieu-thu/chinh-sua/{id}")]
        public async Task<IActionResult> Edit(int id, PHIEUTHU phieuthu)
        {
            if (id != phieuthu.Id)
                return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(phieuthu);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhieuThuExists(phieuthu.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction("Search");
            }
            return View(phieuthu);
        }

        private bool PhieuThuExists(int id)
        {
            return _context.Exists(id);
        }

        // GET: PhieuThu/Delete/5
        [Route("quan-ly/phieu-thu/xoa/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var phieuthu = await _context.Get(id);
            if (phieuthu == null)
                return NotFound();
            AllViewBag();
            return View(phieuthu);
        }

        // POST: PhieuThu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/phieu-thu/xoa/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phieuthu = await _context.Get(id);
            if (ModelState.IsValid)
            {
                if (phieuthu.TrangThaiDuyet == "A")
                    await _context.Update(phieuthu,"U","0");
                else
                    await _context.Delete(id);
            }
            return RedirectToAction("Search");
        }
    }
}
