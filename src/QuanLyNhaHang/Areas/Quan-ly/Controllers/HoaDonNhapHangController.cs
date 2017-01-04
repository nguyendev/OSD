using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Infrastructure;
using QuanLyNhaHang.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace QuanLyNhaHang.Areas.QuanLyWebsite.Controllers
{
    [Area("quan-ly")]
    [Authorize]
    public class HoaDonNhapHangController : Controller
    {
        private readonly IGenericRepository<HOADONNHAPHANG> _context;
        private readonly IGenericRepository<NHANVIEN> _nhanviencontext;
        private readonly IGenericRepository<YEUCAUNHAPHANG> _yeucaunhaphangcontext;
        private SignInManager<AppUser> SignInManager;
        private UserManager<AppUser> UserManager;

        public HoaDonNhapHangController(IGenericRepository<HOADONNHAPHANG> context,
            IGenericRepository<NHANVIEN> nhanviencontext,
            IGenericRepository<YEUCAUNHAPHANG> yeucaunhaphangcontext,
            UserManager<AppUser> userMgr,
        SignInManager<AppUser> signinMgr)
        {
            _context = context;
            _nhanviencontext = nhanviencontext;
            _yeucaunhaphangcontext = yeucaunhaphangcontext;
            SignInManager = signinMgr;
            UserManager = userMgr;
        }
        
        private void AllViewBag()
        {
            List<SelectListItem> listTrangThaiDuyet = new List<SelectListItem>();
            listTrangThaiDuyet.Add(new SelectListItem { Text = "Đã duyệt", Value = "A" });
            listTrangThaiDuyet.Add(new SelectListItem { Text = "Chưa duyệt", Value = "U" });
            ViewData["TrangThaiDuyet"] = listTrangThaiDuyet;
            var yeucaunhaphanglist = _yeucaunhaphangcontext.GetList().Where(c => c.TrangThai == "1" && c.TrangThaiDuyet == "A");
            var nhanvienlist = _nhanviencontext.GetList().Where(c => c.TrangThai == "1" && c.TrangThaiDuyet == "A");
            ViewData["MaNV"] = new SelectList(nhanvienlist, "MaNV", "TenNV");
            ViewData["MaYC"] = new SelectList(yeucaunhaphanglist, "MaYeuCau", "MaYeuCau");
            ViewData["MaNCC"] = new SelectList(yeucaunhaphanglist, "MaNCC", "MaNCC");
        }

        private async Task<IActionResult> GetResult(string mahd = null,
            string manv = null, string ngaylap = null, string mayc = null)
        {
            var yeucaunhaphanglist = _yeucaunhaphangcontext.GetList().Where(c => c.TrangThai == "1" && c.TrangThaiDuyet == "A");
            var nhanvienlist = _nhanviencontext.GetList().Where(c => c.TrangThai == "1" && c.TrangThaiDuyet == "A");
            ViewData["manv"] = new SelectList(nhanvienlist, "MaNV", "MaNV", manv);
            ViewData["mayc"] = new SelectList(yeucaunhaphanglist, "MaYeuCau", "MaYeuCau", mayc);
            IQueryable<HOADONNHAPHANG> result = _context.GetList().Where(c =>
          (mahd == null || c.MaHD == mahd) && (manv == null || c.MaNV == manv)
          && (mahd == null || c.MaHD == mahd) && (ngaylap == null || Convert.ToDateTime(ngaylap).Date 
          == Convert.ToDateTime(c.ThoiGianNhap).Date)
          && c.TrangThai == "1");
            return View(await result.ToListAsync());
        }
        // GET: HoaDonNhapHang
        [Route("quan-ly/hoa-don-nhap-hang")]
        public async Task<IActionResult> Search(string mahd = null,
            string manv = null, string ngaylap = null, string mayc = null)
        {
            List<SelectListItem> listTrangThaiDuyet = new List<SelectListItem>();
            listTrangThaiDuyet.Add(new SelectListItem { Text = "Đã duyệt", Value = "A" });
            listTrangThaiDuyet.Add(new SelectListItem { Text = "Chưa duyệt", Value = "U" });
            ViewData["TrangThaiDuyet"] = listTrangThaiDuyet;

            return await GetResult(mahd, manv, ngaylap, mayc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/hoa-don-nhap-hang")]
        public async Task<IActionResult> Search(int? id, string trangthaiduyet, string mahd = null,
            string manv = null, string ngaylap = null, string mayc = null)
        {
            if (id == null)
            {
                return NotFound();
            }
            var hoadon = await _context.Get(id);
            if (hoadon == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.SetState(hoadon, EntityState.Modified);
                await _context.Update(hoadon, trangthaiduyet, "1", UserManager.GetUserId(User));
            }
            return await Search(mahd, manv, ngaylap, mayc);
        }

        // GET: HoaDonNhapHang/Details/5
        [Route("quan-ly/hoa-don-nhap-hang/chi-tiet/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoadonnhaphang = await _context.Get(id);
            if (hoadonnhaphang == null)
            {
                return NotFound();
            }
            AllViewBag();
            return View(hoadonnhaphang);
        }

        // GET: HoaDonNhapHang/Create
        [Route("quan-ly/hoa-don-nhap-hang/tao-moi")]
        public IActionResult Create()
        {
            AllViewBag();
            return View();
        }

        // POST: HoaDonNhapHang/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/hoa-don-nhap-hang/tao-moi")]
        public async Task<IActionResult> Create(HOADONNHAPHANG hoadonnhaphang)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(hoadonnhaphang, UserManager.GetUserId(User));
                return RedirectToAction("Search");
            }
            return View(hoadonnhaphang);
        }

        // GET: HoaDonNhapHang/Edit/5
        [Route("quan-ly/hoa-don-nhap-hang/chinh-sua/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoadonnhaphang = await _context.Get(id);
            if (hoadonnhaphang == null)
            {
                return NotFound();
            }
            AllViewBag();
            return View(hoadonnhaphang);
        }

        // POST: HoaDonNhapHang/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/hoa-don-nhap-hang/chinh-sua/{id}")]
        public async Task<IActionResult> Edit(int id, HOADONNHAPHANG hoadonnhaphang)
        {
            if (id != hoadonnhaphang.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(hoadonnhaphang);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoaDonNhapHangExists(hoadonnhaphang.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Search");
            }
            return View(hoadonnhaphang);
        }

        private bool HoaDonNhapHangExists(int id)
        {
            return _context.Exists(id);
        }

        // GET: HoaDonNhapHang/Delete/5
        [Route("quan-ly/hoa-don-nhap-hang/xoa/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoadonnhaphang = await _context.Get(id);
            if (hoadonnhaphang == null)
            {
                return NotFound();
            }
            AllViewBag();
            return View(hoadonnhaphang);
        }

        // POST: HoaDonNhapHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/hoa-don-nhap-hang/xoa/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hoadon = await _context.Get(id);
            if (ModelState.IsValid)
            {
                if (hoadon.TrangThaiDuyet == "A")
                {
                    await _context.Update(hoadon, "U", "0");
                }
                else
                    await _context.Delete(id);
            }
            return RedirectToAction("Search");
        }
    }
}
