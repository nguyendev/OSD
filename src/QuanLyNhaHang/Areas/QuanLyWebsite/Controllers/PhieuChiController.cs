using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Models;
using QuanLyNhaHang.Infrastructure;

namespace QuanLyNhaHang.Areas.QuanLyWebsite.Controllers
{
    [Area("QuanLyWebsite")]
    public class PhieuChiController : Controller
    {
        private readonly IGenericRepository<PHIEUCHI> _context;

        public PhieuChiController(IGenericRepository<PHIEUCHI> context)
        {
            _context = context;    
        }

        // GET: PhieuChi
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAll());
        }

        // GET: PhieuChi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieuchi = await _context.Get(id);
            if (phieuchi == null)
            {
                return NotFound();
            }

            return View(phieuchi);
        }

        // GET: PhieuChi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PhieuChi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaPC,MaHD,NguoiLap,NgayLap,SoNo,ThanhTien")] PHIEUCHI phieuchi)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(phieuchi);
                return RedirectToAction("Index");
            }
            return View(phieuchi);
        }

        // GET: PhieuChi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieuchi = await _context.Get(id);
            if (phieuchi == null)
            {
                return NotFound();
            }
            return View(phieuchi);
        }

        // POST: PhieuChi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaPC,MaHD,NguoiLap,NgayLap,SoNo,ThanhTien")] PHIEUCHI phieuchi)
        {
            if (id != phieuchi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(phieuchi);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhieuChiExists(phieuchi.Id))
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
            return View(phieuchi);
        }

        private bool PhieuChiExists(int id)
        {
            return _context.Exists(id);
        }

        // GET: PhieuChi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieuchi = await _context.Get(id);
            if (phieuchi == null)
            {
                return NotFound();
            }

            return View(phieuchi);
        }

        // POST: PhieuChi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _context.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
