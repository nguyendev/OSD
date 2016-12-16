using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Infrastructure;
using QuanLyNhaHang.Models;

namespace QuanLyNhaHang.Areas.QuanLyWebsite.Controllers
{
    [Area("QuanLyWebsite")]
    public class BienBanSuCoController : Controller
    {
        private readonly IGenericRepository<BIENBANSUCO> _context;

        public BienBanSuCoController(IGenericRepository<BIENBANSUCO> context)
        {
            _context = context;    
        }

        // GET: BienBanSuCo
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAll());
        }

        // GET: BienBanSuCo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bienban = await _context.Get(id);
            if (bienban == null)
            {
                return NotFound();
            }

            return View(bienban);
        }

        // GET: BienBanSuCo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BienBanSuCo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaBienBan,MaLoaiSuCo,MaNV,NguyenNhan,ThoiGian,HuongGiaiQuyet")] BIENBANSUCO bienbansuco)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(bienbansuco);
                return RedirectToAction("Index");
            }
            return View(bienbansuco);
        }

        // GET: BienBanSuCo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bienbansuco = await _context.Get(id);
            if (bienbansuco == null)
            {
                return NotFound();
            }
            return View(bienbansuco);
        }

        // POST: BienBanSuCo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaBienBan,MaLoaiSuCo,MaNV,NguyenNhan,ThoiGian,HuongGiaiQuyet")] BIENBANSUCO bienbansuco)
        {
            if (id != bienbansuco.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(bienbansuco);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BienBanExists(bienbansuco.Id))
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
            return View(bienbansuco);
        }

        private bool BienBanExists(int id)
        {
            return _context.Exists(id);
        }

        // GET: BienBanSuCo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bienbansuco = await _context.Get(id);
            if (bienbansuco == null)
            {
                return NotFound();
            }

            return View(bienbansuco);
        }

        // POST: BienBanSuCo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _context.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
