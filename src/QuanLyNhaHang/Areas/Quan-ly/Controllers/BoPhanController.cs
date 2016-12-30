using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Infrastructure;
using QuanLyNhaHang.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;

namespace QuanLyNhaHang.Areas.QuanLyWebsite.Controllers
{
    [Area("Quan-ly")]
    [Authorize]
    public class BoPhanController : Controller
    {
        private readonly IGenericRepository<BOPHAN> _context;

        public BoPhanController(IGenericRepository<BOPHAN> context)
        {
            _context = context;    
        }

        //search
        public async Task<List<BOPHAN>> GetResult(string mabp = null, string tenbp = null,
            string matruongbp = null)
        {
            IQueryable<BOPHAN> result = _context.GetList().Where(c => 
            (mabp == null || c.MaBP == mabp) && (tenbp == null || c.TenBP == tenbp)
            && (matruongbp == null || c.MaTruongBP == matruongbp) && c.TrangThai == "1");
            return await result.ToListAsync();

        }

        // GET: BoPhan
        public async Task<IActionResult> Index(string mabp = null, string tenbp = null,
            string matruongbp = null)
        {
            return View(await GetResult(mabp,tenbp,matruongbp));
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
        public async Task<IActionResult> Create(BOPHAN bophan)
        {
            if (ModelState.IsValid)
            {
                bophan.NgayTao = DateTime.Now;
                bophan.TrangThai = "1";
                bophan.TrangThaiDuyet = "U";
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
        public async Task<IActionResult> Edit(int id, BOPHAN bophan)
        {
            if (id != bophan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    bophan.TrangThaiDuyet = "U";
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
            var bophan = await _context.Get(id);
            if (ModelState.IsValid)
            {
                if (bophan.TrangThaiDuyet == "A")
                {
                    bophan.TrangThai = "0";
                    bophan.TrangThaiDuyet = "U";
                    await _context.Update(bophan);
                }
                else
                    await _context.Delete(id);
            }
            return RedirectToAction("Index");
        }
    }
}
