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

namespace QuanLyNhaHang.Areas.QuanLyWebsite.Controllers
{
    [Area("quan-ly")]
    [Authorize]
    public class MonAnController : Controller
    {
        private readonly IGenericRepository<MONAN> _context;
        private readonly IGenericRepository<LOAIMONAN> _loaimonancontext;

        private SignInManager<AppUser> SignInManager;
        private UserManager<AppUser> UserManager;

        public MonAnController(IGenericRepository<MONAN> context, 
            IGenericRepository<LOAIMONAN> loaimonancontext, UserManager<AppUser> userMgr,
        SignInManager<AppUser> signinMgr)
        {
            _context = context;
            _loaimonancontext = loaimonancontext;
            SignInManager = signinMgr;
            UserManager = userMgr;
        }

        private void AllViewBag()
        {
            var loaimonanlist = _loaimonancontext.GetList().Where(c => c.TrangThai == "1");
            ViewData["MaLoaiMon"] = new SelectList(loaimonanlist, "MaLoaiMon", "TenLoaiMon");
        }

        public async Task<IActionResult> GetResult(string mamon = null,
         string tenmon = null, string maloaimon = null)
        {
            var loaimonanlist = _loaimonancontext.GetList().Where(c => c.TrangThai == "1");
            ViewData["maloaimon"] = new SelectList(loaimonanlist, "MaLoaiMon", "TenLoaiMon", maloaimon);
            IQueryable<MONAN> result = _context.GetList().Where(c =>
           (mamon == null || c.MaMon == mamon) && (tenmon == null || c.TenMon == tenmon)
           && (maloaimon == null || c.MaLoaiMon == mamon) && c.TrangThai == "1");
            return View(await result.ToListAsync());
        }
        // GET: MonAn
        [Route("quan-ly/mon-an")]
        public async Task<IActionResult> Search(string mamon = null,
         string tenmon = null, string maloaimon = null)
        {
            List<SelectListItem> listTrangThaiDuyet = new List<SelectListItem>();
            listTrangThaiDuyet.Add(new SelectListItem { Text = "Đã duyệt", Value = "A" });
            listTrangThaiDuyet.Add(new SelectListItem { Text = "Chưa duyệt", Value = "U" });
            ViewData["TrangThaiDuyet"] = listTrangThaiDuyet;

            return await GetResult(mamon, tenmon, maloaimon);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/mon-an")]
        public async Task<IActionResult> Search(int? id, string trangthaiduyet,
    string mamon = null, string tenmon = null, string maloaimon = null)
        {
            if (id == null)
            {
                return NotFound();
            }
            var monan = await _context.Get(id);
            if (monan == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.SetState(monan, EntityState.Modified);
                await _context.Update(monan, trangthaiduyet,"1", UserManager.GetUserId(User));
            }
            return await Search(mamon, tenmon, maloaimon);
        }
        // GET: MonAn/Details/5
        [Route("quan-ly/mon-an/chi-tiet/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monan = await _context.Get(id);
            if (monan == null)
            {
                return NotFound();
            }
            AllViewBag();
            return View(monan);
        }

        // GET: MonAn/Create
        [Route("quan-ly/mon-an/tao-moi")]
        public IActionResult Create()
        {
            AllViewBag();
            return View();
        }

        // POST: MonAn/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/mon-an/tao-moi")]
        public async Task<IActionResult> Create(MONAN monan)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(monan, UserManager.GetUserId(User));
                return RedirectToAction("Search");
            }
            return View(monan);
        }

        // GET: MonAn/Edit/5
        [Route("quan-ly/mon-an/chinh-sua/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monan = await _context.Get(id);
            if (monan == null)
            {
                return NotFound();
            }
            AllViewBag();
            return View(monan);
        }

        // POST: MonAn/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/mon-an/chinh-sua/{id}")]
        public async Task<IActionResult> Edit(int id, MONAN monan)
        {
            if (id != monan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(monan);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonAnExists(monan.Id))
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
            return View(monan);
        }

        private bool MonAnExists(int id)
        {
            return _context.Exists(id);
        }

        // GET: MonAn/Delete/5
        [Route("quan-ly/mon-an/xoa/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monan = await _context.Get(id);
            if (monan == null)
            {
                return NotFound();
            }
            AllViewBag();
            return View(monan);
        }

        // POST: MonAn/Delete/5
        [HttpPost, ActionName("Delete")]
        [Route("quan-ly/mon-an/xoa/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var monan = await _context.Get(id);
            if (ModelState.IsValid)
            {
                if (monan.TrangThaiDuyet == "A")
                {
                    await _context.Update(monan,"U","0");
                }
                else
                    await _context.Delete(id);
            }
            return RedirectToAction("Search");
        }
    }
}
