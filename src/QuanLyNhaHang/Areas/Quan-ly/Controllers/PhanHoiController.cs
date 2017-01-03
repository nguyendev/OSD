using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Infrastructure;
using QuanLyNhaHang.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace QuanLyNhaHang.Areas.QuanLyWebsite.Controllers
{
    [Area("quan-ly")]
    [Authorize]
    public class PhanHoiController : Controller
    {
        private readonly IGenericRepository<PHANHOI> _context;
        private SignInManager<AppUser> SignInManager;
        private UserManager<AppUser> UserManager;

        public PhanHoiController(IGenericRepository<PHANHOI> context, UserManager<AppUser> userMgr,
        SignInManager<AppUser> signinMgr)
        {
            _context = context;
            SignInManager = signinMgr;
            UserManager = userMgr;
        }

        // GET: PhanHoi
        [Route("quan-ly/phan-hoi")]
        public async Task<IActionResult> Index()
        {
            List<SelectListItem> listTrangThaiDuyet = new List<SelectListItem>();
            listTrangThaiDuyet.Add(new SelectListItem { Text = "Đã duyệt", Value = "A" });
            listTrangThaiDuyet.Add(new SelectListItem { Text = "Chưa duyệt", Value = "U" });
            ViewData["TrangThaiDuyet"] = listTrangThaiDuyet;

            return View(await _context.GetAll());
        }

        // GET: PhanHoi/Details/5
        [Route("quan-ly/phan-hoi/chi-tiet/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();
            var phanhoi = await _context.Get(id);
            if (phanhoi == null)
                return NotFound();
            return View(phanhoi);
        }

        // GET: PhanHoi/Create
        [Route("quan-ly/phan-hoi/tao-moi")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: PhanHoi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/phan-hoi/tao-moi")]
        public async Task<IActionResult> Create(PHANHOI phanhoi)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(phanhoi, UserManager.GetUserId(User));
                return RedirectToAction("Index");
            }
            return View(phanhoi);
        }

        // GET: PhanHoi/Edit/5
        [Route("quan-ly/phan-hoi/chinh-sua/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var phanhoi = await _context.Get(id);
            if (phanhoi == null)
                return NotFound();
            return View(phanhoi);
        }

        // POST: PhanHoi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/phan-hoi/chinh-sua/{id}")]
        public async Task<IActionResult> Edit(int id, PHANHOI phanhoi)
        {
            if (id != phanhoi.Id)
                return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(phanhoi);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhanHoiExists(phanhoi.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction("Index");
            }
            return View(phanhoi);
        }

        private bool PhanHoiExists(int id)
        {
            return _context.Exists(id);
        }

        // GET: PhanHoi/Delete/5
        [Route("quan-ly/phan-hoi/xoa/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var phanhoi = await _context.Get(id);
            if (phanhoi == null)
                return NotFound();
            return View(phanhoi);
        }

        // POST: PhanHoi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/phan-hoi/xoa/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phanhoi = await _context.Get(id);
            if (ModelState.IsValid)
            {
                if (phanhoi.TrangThaiDuyet == "A")
                    await _context.Update(phanhoi,"U","0");
                else
                    await _context.Delete(id);
            }
            return RedirectToAction("Index");
        }

    }
}
