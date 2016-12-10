using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Infrastructure;

namespace QuanLyNhaHang.Areas.QuanLyWebsite.Controllers
{
    public class MonAnController : Controller
    {
        private readonly IGenericRepository<MONAN> _context;

        public MonAnController(IGenericRepository<MONAN> context)
        {
            _context = context;
        }

        // GET: MonAn
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAll());
        }

        // GET: MonAn/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monan = await _context.Get(id);
            if (monan == null)
            {
                return NotFound();
            }

            return View(monan);
        }

        // GET: MonAn/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MonAn/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Gia,MaMon,TenMon")] MONAN monan)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(monan);
                return RedirectToAction("Index");
            }
            return View(monan);
        }

        // GET: MonAn/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monan = await _context.Get(id);
            if (monan == null)
            {
                return NotFound();
            }
            return View(monan);
        }

        // POST: MonAn/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Gia,MaMon,TenMon")] MONAN monan)
        {
            if (id != monan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(monan);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonAnExists(monan.Id))
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
            return View(monan);
        }

        private bool MonAnExists(int id)
        {
            return _context.Exists(id);
        }

        // GET: MonAn/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monan = await _context.Get(id);
            if (monan == null)
            {
                return NotFound();
            }

            return View(monan);
        }

        // POST: MonAn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _context.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
