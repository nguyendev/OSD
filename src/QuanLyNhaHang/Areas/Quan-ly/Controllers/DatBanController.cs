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
    public class DatBanController : Controller
    {
        private readonly IGenericRepository<DATBAN> _context;
        private SignInManager<AppUser> SignInManager;
        private UserManager<AppUser> UserManager;

        public DatBanController(IGenericRepository<DATBAN> context, UserManager<AppUser> userMgr,
        SignInManager<AppUser> signinMgr)
        {
            _context = context;
            SignInManager = signinMgr;
            UserManager = userMgr;
        }

        private async Task<IActionResult> GetResult(string ngay = null,
            string gio = null, string sodt = null)
        {
            IQueryable<DATBAN> result = _context.GetList().Where(c =>
            (gio == null || c.Gio == gio) && (ngay == null || c.Ngay == ngay)
            && (sodt == null || c.SoDT == sodt) && c.TrangThai == "1");
            return View(await result.ToListAsync());

        }

        // GET: DatBan
        [Route("quan-ly/dat-ban")]
        public async Task<IActionResult> Search(string ngay = null,
            string gio = null, string sodt = null)
        {
            List<SelectListItem> listTrangThaiDuyet = new List<SelectListItem>();
            listTrangThaiDuyet.Add(new SelectListItem { Text = "Đã duyệt", Value = "A" });
            listTrangThaiDuyet.Add(new SelectListItem { Text = "Chưa duyệt", Value = "U" });
            ViewData["TrangThaiDuyet"] = listTrangThaiDuyet;

            return await GetResult(ngay, gio, sodt);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/dat-ban")]
        public async Task<IActionResult> Search(int? id, string trangthaiduyet, string ngay = null,
            string gio = null, string sodt = null)
        {
            if (id == null)
            {
                return NotFound();
            }
            var datban = await _context.Get(id);
            if (datban == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.SetState(datban, EntityState.Modified);
                await _context.Update(datban, trangthaiduyet, "1", UserManager.GetUserId(User));
            }
            return await Search(ngay, gio, sodt);
        }
        // GET: DatBan/Details/5
        [Route("quan-ly/dat-ban/chi-tiet/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datban = await _context.Get(id);
            if (datban == null)
            {
                return NotFound();
            }

            return View(datban);
        }

        // GET: DatBan/Create
        [Route("quan-ly/dat-ban/tao-moi")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: DatBan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/dat-ban/tao-moi")]
        public async Task<IActionResult> Create(DATBAN datban)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(datban, UserManager.GetUserId(User));
                return RedirectToAction("Search");
            }
            return View(datban);
        }

        // GET: DatBan/Edit/5
        [Route("quan-ly/dat-ban/chinh-sua/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datban = await _context.Get(id);
            if (datban == null)
            {
                return NotFound();
            }
            return View(datban);
        }

        // POST: DatBan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/dat-ban/chinh-sua/{id}")]
        public async Task<IActionResult> Edit(int id, DATBAN datban)
        {
            if (id != datban.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(datban);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DatBanExists(datban.Id))
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
            return View(datban);
        }

        private bool DatBanExists(int id)
        {
            return _context.Exists(id);
        }

        // GET: DatBan/Delete/5
        [Route("quan-ly/dat-ban/xoa/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datban = await _context.Get(id);
            if (datban == null)
            {
                return NotFound();
            }

            return View(datban);
        }

        // POST: DatBan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/dat-ban/xoa/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var datban = await _context.Get(id);
            if (ModelState.IsValid)
            {
                if (datban.TrangThaiDuyet == "A")
                {
                    await _context.Update(datban,"U","0");
                }
                else
                    await _context.Delete(id);
            }
            return RedirectToAction("Search");
        }
    }
}
