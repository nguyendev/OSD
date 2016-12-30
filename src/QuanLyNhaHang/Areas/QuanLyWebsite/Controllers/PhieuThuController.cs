using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Models;
using QuanLyNhaHang.Infrastructure;

namespace QuanLyNhaHang.Areas.QuanLyWebsite.Controllers
{
    public class PhieuThuController : Controller
    {
        private readonly IGenericRepository<PHIEUTHU> _context;

        public PhieuThuController(IGenericRepository<PHIEUTHU> context)
        {
            _context = context;    
        }

        // GET: PhieuThu
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAll());
        }

        // GET: PhieuThu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieuthu = await _context.Get(id);
            if (phieuthu == null)
            {
                return NotFound();
            }

            return View(phieuthu);
        }

        // GET: PhieuThu/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PhieuThu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaPT,MaLuot,NguoiLap,NgayLap,TienHang,PhiDichVuKhac,KhuyenMai,VAT,ThanhTien")] PHIEUTHU phieuthu)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(phieuthu);
                return RedirectToAction("Index");
            }
            return View(phieuthu);
        }

        // GET: PhieuThu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieuthu = await _context.Get(id);
            if (phieuthu == null)
            {
                return NotFound();
            }
            return View(phieuthu);
        }

        // POST: PhieuThu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaPT,MaLuot,NguoiLap,NgayLap,TienHang,PhiDichVuKhac,KhuyenMai,VAT,ThanhTien")] PHIEUTHU phieuthu)
        {
            if (id != phieuthu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(phieuthu);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhieuThuExists(phieuthu.Id))
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
            return View(phieuthu);
        }

        private bool PhieuThuExists(int id)
        {
            return _context.Exists(id);
        }

        // GET: PhieuThu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieuthu = await _context.Get(id);
            if (phieuthu == null)
            {
                return NotFound();
            }

            return View(phieuthu);
        }

        // POST: PhieuThu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _context.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
