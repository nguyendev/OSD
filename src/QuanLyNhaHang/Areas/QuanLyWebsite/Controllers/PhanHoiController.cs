using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Infrastructure;
using QuanLyNhaHang.Models;

namespace QuanLyNhaHang.Areas.QuanLyWebsite.Controllers
{
    public class PhanHoiController : Controller
    {
        private readonly IGenericRepository<PHANHOI> _context;

        public PhanHoiController(IGenericRepository<PHANHOI> context)
        {
            _context = context;    
        }

        // GET: PhanHoi
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAll());
        }

        // GET: PhanHoi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phanhoi = await _context.Get(id);
            if (phanhoi == null)
            {
                return NotFound();
            }

            return View(phanhoi);
        }

        // GET: PhanHoi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PhanHoi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenNguoiPH,NoiDung")] PHANHOI phanhoi)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(phanhoi);
                return RedirectToAction("Index");
            }
            return View(phanhoi);
        }

        // GET: PhanHoi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phanhoi = await _context.Get(id);
            if (phanhoi == null)
            {
                return NotFound();
            }
            return View(phanhoi);
        }

        // POST: PhanHoi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenNguoiPH,NoiDung")] PHANHOI phanhoi)
        {
            if (id != phanhoi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(phanhoi);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhanHoiExists(phanhoi.Id))
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
            return View(phanhoi);
        }

        private bool PhanHoiExists(int id)
        {
            return _context.Exists(id);
        }

        // GET: PhanHoi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phanhoi = await _context.Get(id);
            if (phanhoi == null)
            {
                return NotFound();
            }

            return View(phanhoi);
        }

        // POST: PhanHoi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _context.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
