using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Infrastructure;

namespace QuanLyNhaHang.Areas.QuanLyWebsite.Controllers
{
    public class BoPhanController : Controller
    {
        private readonly IGenericRepository<BOPHAN> _context;

        public BoPhanController(IGenericRepository<BOPHAN> context)
        {
            _context = context;    
        }

        // GET: BoPhan
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAll());
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
            return View();
        }

        // POST: BoPhan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaBP,MaTruongBP,TenBP")] BOPHAN bophan)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(bophan);
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
            return View(bophan);
        }

        // POST: BoPhan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaBP,MaTruongBP,TenBP")] BOPHAN bophan)
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
            await _context.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
