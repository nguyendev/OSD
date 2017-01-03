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
            IGenericRepository<NHANVIEN> nhanviencontext, UserManager<AppUser> userMgr,
        SignInManager<AppUser> signinMgr)
        {
            _context = context;
            _nhanviencontext = nhanviencontext;
            SignInManager = signinMgr;
            UserManager = userMgr;
        }

        private void AllViewBag()
        {
            var nguoilaplist = _nhanviencontext.GetList().Where(c => c.TrangThai == "1");
            ViewData["NguoiLap"] = new SelectList(nguoilaplist, "MaNV", "MaNV");
        }

        private async Task<IActionResult> GetResult(string ngaylap = null,
          string nguoilap = null)
        {
            var nguoilaplist = _nhanviencontext.GetList().Where(c => c.TrangThai == "1");
            ViewData["nguoilap"] = new SelectList(nguoilaplist, "MaNV", "MaNV", nguoilap);
            IQueryable<THUCHI> result = _context.GetList().Where(c =>
           (ngaylap == null || DateTime.Compare(Convert.ToDateTime(c.NgayTao), Convert.ToDateTime(ngaylap)) == 0)
           && (nguoilap == null || c.NguoiLap == nguoilap) && c.TrangThai == "1");
            return View(await result.ToListAsync());
        }
        // GET: ThuChi
        [Route("quan-ly/thu-chi")]
        public async Task<IActionResult> Search(string ngaylap = null,
          string nguoilap = null)
        {
            List<SelectListItem> listTrangThaiDuyet = new List<SelectListItem>();
            listTrangThaiDuyet.Add(new SelectListItem { Text = "Đã duyệt", Value = "A" });
            listTrangThaiDuyet.Add(new SelectListItem { Text = "Chưa duyệt", Value = "U" });
            ViewData["TrangThaiDuyet"] = listTrangThaiDuyet;

            return await GetResult(ngaylap, nguoilap);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/thu-chi")]
        public async Task<IActionResult> Search(int? id, string trangthaiduyet,
            string ngaylap = null, string nguoilap = null)
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
            return await Search(ngaylap, nguoilap);
        }
        // GET: ThuChi/Details/5
        [Route("quan-ly/thu-chi/chi-tiet/{id}")]
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
            AllViewBag();
            return View(thuchi);
        }

        // GET: ThuChi/Create
        [Route("quan-ly/thu-chi/tao-moi")]
        public IActionResult Create()
        {
            AllViewBag();
            return View();
        }

        // POST: ThuChi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/thu-chi/tao-moi")]
        public async Task<IActionResult> Create(THUCHI thuchi)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(thuchi, UserManager.GetUserId(User));
                return RedirectToAction("Search");
            }
            return View(thuchi);
        }

        // GET: ThuChi/Edit/5
        [Route("quan-ly/thu-chi/chinh-sua/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var thuchi = await _context.Get(id);
            if (thuchi == null)
                return NotFound();
            AllViewBag();
            return View(thuchi);
        }

        // POST: ThuChi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/thu-chi/chinh-sua/{id}")]
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
                return RedirectToAction("Search");
            }
            return View(thuchi);
        }

        private bool ThuChiExists(int id)
        {
            return _context.Exists(id);
        }

        // GET: ThuChi/Delete/5
        [Route("quan-ly/thu-chi/xoa/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var thuchi = await _context.Get(id);
            if (thuchi == null)
                return NotFound();
            AllViewBag();
            return View(thuchi);
        }

        // POST: ThuChi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/thu-chi/xoa/{id}")]
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
            return RedirectToAction("Search");
        }
    }
}
