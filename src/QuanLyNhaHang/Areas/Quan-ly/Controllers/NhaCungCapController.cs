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
    public class NhaCungCapController : Controller
    {
        private readonly IGenericRepository<NHACUNGCAP> _context;
        private SignInManager<AppUser> SignInManager;
        private UserManager<AppUser> UserManager;

        public NhaCungCapController(IGenericRepository<NHACUNGCAP> context, UserManager<AppUser> userMgr,
        SignInManager<AppUser> signinMgr)
        {
            _context = context;
            SignInManager = signinMgr;
            UserManager = userMgr;
        }

        public async Task<IActionResult> GetResult(string mancc = null,
      string tenncc = null)
        {
            IQueryable<NHACUNGCAP> result = _context.GetList().Where(c =>
           (mancc == null || c.MaNCC == mancc) && (tenncc == null || c.TenNCC == tenncc)
           && c.TrangThai == "1");
            return View(await result.ToListAsync());
        }

        // GET: NhaCungCap
        [Route("quan-ly/nha-cung-cap")]
        public async Task<IActionResult> Search(string mancc = null,
      string tenncc = null)
        {
            List<SelectListItem> listTrangThaiDuyet = new List<SelectListItem>();
            listTrangThaiDuyet.Add(new SelectListItem { Text = "Đã duyệt", Value = "A" });
            listTrangThaiDuyet.Add(new SelectListItem { Text = "Chưa duyệt", Value = "U" });
            ViewData["TrangThaiDuyet"] = listTrangThaiDuyet;

            return await GetResult(mancc, tenncc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/nha-cung-cap")]
        public async Task<IActionResult> Search(int? id, string trangthaiduyet,
           string mancc = null, string tenncc = null)
        {
            if (id == null)
            {
                return NotFound();
            }
            var nhacungcap = await _context.Get(id);
            if (nhacungcap == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.SetState(nhacungcap, EntityState.Modified);
                await _context.Update(nhacungcap, trangthaiduyet, "1", UserManager.GetUserId(User));
            }
            return await Search(mancc, tenncc);
        }
        // GET: NhaCungCap/Details/5
        [Route("quan-ly/nha-cung-cap/chi-tiet/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhacungcap = await _context.Get(id);
            if (nhacungcap == null)
            {
                return NotFound();
            }

            return View(nhacungcap);
        }

        // GET: NhaCungCap/Create
        [Route("quan-ly/nha-cung-cap/tao-moi")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: NhaCungCap/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/nha-cung-cap/tao-moi")]
        public async Task<IActionResult> Create(NHACUNGCAP nhacungcap)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(nhacungcap, UserManager.GetUserId(User));
                return RedirectToAction("Search");
            }
            return View(nhacungcap);
        }

        // GET: NhaCungCap/Edit/5
        [Route("quan-ly/nha-cung-cap/chinh-sua/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhacungcap = await _context.Get(id);
            if (nhacungcap == null)
            {
                return NotFound();
            }
            return View(nhacungcap);
        }

        // POST: NhaCungCap/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/nha-cung-cap/chinh-sua/{id}")]
        public async Task<IActionResult> Edit(int id, NHACUNGCAP nhacungcap)
        {
            if (id != nhacungcap.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(nhacungcap);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhaCungCapExists(nhacungcap.Id))
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
            return View(nhacungcap);
        }

        private bool NhaCungCapExists(int id)
        {
            return _context.Exists(id);
        }

        // GET: NhaCungCap/Delete/5
        [Route("quan-ly/nha-cung-cap/xoa/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhacungcap = await _context.Get(id);
            if (nhacungcap == null)
            {
                return NotFound();
            }

            return View(nhacungcap);
        }

        // POST: NhaCungCap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/nha-cung-cap/xoa/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nhacungcap = await _context.Get(id);
            if (ModelState.IsValid)
            {
                if (nhacungcap.TrangThaiDuyet == "A")
                    await _context.Update(nhacungcap,"U","0");
                else
                    await _context.Delete(id);
            }
            return RedirectToAction("Search");
        }

    }
}
