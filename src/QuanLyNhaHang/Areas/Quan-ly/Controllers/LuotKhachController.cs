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
    public class LuotKhachController : Controller
    {
        private readonly IGenericRepository<LUOTKHACH> _context;
        private SignInManager<AppUser> SignInManager;
        private UserManager<AppUser> UserManager;

        public LuotKhachController(IGenericRepository<LUOTKHACH> context, UserManager<AppUser> userMgr,
        SignInManager<AppUser> signinMgr)
        {
            _context = context;
            SignInManager = signinMgr;
            UserManager = userMgr;
        }

        private async Task<IActionResult> GetResult(string maluot = null,
           string thoigianvao = null)
        {
            IQueryable<LUOTKHACH> result = _context.GetList().Where(c =>
          (maluot == null || c.MaLuot == maluot)
          && (thoigianvao == null || Convert.ToDateTime(c.ThoiGianVao).Date == 
          Convert.ToDateTime(thoigianvao).Date) && c.TrangThai == "1");
            return View(await result.ToListAsync());
        }
        // GET: LuotKhach
        [Route("quan-ly/luot-khach")]
        public async Task<IActionResult> Search(string maluot = null,
            string thoigianvao = null)
        {
            List<SelectListItem> listTrangThaiDuyet = new List<SelectListItem>();
            listTrangThaiDuyet.Add(new SelectListItem { Text = "Đã duyệt", Value = "A" });
            listTrangThaiDuyet.Add(new SelectListItem { Text = "Chưa duyệt", Value = "U" });
            ViewData["TrangThaiDuyet"] = listTrangThaiDuyet;

            return await GetResult(maluot, thoigianvao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/luot-khach")]
        public async Task<IActionResult> Search(int? id, string trangthaiduyet,
    string maluot = null, string thoigianvao = null)
        {
            if (id == null)
            {
                return NotFound();
            }
            var luotkhach = await _context.Get(id);
            if (luotkhach == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.SetState(luotkhach, EntityState.Modified);
                await _context.Update(luotkhach, trangthaiduyet,"1", UserManager.GetUserId(User));
            }
            return await Search(maluot, thoigianvao);
        }
        // GET: LuotKhach/Details/5
        [Route("quan-ly/luot-khach/chi-tiet/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var luotkhach = await _context.Get(id);
            if (luotkhach == null)
            {
                return NotFound();
            }

            return View(luotkhach);
        }

        // GET: LuotKhach/Create
        [Route("quan-ly/luot-khach/tao-moi")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: LuotKhach/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/luot-khach/tao-moi")]
        public async Task<IActionResult> Create(LUOTKHACH luotkhach)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(luotkhach, UserManager.GetUserId(User));
                return RedirectToAction("Search");
            }
            return View(luotkhach);
        }

        // GET: LuotKhach/Edit/5
        [Route("quan-ly/luot-khach/chinh-sua/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var luotkhach = await _context.Get(id);
            if (luotkhach == null)
            {
                return NotFound();
            }
            return View(luotkhach);
        }

        // POST: LuotKhach/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/luot-khach/chinh-sua/{id}")]
        public async Task<IActionResult> Edit(int id, LUOTKHACH luotkhach)
        {
            if (id != luotkhach.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(luotkhach);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LuotKhachExists(luotkhach.Id))
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
            return View(luotkhach);
        }

        private bool LuotKhachExists(int id)
        {
            return _context.Exists(id);
        }

        // GET: LuotKhach/Delete/5
        [Route("quan-ly/luot-khach/xoa/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var luotkhach = await _context.Get(id);
            if (luotkhach == null)
            {
                return NotFound();
            }

            return View(luotkhach);
        }

        // POST: LuotKhach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/luot-khach/xoa/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var luotkhach = await _context.Get(id);
            if (ModelState.IsValid)
            {
                if (luotkhach.TrangThaiDuyet == "A")
                {
                    await _context.Update(luotkhach, "U", "0");
                }
                else
                    await _context.Delete(id);
            }
            return RedirectToAction("Search");
        }
    }
}
