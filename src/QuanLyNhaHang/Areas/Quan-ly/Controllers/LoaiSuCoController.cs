using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Infrastructure;
using QuanLyNhaHang.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace QuanLyNhaHang.Areas.QuanLyWebsite.Controllers
{
    [Area("quan-ly")]
    [Authorize]
    public class LoaiSuCoController : Controller
    {
        private readonly IGenericRepository<LOAISUCO> _context;
        private readonly IGenericRepository<BOPHAN> _bophancontext;
        private SignInManager<AppUser> SignInManager;
        private UserManager<AppUser> UserManager;

        public LoaiSuCoController(IGenericRepository<LOAISUCO> context,
            IGenericRepository<BOPHAN> bophancontext, UserManager<AppUser> userMgr,
        SignInManager<AppUser> signinMgr)
        {
            _context = context;
            _bophancontext = bophancontext;
            SignInManager = signinMgr;
            UserManager = userMgr;
        }

        private void AllViewBag()
        {
            var bophanxulylist = _bophancontext.GetList().Where(c => c.TrangThai == "1");
            ViewData["MaBP"] = new SelectList(bophanxulylist, "MaBP", "MaBP");
        }

        private async Task<IActionResult> GetResult(string maloaisuco = null,
           string tenloaisuco = null, string mabp = null)
        {
            var bophanxulylist = _bophancontext.GetList().Where(c => c.TrangThai == "1");
            ViewData["mabp"] = new SelectList(bophanxulylist, "MaBP", "MaBP",mabp);
            IQueryable<LOAISUCO> result = _context.GetList().Where(c =>
           (maloaisuco == null || c.MaLoaiSuCo == maloaisuco) && (tenloaisuco == null || c.TenLoaiSuCo == tenloaisuco)
            && (mabp == null || c.MaBoPhanXuLy == mabp) && c.TrangThai == "1");
            return View(await result.ToListAsync());
        }
        // GET: LoaiSuCo
        [Route("quan-ly/loai-su-co")]
        public async Task<IActionResult> Search(string maloaisuco = null,
           string tenloaisuco = null, string mabp = null)
        {
            List<SelectListItem> listTrangThaiDuyet = new List<SelectListItem>();
            listTrangThaiDuyet.Add(new SelectListItem { Text = "Đã duyệt", Value = "A" });
            listTrangThaiDuyet.Add(new SelectListItem { Text = "Chưa duyệt", Value = "U" });
            return await GetResult(maloaisuco, tenloaisuco,mabp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/loai-su-co")]
        public async Task<IActionResult> Search(int? id, string trangthaiduyet,
    string maloaisuco = null, string tenloaisuco = null, string mabp = null)
        {
            if (id == null)
            {
                return NotFound();
            }
            var loaisuco = await _context.Get(id);
            if (loaisuco == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.SetState(loaisuco, EntityState.Modified);
                await _context.Update(loaisuco, trangthaiduyet,"1", UserManager.GetUserId(User));
            }
            return await Search(maloaisuco, tenloaisuco, mabp);
        }

        // GET: LoaiSuCo/Details/5
        [Route("quan-ly/loai-su-co/chi-tiet/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaisuco = await _context.Get(id);
            if (loaisuco == null)
            {
                return NotFound();
            }
            AllViewBag();
            return View(loaisuco);
        }

        // GET: LoaiSuCo/Create
        [Route("quan-ly/loai-su-co/tao-moi")]
        public IActionResult Create()
        {
            AllViewBag();
            return View();
        }

        // POST: LoaiSuCo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/loai-su-co/tao-moi")]
        public async Task<IActionResult> Create(LOAISUCO loaisuco)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(loaisuco, UserManager.GetUserId(User));
                return RedirectToAction("Search");
            }
            return View(loaisuco);
        }

        // GET: LoaiSuCo/Edit/5
        [Route("quan-ly/loai-su-co/chinh-sua/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaisuco = await _context.Get(id);
            if (loaisuco == null)
            {
                return NotFound();
            }
            AllViewBag();
            return View(loaisuco);
        }

        // POST: LoaiSuCo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/loai-su-co/chinh-sua/{id}")]
        public async Task<IActionResult> Edit(int id, LOAISUCO loaisuco)
        {
            if (id != loaisuco.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(loaisuco);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiSuCoExists(loaisuco.Id))
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
            return View(loaisuco);
        }

        private bool LoaiSuCoExists(int id)
        {
            return _context.Exists(id);
        }

        // GET: LoaiSuCo/Delete/5
        [Route("quan-ly/loai-su-co/xoa/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaisuco = await _context.Get(id);
            if (loaisuco == null)
            {
                return NotFound();
            }
            AllViewBag();
            return View(loaisuco);
        }

        // POST: LoaiSuCo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/loai-su-co/xoa/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loaisuco = await _context.Get(id);
            if (ModelState.IsValid)
            {
                if (loaisuco.TrangThaiDuyet == "A")
                {
                    await _context.Update(loaisuco, "U", "0");
                }
                else
                    await _context.Delete(id);
            }
            return RedirectToAction("Search");
        }
    }
}
