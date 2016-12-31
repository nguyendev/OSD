using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Infrastructure;
using QuanLyNhaHang.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace QuanLyNhaHang.Areas.QuanLyWebsite.Controllers
{
    [Area("Quan-ly")]
    [Authorize]
    public class NguyenLieuController : Controller
    {
        private readonly IGenericRepository<NGUYENLIEU> _context;
        private SignInManager<AppUser> SignInManager;
        private UserManager<AppUser> UserManager;

        public NguyenLieuController(IGenericRepository<NGUYENLIEU> context)
        {
            _context = context;    
        }

        public async Task<IActionResult> GetResult(string manl = null,
        string tennl = null)
        {
            IQueryable<NGUYENLIEU> result = _context.GetList().Where(c =>
           (manl == null || c.MaNL == manl) && (tennl == null || c.TenNL == tennl)
           && c.TrangThai == "1");
            return View(await result.ToListAsync());
        }
        // GET: NguyenLieu
        public async Task<IActionResult> Index(string manl = null,
        string tennl = null)
        {
            return await GetResult(manl,tennl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(int? id, string trangthaiduyet,
            string manl = null, string tennl = null)
        {
            if (id == null)
            {
                return NotFound();
            }
            var nguyenlieu = await _context.Get(id);
            if (nguyenlieu == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.SetState(nguyenlieu, EntityState.Modified);
                await _context.Update(nguyenlieu, trangthaiduyet,"1", UserManager.GetUserId(User));
            }
            return await GetResult(manl, tennl);
        }

        // GET: NguyenLieu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguyenlieu = await _context.Get(id);
            if (nguyenlieu == null)
            {
                return NotFound();
            }

            return View(nguyenlieu);
        }

        // GET: NguyenLieu/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NguyenLieu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NGUYENLIEU nguyenlieu)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(nguyenlieu, UserManager.GetUserId(User));
                return RedirectToAction("Index");
            }
            return View(nguyenlieu);
        }

        // GET: NguyenLieu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguyenlieu = await _context.Get(id);
            if (nguyenlieu == null)
            {
                return NotFound();
            }
            return View(nguyenlieu);
        }

        // POST: NguyenLieu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, NGUYENLIEU nguyenlieu)
        {
            if (id != nguyenlieu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(nguyenlieu);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NguyenLieuExists(nguyenlieu.Id))
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
            return View(nguyenlieu);
        }

        private bool NguyenLieuExists(int id)
        {
            return _context.Exists(id);
        }

        // GET: NguyenLieu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguyenlieu = await _context.Get(id);
            if (nguyenlieu == null)
            {
                return NotFound();
            }

            return View(nguyenlieu);
        }

        // POST: NguyenLieu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nguyenlieu = await _context.Get(id);
            if (ModelState.IsValid)
            {
                if (nguyenlieu.TrangThaiDuyet == "A")
                {
                    await _context.Update(nguyenlieu,"U","0");
                }
                else
                    await _context.Delete(id);
            }
            return RedirectToAction("Index");
        }

    }
}
