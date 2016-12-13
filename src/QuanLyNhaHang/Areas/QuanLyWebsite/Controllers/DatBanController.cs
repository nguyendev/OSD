using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Infrastructure;
using QuanLyNhaHang.Models;

namespace QuanLyNhaHang.Areas.QuanLyWebsite.Controllers
{
    public class DatBanController : Controller
    {
        private readonly IGenericRepository<DATBAN> _context;

        public DatBanController(IGenericRepository<DATBAN> context)
        {
            _context = context;    
        }

        // GET: DatBan
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAll());
        }

        // GET: DatBan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datban = await _context.Get(id);
            if (datban == null)
            {
                return NotFound();
            }

            return View(datban);
        }

        // GET: DatBan/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DatBan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Gio,HoTen,Ngay,SoDT,SoNguoi")] DATBAN datban)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(datban);
                return RedirectToAction("Index");
            }
            return View(datban);
        }

        // GET: DatBan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datban = await _context.Get(id);
            if (datban == null)
            {
                return NotFound();
            }
            return View(datban);
        }

        // POST: DatBan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Gio,HoTen,Ngay,SoDT,SoNguoi")] DATBAN datban)
        {
            if (id != datban.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(datban);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DatBanExists(datban.Id))
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
            return View(datban);
        }

        private bool DatBanExists(int id)
        {
            return _context.Exists(id);
        }

        // GET: DatBan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datban = await _context.Get(id);
            if (datban == null)
            {
                return NotFound();
            }

            return View(datban);
        }

        // POST: DatBan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _context.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
