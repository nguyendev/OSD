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
    public class BoPhanController : Controller
    {
        private readonly IGenericRepository<BOPHAN> _context;
        private readonly IGenericRepository<NHANVIEN> _nhanviencontext;
        private SignInManager<AppUser> SignInManager;
        private UserManager<AppUser> UserManager;

        public BoPhanController(IGenericRepository<BOPHAN> context,
            IGenericRepository<NHANVIEN> nhanviencontext)
        {
            _context = context;
            _nhanviencontext = nhanviencontext;   
        }

        //search
        public async Task<IActionResult> GetResult(string mabp = null, string tenbp = null,
            string matruongbp = null)
        {
            var nhanvienlist = _nhanviencontext.GetList().Where(c => c.TrangThai == "1");
            ViewData["MaTruongBP"] = new SelectList(nhanvienlist, "MaNV", "MaNV", matruongbp);
            IQueryable<BOPHAN> result = _context.GetList().Where(c => 
            (mabp == null || c.MaBP == mabp) && (tenbp == null || c.TenBP == tenbp)
            && (matruongbp == null || c.MaTruongBP == matruongbp) && c.TrangThai == "1");
            return View(await result.ToListAsync());
        }

        // GET: BoPhan
        public async Task<IActionResult> Index(string mabp = null, string tenbp = null,
            string matruongbp = null)
        {
            return await GetResult(mabp,tenbp,matruongbp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(int? id, string trangthaiduyet, string mabp = null, string tenbp = null,
            string matruongbp = null)
        {
            if (id == null)
            {
                return NotFound();
            }
            var bophan = await _context.Get(id);
            if (bophan == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.SetState(bophan, EntityState.Modified);
                await _context.Update(bophan,trangthaiduyet, "1", UserManager.GetUserId(User));
            }
            return await GetResult(mabp, tenbp, matruongbp);
        }
        // GET: BoPhan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bophan = await _context.Get(id);
            if (bophan == null)
            {
                return NotFound();
            }

            return View(bophan);
        }

        // GET: BoPhan/Create
        public IActionResult Create()
        {
            var nhanvienlist = _nhanviencontext.GetList().Where(c => c.TrangThai == "1");
            ViewData["MaTruongBP"] = new SelectList(nhanvienlist, "MaNV", "MaNV");
            return View();
        }

        // POST: BoPhan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BOPHAN bophan)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(bophan, UserManager.GetUserId(User));
                return RedirectToAction("Index");
            }
            return View(bophan);
        }

        // GET: BoPhan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bophan = await _context.Get(id);
            if (bophan == null)
            {
                return NotFound();
            }
            var nhanvienlist = _nhanviencontext.GetList().Where(c => c.TrangThai == "1");
            ViewData["MaTruongBP"] = new SelectList(nhanvienlist, "MaNV", "MaNV");
            return View(bophan);
        }

        // POST: BoPhan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BOPHAN bophan)
        {
            if (id != bophan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(bophan);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoPhanExists(bophan.Id))
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
            return View(bophan);
        }

        private bool BoPhanExists(int id)
        {
            return _context.Exists(id);
        }

        // GET: BoPhan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bophan = await _context.Get(id);
            if (bophan == null)
            {
                return NotFound();
            }

            return View(bophan);
        }

        // POST: BoPhan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bophan = await _context.Get(id);
            if (ModelState.IsValid)
            {
                if (bophan.TrangThaiDuyet == "A")
                {
                    await _context.Update(bophan,"U","0");
                }
                else
                    await _context.Delete(id);
            }
            return RedirectToAction("Index");
        }
    }
}
