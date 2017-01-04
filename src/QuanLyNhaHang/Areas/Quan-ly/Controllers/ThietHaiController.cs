using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Infrastructure;
using QuanLyNhaHang.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaHang.Areas.Quan_ly.Controllers
{
    [Area("quan-ly")]
    [Authorize]
    public class ThietHaiController : Controller
    {
        private readonly IGenericRepository<THIETHAI> _context;
        private readonly IGenericRepository<BIENBANSUCO> _bienbansucocontext;
        private SignInManager<AppUser> _signInManager;
        private UserManager<AppUser> _userManager;

        public ThietHaiController(IGenericRepository<THIETHAI> context,
         IGenericRepository<BIENBANSUCO> loaisucocontext,
         UserManager<AppUser> userMgr,
     SignInManager<AppUser> signinMgr)
        {
            _context = context;
            _bienbansucocontext = loaisucocontext;
            _signInManager = signinMgr;
            _userManager = userMgr;
        }

        private void AllViewBag()
        {
            List<SelectListItem> listTrangThaiDuyet = new List<SelectListItem>();
            listTrangThaiDuyet.Add(new SelectListItem { Text = "Đã duyệt", Value = "A" });
            listTrangThaiDuyet.Add(new SelectListItem { Text = "Chưa duyệt", Value = "U" });
            ViewData["TrangThaiDuyet"] = listTrangThaiDuyet;
            var loaisucolist = _bienbansucocontext.GetList().Where(c => c.TrangThai == "1" && c.TrangThaiDuyet == "A");
            ViewData["MaBienBan"] = new SelectList(loaisucolist, "MaBienBan", "MaBienBan");
        }

        [Route("quan-ly/thiet-hai")]
        public async Task<IActionResult> Index()
        {
            AllViewBag();
            return View(await _context.GetAll());
        }

        [Route("quan-ly/thiet-hai")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(int ?id, string trangthaiduyet)
        {
            AllViewBag();
            if (id == null)
                return NotFound();
            var thiethai = await _context.Get(id);
            if (thiethai == null)
                return NotFound();
            if (ModelState.IsValid)
            {
                _context.SetState(thiethai, EntityState.Modified);
                await _context.Update(thiethai, trangthaiduyet, "1", _userManager.GetUserId(User));
            }
            return await Index();
        }
        // GET: PhanHoi/Details/5
        [Route("quan-ly/thiet-hai/chi-tiet/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();
            var thiethai = await _context.Get(id);
            if (thiethai == null)
                return NotFound();
            AllViewBag();
            return View(thiethai);
        }

        // GET: PhanHoi/Create
        [Route("quan-ly/thiet-hai/tao-moi")]
        public IActionResult Create()
        {
            AllViewBag();
            return View();
        }

        // POST: PhanHoi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/thiet-hai/tao-moi")]
        public async Task<IActionResult> Create(THIETHAI thiethai)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(thiethai, _userManager.GetUserId(User));
                return RedirectToAction("Index");
            }
            return View(thiethai);
        }

        // GET: PhanHoi/Edit/5
        [Route("quan-ly/thiet-hai/chinh-sua/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var thiethai = await _context.Get(id);
            if (thiethai == null)
                return NotFound();
            AllViewBag();
            return View(thiethai);
        }

        // POST: PhanHoi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/thiet-hai/chinh-sua/{id}")]
        public async Task<IActionResult> Edit(int id, THIETHAI thiethai)
        {
            if (id != thiethai.Id)
                return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(thiethai);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThietHaiExists(thiethai.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction("Index");
            }
            return View(thiethai);
        }

        private bool ThietHaiExists(int id)
        {
            return _context.Exists(id);
        }

        // GET: PhanHoi/Delete/5
        [Route("quan-ly/thiet-hai/xoa/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var thiethai = await _context.Get(id);
            if (thiethai == null)
                return NotFound();
            AllViewBag();
            return View(thiethai);
        }

        // POST: PhanHoi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/thiet-hai/xoa/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var thiethai = await _context.Get(id);
            if (ModelState.IsValid)
            {
                if (thiethai.TrangThaiDuyet == "A")
                    await _context.Update(thiethai, "U", "0");
                else
                    await _context.Delete(id);
            }
            return RedirectToAction("Index");
        }
    }
}