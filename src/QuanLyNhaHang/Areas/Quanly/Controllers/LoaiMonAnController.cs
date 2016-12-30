using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Models;
using QuanLyNhaHang.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyNhaHang.Areas.QuanLyWebsite.Controllers
{
    [Area("Quanly")]

    public class LoaiMonAnController : Controller
    {
        private readonly IGenericRepository<LOAIMONAN> _context;

        public LoaiMonAnController(IGenericRepository<LOAIMONAN> context)
        {
            _context = context;    
        }

        //search
        public async Task<List<LOAIMONAN>> GetResult(string sortOrder, string maloaimon = null,
            string tenloaimon = null)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.MaLoaiMonAn = string.IsNullOrEmpty(sortOrder) ? "MaLoaiMonGiam" : "MaLoaiMon";
            ViewBag.TenLoaiMonAn = string.IsNullOrEmpty(sortOrder) ? "TenLoaiMonGiam" : "TenLoaiMon";
            IQueryable<LOAIMONAN> result = _context.GetList().Where(c =>
           (maloaimon == null || c.MaLoaiMon == maloaimon) && (tenloaimon == null || c.TenLoaiMon == tenloaimon)
            && c.TrangThai == "1");
            switch (sortOrder)
            {
                case "TenLoaiMonGiam":
                    {
                        result.OrderByDescending(c => c.TenLoaiMon);
                        break;
                    }
                case "TenLoaiMon":
                    {
                        result.OrderBy(c => c.TenLoaiMon);
                        break;
                    }
                case "MaLoaiMonGiam":
                    {
                        result.OrderByDescending(c => c.MaLoaiMon);
                        break;
                    }
                default:
                    {
                        result.OrderBy(c => c.MaLoaiMon);
                        break;
                    }
            }
            return await result.ToListAsync();
        }
        // GET: LoaiMonAn
        public async Task<IActionResult> Index(string sortOrder, string maloaimon = null,
            string tenloaimon = null)
        {
            return View(await GetResult(sortOrder, maloaimon, tenloaimon));
        }

        // GET: LoaiMonAn/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaimonan = await _context.Get(id);
            if (loaimonan == null)
            {
                return NotFound();
            }

            return View(loaimonan);
        }

        // GET: LoaiMonAn/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LoaiMonAn/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaLoaiMon,TenLoaiMon")] LOAIMONAN loaimonan)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(loaimonan);
                return RedirectToAction("Index");
            }
            return View(loaimonan);
        }

        // GET: LoaiMonAn/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaimonan = await _context.Get(id);
            if (loaimonan == null)
            {
                return NotFound();
            }
            return View(loaimonan);
        }

        // POST: LoaiMonAn/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaLoaiMon,TenLoaiMon")] LOAIMONAN loaimonan)
        {
            if (id != loaimonan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(loaimonan);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiMonAnExists(loaimonan.Id))
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
            return View(loaimonan);
        }

        private bool LoaiMonAnExists(int id)
        {
            return _context.Exists(id);
        }

        // GET: LoaiMonAn/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaimonan = await _context.Get(id);
            if (loaimonan == null)
            {
                return NotFound();
            }

            return View(loaimonan);
        }

        // POST: LoaiMonAn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _context.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
