using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Infrastructure;
using QuanLyNhaHang.Models;

namespace QuanLyNhaHang.Areas.QuanLyWebsite.Controllers
{
    [Area("QuanLyWebsite")]
    public class YeuCauMonAnController : Controller
    {
        private readonly IGenericRepository<YEUCAUMONAN> _context;

        public YeuCauMonAnController(IGenericRepository<YEUCAUMONAN> context)
        {
            _context = context;    
        }

        // GET: YeuCauMonAn
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAll());
        }

        // GET: YeuCauMonAn/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yeucaumonan = await _context.Get(id);
            if (yeucaumonan == null)
            {
                return NotFound();
            }

            return View(yeucaumonan);
        }

        // GET: YeuCauMonAn/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: YeuCauMonAn/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaLuot,MaMon,SoLuong")] YEUCAUMONAN yeucaumonan)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(yeucaumonan);
                return RedirectToAction("Index");
            }
            return View(yeucaumonan);
        }

        // GET: YeuCauMonAn/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yeucaumonan = await _context.Get(id);
            if (yeucaumonan == null)
            {
                return NotFound();
            }
            return View(yeucaumonan);
        }

        // POST: YeuCauMonAn/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaLuot,MaMon,SoLuong")] YEUCAUMONAN yeucaumonan)
        {
            if (id != yeucaumonan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(yeucaumonan);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YeuCauMonAnExists(yeucaumonan.Id))
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
            return View(yeucaumonan);
        }

        private bool YeuCauMonAnExists(int id)
        {
            return _context.Exists(id);
        }

        // GET: YeuCauMonAn/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yeucaumonan = await _context.Get(id);
            if (yeucaumonan == null)
            {
                return NotFound();
            }

            return View(yeucaumonan);
        }

        // POST: YeuCauMonAn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _context.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
