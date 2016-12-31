using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Infrastructure;
using QuanLyNhaHang.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace QuanLyNhaHang.Areas.QuanLyWebsite.Controllers
{
    [Area("Quan-ly")]
    [Authorize]
    public class LuotKhachController : Controller
    {
        private readonly IGenericRepository<LUOTKHACH> _context;
        private SignInManager<AppUser> SignInManager;
        private UserManager<AppUser> UserManager;

        public LuotKhachController(IGenericRepository<LUOTKHACH> context)
        {
            _context = context;
        }

        private async Task<IActionResult> GetResult(string maluot = null,
           int? soban = null, string thoigianvao = null)
        {
            IQueryable<LUOTKHACH> result = _context.GetList().Where(c =>
          (maluot == null || c.MaLuot == maluot) && (soban == null || c.SoBan == soban.Value)
          && (thoigianvao == null || c.ThoiGianVao == thoigianvao) && c.TrangThai == "1");
            return View(await result.ToListAsync());
        }
        // GET: LuotKhach
        public async Task<IActionResult> Index(string maluot = null,
           int? soban = null, string thoigianvao = null)
        {
            return await GetResult(maluot, soban, thoigianvao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(int? id, string trangthaiduyet,
    string maluot = null, int? soban = null, string thoigianvao = null)
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
            return await GetResult(maluot, soban, thoigianvao);
        }
        // GET: LuotKhach/Details/5
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
        public IActionResult Create()
        {
            return View();
        }

        // POST: LuotKhach/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LUOTKHACH luotkhach)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(luotkhach, UserManager.GetUserId(User));
                return RedirectToAction("Index");
            }
            return View(luotkhach);
        }

        // GET: LuotKhach/Edit/5
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
                return RedirectToAction("Index");
            }
            return View(luotkhach);
        }

        private bool LuotKhachExists(int id)
        {
            return _context.Exists(id);
        }

        // GET: LuotKhach/Delete/5
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
            return RedirectToAction("Index");
        }
    }
}
