using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Infrastructure;
using QuanLyNhaHang.Models;

namespace QuanLyNhaHang.Areas.QuanLyWebsite.Controllers
{
    [Area("QuanLyWebsite")]
    public class YeuCauNhapHangController : Controller
    {
        private readonly IGenericRepository<YEUCAUNHAPHANG> _context;

        public YeuCauNhapHangController(IGenericRepository<YEUCAUNHAPHANG> context)
        {
            _context = context;    
        }

        // GET: YeuCauNhapHang
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAll());
        }

        // GET: YeuCauNhapHang/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yeucaunhaphang = await _context.Get(id);
            if (yeucaunhaphang == null)
            {
                return NotFound();
            }

            return View(yeucaunhaphang);
        }

        // GET: YeuCauNhapHang/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: YeuCauNhapHang/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaYeuCau,MaNL,MaNCC,SoLuong")] YEUCAUNHAPHANG yeucaunhaphang)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(yeucaunhaphang);
                return RedirectToAction("Index");
            }
            return View(yeucaunhaphang);

        }

        // GET: YeuCauNhapHang/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yeucaunhaphang = await _context.Get(id);
            if (yeucaunhaphang == null)
            {
                return NotFound();
            }
            return View(yeucaunhaphang);
        }

        // POST: YeuCauNhapHang/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaYeuCau,MaNL,MaNCC,SoLuong")] YEUCAUNHAPHANG yeucaunhaphang)
        {
            if (id != yeucaunhaphang.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(yeucaunhaphang);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YeuCauNhapHangExists(yeucaunhaphang.Id))
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
            {
                return NotFound();
            }

            var yeucaunhaphang = await _context.Get(id);
            if (yeucaunhaphang == null)
            {
                return NotFound();
            }

            return View(yeucaunhaphang);
        }

        // POST: YeuCauNhapHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _context.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
