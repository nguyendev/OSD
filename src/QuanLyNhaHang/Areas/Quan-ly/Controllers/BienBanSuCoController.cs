using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Models;
using QuanLyNhaHang.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace QuanLyNhaHang.Areas.Quanly.Controllers
{
    [Area("quan-ly")]
    [Authorize]
    public class BienBanSuCoController : Controller
    {
        private readonly IGenericRepository<BIENBANSUCO> _context;
        private readonly IGenericRepository<LOAISUCO> _loaisucocontext;
        private readonly IGenericRepository<NHANVIEN> _nhanviencontext;

        private SignInManager<AppUser> _signInManager;
        private UserManager<AppUser> _userManager;

        public BienBanSuCoController(IGenericRepository<BIENBANSUCO> context,
            IGenericRepository<LOAISUCO> loaisucocontext,
            IGenericRepository<NHANVIEN> nhanviencontext, UserManager<AppUser> userMgr,
        SignInManager<AppUser> signinMgr)
        {
            _context = context;
            _loaisucocontext = loaisucocontext;
            _nhanviencontext = nhanviencontext;
            _signInManager = signinMgr;
            _userManager = userMgr;

        }

        private void AllViewBag()
        {
            var loaisucolist = _loaisucocontext.GetList().Where(c => c.TrangThai == "1");
            var nhanvienlist = _nhanviencontext.GetList().Where(c => c.TrangThai == "1");
            ViewData["MaLoaiSuCo"] = new SelectList(loaisucolist, "MaLoaiSuCo", "MaLoaiSuCo");
            ViewData["MaNV"] = new SelectList(nhanvienlist, "MaNV", "MaNV");
        }
        private async Task<IActionResult> GetResult(string mabienban = null,
            string maloaisuco = null, string manv = null, DateTime? thoigian = null)
        {
            var loaisucolist = _loaisucocontext.GetList().Where(c => c.TrangThai == "1");
            var nhanvienlist = _nhanviencontext.GetList().Where(c => c.TrangThai == "1");
            ViewData["maloaisuco"] = new SelectList(loaisucolist, "MaLoaiSuCo", "MaLoaiSuCo", maloaisuco);
            ViewData["manv"] = new SelectList(nhanvienlist, "MaNV", "MaNV", manv);
            //var a = _context.GetList();
            var result = from s in _context.GetList() where
                         (mabienban == null || s.MaBienBan == mabienban)
                         && (maloaisuco == null || s.MaLoaiSuCo == maloaisuco)
                         && (manv == null || s.MaNV == manv)
                         && (thoigian == null || DateTime.Compare(Convert.ToDateTime(s.ThoiGian), thoigian.Value) == 0)
                         && s.TrangThai == "1"
                         select s;
            //IQueryable<BIENBANSUCO> result = _context.GetList().Where(c =>
            //(mabienban == null || c.MaBienBan == mabienban) && (maloaisuco == null || c.MaLoaiSuCo == maloaisuco)
            //&& (manv == null || c.MaNV == manv)
            //&& (thoigian == null || DateTime.Compare(Convert.ToDateTime(c.ThoiGian), thoigian.Value) == 0)
            //&& c.TrangThai == "1");
            return View(await result.ToListAsync());

        }
        // GET: BienBanSuCo
        [Route("quan-ly/bien-ban-su-co")]
        public async Task<IActionResult> Search(string mabienban = null,
            string maloaisuco = null, string manv = null, DateTime? thoigian = null)
        {
            //return View(await _context.GetAll());
            List<SelectListItem> listTrangThaiDuyet = new List<SelectListItem>();
            listTrangThaiDuyet.Add(new SelectListItem { Text = "Đã duyệt", Value = "A" });
            listTrangThaiDuyet.Add(new SelectListItem { Text = "Chưa duyệt", Value = "U" });
            ViewData["TrangThaiDuyet"] = listTrangThaiDuyet;
            return await GetResult(mabienban, maloaisuco, manv, thoigian = null);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/bien-ban-su-co")]
        public async Task<IActionResult> Search(int? id, string trangthaiduyet, string mabienban = null,
            string maloaisuco = null, string manv = null, DateTime? thoigian = null)
        {
            if (id == null)
                return NotFound();
            var bienbansuco = await _context.Get(id);
            if (bienbansuco == null)
                return NotFound();
            if (ModelState.IsValid)
            {
                _context.SetState(bienbansuco, EntityState.Modified);
                await _context.Update(bienbansuco, trangthaiduyet, "1", _userManager.GetUserId(User));
            }
            return await Search(mabienban, maloaisuco, manv, thoigian = null);
        }
        // GET: BienBanSuCo/Details/5
        [Route("quan-ly/bien-ban-su-co/chi-tiet/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();
            var bienbansuco = await _context.Get(id);
            if (bienbansuco == null)
                return NotFound();
            AllViewBag();
            return View(bienbansuco);
        }

        // GET: BienBanSuCo/Create
        [Route("quan-ly/bien-ban-su-co/tao-moi")]
        public IActionResult Create()
        {
            AllViewBag();
            return View();
        }

        // POST: BienBanSuCo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/bien-ban-su-co/tao-moi")]
        public async Task<IActionResult> Create(BIENBANSUCO bienbansuco)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(bienbansuco, _userManager.GetUserId(User));
                return RedirectToAction("Index");
            }
            return View(bienbansuco);
        }

        // GET: BienBanSuCo/Edit/5
        [Route("quan-ly/bien-ban-su-co/chinh-sua/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var bienbansuco = await _context.Get(id);
            if (bienbansuco == null)
                return NotFound();
            var loaisucolist = _loaisucocontext.GetList().Where(c => c.TrangThai == "1");
            var nhanvienlist = _nhanviencontext.GetList().Where(c => c.TrangThai == "1");
            AllViewBag();
            return View(bienbansuco);
        }

        // POST: BienBanSuCo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/bien-ban-su-co/chinh-sua/{id}")]
        public async Task<IActionResult> Edit(int id, BIENBANSUCO bienbansuco)
        {
            if (id != bienbansuco.Id)
                return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(bienbansuco);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BienBanSuCoExists(bienbansuco.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction("Index");
            }
            return View(bienbansuco);
        }
        [Route("quan-ly/bien-ban-su-co/xoa/{id}")]
        // GET: BienBanSuCo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var bienbansuco = await _context.Get(id);
            if (bienbansuco == null)
                return NotFound();
            AllViewBag();
            return View(bienbansuco);
        }

        // POST: BienBanSuCo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/bien-ban-su-co/xoa/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bienbansuco = await _context.Get(id);
            if (ModelState.IsValid)
            {
                if (bienbansuco.TrangThaiDuyet == "A")
                    await _context.Update(bienbansuco, "U", "0");
                else
                    await _context.Delete(id);
            }
            return RedirectToAction("Index");
        }

        private bool BienBanSuCoExists(int id)
        {
            return _context.Exists(id);
        }
    }
}
