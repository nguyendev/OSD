using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Infrastructure;
using QuanLyNhaHang.Models;
using System;

namespace QuanLyNhaHang.Areas.QuanLyWebsite.Controllers
{
    [Area("Quanly")]

    public class NguyenLieuTrongKhoController : Controller
    {
        private readonly IGenericRepository<NGUYENLIEUTRONGKHO> _context;

        public NguyenLieuTrongKhoController(IGenericRepository<NGUYENLIEUTRONGKHO> context)
        {
            _context = context;    
        }

        // GET: NguyenLieuTrongKho
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAll());
        }

        // GET: NguyenLieuTrongKho/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguyenlieutrongkho = await _context.Get(id);
            if (nguyenlieutrongkho == null)
            {
                return NotFound();
            }

            return View(nguyenlieutrongkho);
        }

        // GET: NguyenLieuTrongKho/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NguyenLieuTrongKho/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NGUYENLIEUTRONGKHO nguyenlieutrongkho)
        {
            if (ModelState.IsValid)
            {
                nguyenlieutrongkho.NgayTao = DateTime.Now;
                nguyenlieutrongkho.TrangThai = "1";
                nguyenlieutrongkho.TrangThaiDuyet = "U";
                await _context.Add(nguyenlieutrongkho);
                return RedirectToAction("Index");
            }
            return View(nguyenlieutrongkho);
        }

        // GET: NguyenLieuTrongKho/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguyenlieutrongkho = await _context.Get(id);
            if (nguyenlieutrongkho == null)
            {
                return NotFound();
            }
            return View(nguyenlieutrongkho);
        }

        // POST: NguyenLieuTrongKho/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, NGUYENLIEUTRONGKHO nguyenlieutrongkho)
        {
            if (id != nguyenlieutrongkho.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    nguyenlieutrongkho.TrangThaiDuyet = "U";
                    await _context.Update(nguyenlieutrongkho);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NguyenLieuTrongKhoExists(nguyenlieutrongkho.Id))
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
            return View(nguyenlieutrongkho);
        }

        private bool NguyenLieuTrongKhoExists(int id)
        {
            return _context.Exists(id);
        }

        // GET: NguyenLieuTrongKho/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguyenlieutrongkho = await _context.Get(id);
            if (nguyenlieutrongkho == null)
            {
                return NotFound();
            }

            return View(nguyenlieutrongkho);
        }

        // POST: NguyenLieuTrongKho/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nguyenlieutrongkho = await _context.Get(id);
            if (ModelState.IsValid)
            {
                if (nguyenlieutrongkho.TrangThaiDuyet == "A")
                {
                    nguyenlieutrongkho.TrangThai = "0";
                    nguyenlieutrongkho.TrangThaiDuyet = "U";
                    await _context.Update(nguyenlieutrongkho);
                }
                else
                    await _context.Delete(id);
            }
            return RedirectToAction("Index");
        }
    }
}
