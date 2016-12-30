using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Infrastructure;
using QuanLyNhaHang.Models;

namespace QuanLyNhaHang.Areas.QuanLyWebsite.Controllers
{
    [Area("Quanly")]
    public class HoaDonNhapHangController : Controller
    {
        private readonly IGenericRepository<HOADONNHAPHANG> _context;

        public HoaDonNhapHangController(IGenericRepository<HOADONNHAPHANG> context)
        {
            _context = context;    
        }

        // GET: HoaDonNhapHang
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAll());
        }

        // GET: HoaDonNhapHang/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoadonnhaphang = await _context.Get(id);
            if (hoadonnhaphang == null)
            {
                return NotFound();
            }

            return View(hoadonnhaphang);
        }

        // GET: HoaDonNhapHang/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HoaDonNhapHang/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaHD,MaYeuCau,MaNV,ThoiGianNhap,ThanhTien")] HOADONNHAPHANG hoadonnhaphang)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(hoadonnhaphang);
                return RedirectToAction("Index");
            }
            return View(hoadonnhaphang);
        }

        // GET: HoaDonNhapHang/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoadonnhaphang = await _context.Get(id);
            if (hoadonnhaphang == null)
            {
                return NotFound();
            }
            return View(hoadonnhaphang);
        }

        // POST: HoaDonNhapHang/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaHD,MaYeuCau,MaNV,ThoiGianNhap,ThanhTien")] HOADONNHAPHANG hoadonnhaphang)
        {
            if (id != hoadonnhaphang.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(hoadonnhaphang);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoaDonNhapHangExists(hoadonnhaphang.Id))
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
            return View(hoadonnhaphang);
        }

        private bool HoaDonNhapHangExists(int id)
        {
            return _context.Exists(id);
        }

        // GET: HoaDonNhapHang/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoadonnhaphang = await _context.Get(id);
            if (hoadonnhaphang == null)
            {
                return NotFound();
            }

            return View(hoadonnhaphang);
        }

        // POST: HoaDonNhapHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _context.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
