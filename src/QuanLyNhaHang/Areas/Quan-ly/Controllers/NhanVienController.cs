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
    [Area("quan-ly")]
    [Authorize]
    public class NhanVienController : Controller
    {
        private readonly IGenericRepository<NHANVIEN> _context;
        private readonly IGenericRepository<BOPHAN> _bophancontext;

        private SignInManager<AppUser> SignInManager;
        private UserManager<AppUser> UserManager;

        public NhanVienController(IGenericRepository<NHANVIEN> context,
            IGenericRepository<BOPHAN> bophancontext, UserManager<AppUser> userMgr,
        SignInManager<AppUser> signinMgr)
        {
            _context = context;
            _bophancontext = bophancontext;
            SignInManager = signinMgr;
            UserManager = userMgr;
        }

        private void AllViewBag()
        {
            var bophanlist = _bophancontext.GetList().Where(c => c.TrangThai == "1");
            ViewData["MaBP"] = new SelectList(bophanlist, "MaBP", "TenBP");
        }

        public async Task<IActionResult> GetResult(string manv = null,
      string tennv = null, string mabp = null)
        {
            var bophanlist = _bophancontext.GetList().Where(c => c.TrangThai == "1");
            ViewData["mabp"] = new SelectList(bophanlist, "MaBP", "TenBP", mabp);
            IQueryable<NHANVIEN> result = _context.GetList().Where(c =>
           (manv == null || c.MaNV == manv) && (tennv == null || c.TenNV == tennv)
           && (mabp == null || c.MaBP == mabp) && c.TrangThai == "1");
            return View(await result.ToListAsync());
        }
        // GET: NhanVien
        [Route("quan-ly/nhan-vien")]
        public async Task<IActionResult> Search(string manv = null,
      string tennv = null, string mabp = null)
        {
            List<SelectListItem> listTrangThaiDuyet = new List<SelectListItem>();
            listTrangThaiDuyet.Add(new SelectListItem { Text = "Đã duyệt", Value = "A" });
            listTrangThaiDuyet.Add(new SelectListItem { Text = "Chưa duyệt", Value = "U" });
            return await GetResult(manv,tennv, mabp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/nhan-vien")]
        public async Task<IActionResult> Search(int? id, string trangthaiduyet,
          string manv = null, string tennv = null, string mabp = null)
        {
            if (id == null)
            {
                return NotFound();
            }
            var nhanvien = await _context.Get(id);
            if (nhanvien == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.SetState(nhanvien, EntityState.Modified);
                await _context.Update(nhanvien, trangthaiduyet, "1", UserManager.GetUserId(User));
            }
            return await Search(manv, tennv, mabp);
        }
        // GET: NhanVien/Details/5
        [Route("quan-ly/nhan-vien/chi-tiet/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Get(id);
            if (nhanvien == null)
            {
                return NotFound();
            }
            AllViewBag();
            return View(nhanvien);
        }

        // GET: NhanVien/Create
        [Route("quan-ly/nhan-vien/tao-moi")]
        public IActionResult Create()
        {
            AllViewBag();
            return View();
        }

        // POST: NhanVien/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/nhan-vien/tao-moi")]
        public async Task<IActionResult> Create(NHANVIEN nhanvien)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(nhanvien, UserManager.GetUserId(User));
                return RedirectToAction("Index");
            }
            return View(nhanvien);
        }

        // GET: NhanVien/Edit/5
        [Route("quan-ly/nhan-vien/chinh-sua/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Get(id);
            if (nhanvien == null)
            {
                return NotFound();
            }
            AllViewBag();
            return View(nhanvien);
        }

        // POST: NhanVien/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/nhan-vien/chinh-sua/{id}")]
        public async Task<IActionResult> Edit(int id, NHANVIEN nhanvien)
        {
            if (id != nhanvien.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(nhanvien);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhanVienExists(nhanvien.Id))
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
            return View(nhanvien);
        }

        private bool NhanVienExists(int id)
        {
            return _context.Exists(id);
        }

        // GET: NhanVien/Delete/5
        [Route("quan-ly/nhan-vien/xoa/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Get(id);
            if (nhanvien == null)
            {
                return NotFound();
            }
            AllViewBag();
            return View(nhanvien);
        }

        // POST: NhanVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/nhan-vien/xoa/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nhanvien = await _context.Get(id);
            if (ModelState.IsValid)
            {
                if (nhanvien.TrangThaiDuyet == "A")
                    await _context.Update(nhanvien,"U","0");
                else
                    await _context.Delete(id);
            }
            return RedirectToAction("Index");
        }

    }
}
