using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Infrastructure;
using QuanLyNhaHang.Models;

namespace QuanLyNhaHang.Areas.QuanLyWebsite.Controllers
{
    [Area("QuanLyWebsite")]

    public class LuotKhachController : Controller
    {
        private readonly IGenericRepository<LUOTKHACH> _context;

        public LuotKhachController(IGenericRepository<LUOTKHACH> context)
        {
            _context = context;
        }

        // GET: LuotKhach
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAll());
        }

        // GET: LuotKhach/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var luotkhach = await _context.Get(id);
            if (luotkhach == null)
            {
                return NotFound();
            }

            return View(luotkhach);
        }

        // GET: LuotKhach/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LuotKhach/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaLuot,SoBan,ThoiGianVao,ThoiGianRa")] LUOTKHACH luotkhach)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(luotkhach);
                return RedirectToAction("Index");
            }
            return View(luotkhach);
        }

        // GET: LuotKhach/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var luotkhach = await _context.Get(id);
            if (luotkhach == null)
            {
                return NotFound();
            }
            return View(luotkhach);
        }

        // POST: LuotKhach/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaLuot,SoBan,ThoiGianVao,ThoiGianRa")] LUOTKHACH luotkhach)
        {
            if (id != luotkhach.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(luotkhach);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LuotKhachExists(luotkhach.Id))
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
            return View(luotkhach);
        }

        private bool LuotKhachExists(int id)
        {
            return _context.Exists(id);
        }

        // GET: LuotKhach/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var luotkhach = await _context.Get(id);
            if (luotkhach == null)
            {
                return NotFound();
            }

            return View(luotkhach);
        }

        // POST: LuotKhach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _context.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
