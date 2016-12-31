using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Infrastructure;
using QuanLyNhaHang.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace QuanLyNhaHang.Areas.QuanLyWebsite.Controllers
{
    [Area("Quan-ly")]
    [Authorize]
    public class NguyenLieuTrongKhoController : Controller
    {
        private readonly IGenericRepository<NGUYENLIEUTRONGKHO> _context;
        private readonly IGenericRepository<NGUYENLIEU> _nguyenlieucontext;
        private SignInManager<AppUser> SignInManager;
        private UserManager<AppUser> UserManager;

        public NguyenLieuTrongKhoController(IGenericRepository<NGUYENLIEUTRONGKHO> context,
            IGenericRepository<NGUYENLIEU> nguyenlieucontext)
        {
            _context = context;
            _nguyenlieucontext = nguyenlieucontext;
        }

        public async Task<IActionResult> GetResult(string manl = null)
        {
            var nguyenlieulist = _nguyenlieucontext.GetList().Where(c => c.TrangThai == "1");
            ViewData["MaNL"] = new SelectList(nguyenlieulist, "MaNL", "TenNL", manl);

            IQueryable<NGUYENLIEUTRONGKHO> result = _context.GetList().Where(c =>
           (manl == null || c.MaNL == manl)
           && c.TrangThai == "1");
            return View(await result.ToListAsync());
        }
        // GET: NguyenLieuTrongKho
        public async Task<IActionResult> Index(string manl = null)
        {
            return await GetResult(manl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(int? id, string trangthaiduyet,
     string manl = null)
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
                await _context.Update(nguyenlieu, trangthaiduyet,"1",UserManager.GetUserId(User));
            }
            return await GetResult(manl);
        }
        // GET: NguyenLieuTrongKho/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguyenlieutrongkho = await _context.Get(id);
            if (nguyenlieutrongkho == null)
            {
                return NotFound();
            }

            return View(nguyenlieutrongkho);
        }

        // GET: NguyenLieuTrongKho/Create
        public IActionResult Create()
        {
            var nguyenlieulist = _nguyenlieucontext.GetList().Where(c => c.TrangThai == "1");
            ViewData["MaNL"] = new SelectList(nguyenlieulist, "MaNL", "TenNL");
            return View();
        }

        // POST: NguyenLieuTrongKho/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NGUYENLIEUTRONGKHO nguyenlieutrongkho)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(nguyenlieutrongkho, UserManager.GetUserId(User));
                return RedirectToAction("Index");
            }
            return View(nguyenlieutrongkho);
        }

        // GET: NguyenLieuTrongKho/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguyenlieutrongkho = await _context.Get(id);
            if (nguyenlieutrongkho == null)
            {
                return NotFound();
            }
            var nguyenlieulist = _nguyenlieucontext.GetList().Where(c => c.TrangThai == "1");
            ViewData["MaNL"] = new SelectList(nguyenlieulist, "MaNL", "TenNL");
            return View(nguyenlieutrongkho);
        }

        // POST: NguyenLieuTrongKho/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, NGUYENLIEUTRONGKHO nguyenlieutrongkho)
        {
            if (id != nguyenlieutrongkho.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(nguyenlieutrongkho);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NguyenLieuTrongKhoExists(nguyenlieutrongkho.Id))
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
            return View(nguyenlieutrongkho);
        }

        private bool NguyenLieuTrongKhoExists(int id)
        {
            return _context.Exists(id);
        }

        // GET: NguyenLieuTrongKho/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguyenlieutrongkho = await _context.Get(id);
            if (nguyenlieutrongkho == null)
            {
                return NotFound();
            }

            return View(nguyenlieutrongkho);
        }

        // POST: NguyenLieuTrongKho/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nguyenlieutrongkho = await _context.Get(id);
            if (ModelState.IsValid)
            {
                if (nguyenlieutrongkho.TrangThaiDuyet == "A")
                {
                    await _context.Update(nguyenlieutrongkho,"U","0");
                }
                else
                    await _context.Delete(id);
            }
            return RedirectToAction("Index");
        }
    }
}
