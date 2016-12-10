using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Infrastructure;

namespace QuanLyNhaHang.Areas.QuanLyWebsite.Controllers
{
    public class LoaiSuCoController : Controller
    {
        private readonly IGenericRepository<LOAISUCO> _context;

        public LoaiSuCoController(IGenericRepository<LOAISUCO> context)
        {
            _context = context;
        }

        // GET: LoaiSuCo
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAll());
        }

        // GET: LoaiSuCo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaisuco = await _context.Get(id);
            if (loaisuco == null)
            {
                return NotFound();
            }

            return View(loaisuco);
        }

        // GET: LoaiSuCo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LoaiSuCo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaBoPhanXuLy,MaLSC,TenLSC")] LOAISUCO loaisuco)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(loaisuco);
                return RedirectToAction("Index");
            }
            return View(loaisuco);
        }

        // GET: LoaiSuCo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaisuco = await _context.Get(id);
            if (loaisuco == null)
            {
                return NotFound();
            }
            return View(loaisuco);
        }

        // POST: LoaiSuCo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaBoPhanXuLy,MaLSC,TenLSC")] LOAISUCO loaisuco)
        {
            if (id != loaisuco.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(loaisuco);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiSuCoExists(loaisuco.Id))
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
            return View(loaisuco);
        }

        private bool LoaiSuCoExists(int id)
        {
            return _context.Exists(id);
        }

        // GET: LoaiSuCo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaisuco = await _context.Get(id);
            if (loaisuco == null)
            {
                return NotFound();
            }

            return View(loaisuco);
        }

        // POST: LoaiSuCo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _context.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
