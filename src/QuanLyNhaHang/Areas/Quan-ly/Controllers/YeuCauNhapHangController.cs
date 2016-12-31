using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Infrastructure;
using QuanLyNhaHang.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace QuanLyNhaHang.Areas.QuanLyWebsite.Controllers
{
    [Area("Quan-ly")]
    [Authorize]
    public class YeuCauNhapHangController : Controller
    {
        private readonly IGenericRepository<YEUCAUNHAPHANG> _context;
        private readonly IGenericRepository<NGUYENLIEU> _nguyenlieucontext;
        private readonly IGenericRepository<NHACUNGCAP> _nhacungcapcontext;
        private SignInManager<AppUser> SignInManager;
        private UserManager<AppUser> UserManager;

        public YeuCauNhapHangController(IGenericRepository<YEUCAUNHAPHANG> context,
            IGenericRepository<NGUYENLIEU> nguyenlieucontext,
            IGenericRepository<NHACUNGCAP> nhacungcapcontext)
        {
            _context = context;
            _nguyenlieucontext = nguyenlieucontext;
            _nhacungcapcontext = nhacungcapcontext;   
        }

        private async Task<IActionResult> GetResult(string mayc = null,
     string manl = null, string mancc = null)
        {
            var nguyenlieulist = _nguyenlieucontext.GetList().Where(c => c.TrangThai == "1");
            ViewData["MaNL"] = new SelectList(nguyenlieulist, "MaNL", "TenNL", manl);
            var ncclist = _nhacungcapcontext.GetList().Where(c => c.TrangThai == "1");
            ViewData["MaNCC"] = new SelectList(ncclist, "MaNCC", "TenNCC", mancc);
            IQueryable<YEUCAUNHAPHANG> result = _context.GetList().Where(c =>
           (mayc == null || c.MaYeuCau == mayc) && (manl == null || c.MaNL == manl)
           && (mancc == null || c.MaNCC == mancc) && c.TrangThai == "1");
            return View(await result.ToListAsync());
        }
        // GET: YeuCauNhapHang
        public async Task<IActionResult> Index(string mayc = null, string manl = null, string mancc = null)
        {
            return await GetResult(mayc, manl, mancc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(int? id, string trangthaiduyet,
        string mayc = null, string manl = null, string mancc = null)
        {
            if (id == null)
                return NotFound();
            var yeucau = await _context.Get(id);
            if (yeucau == null)
                return NotFound();
            if (ModelState.IsValid)
            {
                _context.SetState(yeucau, EntityState.Modified);
                await _context.Update(yeucau, trangthaiduyet, "1", UserManager.GetUserId(User));
            }
            return await GetResult(mayc, manl, mancc);
        }
        // GET: YeuCauNhapHang/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();
            var yeucaunhaphang = await _context.Get(id);
            if (yeucaunhaphang == null)
                return NotFound();
            return View(yeucaunhaphang);
        }

        // GET: YeuCauNhapHang/Create
        public IActionResult Create()
        {
            var nguyenlieulist = _nguyenlieucontext.GetList().Where(c => c.TrangThai == "1");
            ViewData["MaNL"] = new SelectList(nguyenlieulist, "MaNL", "TenNL");
            var ncclist = _nhacungcapcontext.GetList().Where(c => c.TrangThai == "1");
            ViewData["MaNCC"] = new SelectList(ncclist, "MaNCC", "TenNCC");
            return View();
        }

        // POST: YeuCauNhapHang/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(YEUCAUNHAPHANG yeucaunhaphang)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(yeucaunhaphang, UserManager.GetUserId(User));
                return RedirectToAction("Index");
            }
            return View(yeucaunhaphang);

        }

        // GET: YeuCauNhapHang/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var yeucaunhaphang = await _context.Get(id);
            if (yeucaunhaphang == null)
                return NotFound();
            var nguyenlieulist = _nguyenlieucontext.GetList().Where(c => c.TrangThai == "1");
            ViewData["MaNL"] = new SelectList(nguyenlieulist, "MaNL", "TenNL");
            var ncclist = _nhacungcapcontext.GetList().Where(c => c.TrangThai == "1");
            ViewData["MaNCC"] = new SelectList(ncclist, "MaNCC", "TenNCC");
            return View(yeucaunhaphang);
        }

        // POST: YeuCauNhapHang/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, YEUCAUNHAPHANG yeucaunhaphang)
        {
            if (id != yeucaunhaphang.Id)
                return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(yeucaunhaphang);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YeuCauNhapHangExists(yeucaunhaphang.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction("Index");
            }
            return View(yeucaunhaphang);
        }

        private bool YeuCauNhapHangExists(int id)
        {
            return _context.Exists(id);
        }

        // GET: YeuCauNhapHang/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var yeucaunhaphang = await _context.Get(id);
            if (yeucaunhaphang == null)
                return NotFound();
            return View(yeucaunhaphang);
        }

        // POST: YeuCauNhapHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yeucaunhaphang = await _context.Get(id);
            if (ModelState.IsValid)
            {
                if (yeucaunhaphang.TrangThaiDuyet == "A")
                    await _context.Update(yeucaunhaphang, "U", "0");
                else
                    await _context.Delete(id);
            }
            return RedirectToAction("Index");
        }
    }
}
