using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Infrastructure;
using QuanLyNhaHang.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace QuanLyNhaHang.Areas.QuanLyWebsite.Controllers
{
    [Area("quan-ly")]
    [Authorize]
    public class NguyenLieuTrongKhoController : Controller
    {
        private readonly IGenericRepository<NGUYENLIEUTRONGKHO> _context;
        private readonly IGenericRepository<NGUYENLIEU> _nguyenlieucontext;
        private SignInManager<AppUser> SignInManager;
        private UserManager<AppUser> UserManager;

        public NguyenLieuTrongKhoController(IGenericRepository<NGUYENLIEUTRONGKHO> context,
            IGenericRepository<NGUYENLIEU> nguyenlieucontext, UserManager<AppUser> userMgr,
        SignInManager<AppUser> signinMgr)
        {
            _context = context;
            _nguyenlieucontext = nguyenlieucontext;
            SignInManager = signinMgr;
            UserManager = userMgr;
        }

        private void AllViewBag()
        {
            var nguyenlieulist = _nguyenlieucontext.GetList().Where(c => c.TrangThai == "1");
            ViewData["MaNL"] = new SelectList(nguyenlieulist, "MaNL", "TenNL");
        }

        public async Task<IActionResult> GetResult(string manl = null)
        {
            var nguyenlieulist = _nguyenlieucontext.GetList().Where(c => c.TrangThai == "1");
            ViewData["manl"] = new SelectList(nguyenlieulist, "MaNL", "TenNL", manl);
            IQueryable<NGUYENLIEUTRONGKHO> result = _context.GetList().Where(c =>
           (manl == null || c.MaNL == manl)
           && c.TrangThai == "1");
            return View(await result.ToListAsync());
        }
        // GET: NguyenLieuTrongKho
        [Route("quan-ly/nguyen-lieu-trong-kho")]
        public async Task<IActionResult> Search(string manl = null)
        {
            List<SelectListItem> listTrangThaiDuyet = new List<SelectListItem>();
            listTrangThaiDuyet.Add(new SelectListItem { Text = "Đã duyệt", Value = "A" });
            listTrangThaiDuyet.Add(new SelectListItem { Text = "Chưa duyệt", Value = "U" });
            return await GetResult(manl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/nguyen-lieu-trong-kho")]
        public async Task<IActionResult> Search(int? id, string trangthaiduyet,
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
            return await Search(manl);
        }
        // GET: NguyenLieuTrongKho/Details/5
        [Route("quan-ly/nguyen-lieu-trong-kho/chi-tiet/{id}")]
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
            AllViewBag();
            return View(nguyenlieutrongkho);
        }

        // GET: NguyenLieuTrongKho/Create
        [Route("quan-ly/nguyen-lieu-trong-kho/tao-moi")]
        public IActionResult Create()
        {
            AllViewBag();
            return View();
        }

        // POST: NguyenLieuTrongKho/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/nguyen-lieu-trong-kho/tao-moi")]
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
        [Route("quan-ly/nguyen-lieu-trong-kho/chinh-sua/{id}")]
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
            AllViewBag();
            return View(nguyenlieutrongkho);
        }

        // POST: NguyenLieuTrongKho/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/nguyen-lieu-trong-kho/chinh-sua/{id}")]
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
        [Route("quan-ly/nguyen-lieu-trong-kho/xoa/{id}")]
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
            AllViewBag();
            return View(nguyenlieutrongkho);
        }

        // POST: NguyenLieuTrongKho/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/nguyen-lieu-trong-kho/xoa/{id}")]
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
