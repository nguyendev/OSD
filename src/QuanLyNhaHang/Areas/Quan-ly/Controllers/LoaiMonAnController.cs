using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Models;
using QuanLyNhaHang.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace QuanLyNhaHang.Areas.QuanLyWebsite.Controllers
{
    [Area("quan-ly")]
    [Authorize]
    public class LoaiMonAnController : Controller
    {
        private readonly IGenericRepository<LOAIMONAN> _context;
        private SignInManager<AppUser> SignInManager;
        private UserManager<AppUser> UserManager;

        public LoaiMonAnController(IGenericRepository<LOAIMONAN> context, UserManager<AppUser> userMgr,
        SignInManager<AppUser> signinMgr)
        {
            _context = context;
            SignInManager = signinMgr;
            UserManager = userMgr;
        }

        //search
        private async Task<IActionResult> GetResult(string maloaimon = null,
            string tenloaimon = null)
        {
            IQueryable<LOAIMONAN> result = _context.GetList().Where(c =>
           (maloaimon == null || c.MaLoaiMon == maloaimon) && (tenloaimon == null || c.TenLoaiMon == tenloaimon)
            && c.TrangThai == "1");
            return View(await result.ToListAsync());
        }
        // GET: LoaiMonAn
        [Route("quan-ly/loai-mon-an")]
        public async Task<IActionResult> Search(string maloaimon = null,
            string tenloaimon = null)
        {
            List<SelectListItem> listTrangThaiDuyet = new List<SelectListItem>();
            listTrangThaiDuyet.Add(new SelectListItem { Text = "Đã duyệt", Value = "A" });
            listTrangThaiDuyet.Add(new SelectListItem { Text = "Chưa duyệt", Value = "U" });
            ViewData["TrangThaiDuyet"] = listTrangThaiDuyet;

            return await GetResult(maloaimon, tenloaimon);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/loai-mon-an")]
        public async Task<IActionResult> Search(int? id, string trangthaiduyet, 
            string maloaimon = null, string tenloaimon = null)
        {
            if (id == null)
            {
                return NotFound();
            }
            var loaimonan = await _context.Get(id);
            if (loaimonan == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.SetState(loaimonan, EntityState.Modified);
                await _context.Update(loaimonan, trangthaiduyet, "1", UserManager.GetUserId(User));
            }
            return await Search(maloaimon, tenloaimon);
        }
        // GET: LoaiMonAn/Details/5
        [Route("quan-ly/loai-mon-an/chi-tiet/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaimonan = await _context.Get(id);
            if (loaimonan == null)
            {
                return NotFound();
            }

            return View(loaimonan);
        }

        // GET: LoaiMonAn/Create
        [Route("quan-ly/loai-mon-an/tao-moi")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: LoaiMonAn/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/loai-mon-an/tao-moi")]
        public async Task<IActionResult> Create(LOAIMONAN loaimonan)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(loaimonan, UserManager.GetUserId(User));
                return RedirectToAction("Search");
            }
            return View(loaimonan);
        }

        // GET: LoaiMonAn/Edit/5
        [Route("quan-ly/loai-mon-an/chinh-sua/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaimonan = await _context.Get(id);
            if (loaimonan == null)
            {
                return NotFound();
            }
            return View(loaimonan);
        }

        // POST: LoaiMonAn/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/loai-mon-an/chinh-sua/{id}")]
        public async Task<IActionResult> Edit(int id, LOAIMONAN loaimonan)
        {
            if (id != loaimonan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(loaimonan);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiMonAnExists(loaimonan.Id))
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
            return View(loaimonan);
        }

        private bool LoaiMonAnExists(int id)
        {
            return _context.Exists(id);
        }

        // GET: LoaiMonAn/Delete/5
        [Route("quan-ly/loai-mon-an/xoa/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaimonan = await _context.Get(id);
            if (loaimonan == null)
            {
                return NotFound();
            }

            return View(loaimonan);
        }

        // POST: LoaiMonAn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/loai-mon-an/xoa/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loaimon = await _context.Get(id);
            if (ModelState.IsValid)
            {
                if (loaimon.TrangThaiDuyet == "A")
                {
                    await _context.Update(loaimon, "U", "0");
                }
                else
                    await _context.Delete(id);
            }
            return RedirectToAction("Search");
        }
    }
}
