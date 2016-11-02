using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHangv1.Data;
using QuanLyNhaHangv1.Models;

namespace QuanLyNhaHangv1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GrantPermissionController : Controller
    {
        private readonly QuanLyNhaHangDbContext _context;

        public GrantPermissionController(QuanLyNhaHangDbContext context)
        {
            _context = context;    
        }

        // GET: GrantPermission
        public async Task<IActionResult> Index()
        {
            var quanLyNhaHang = _context.grantPermission.Include(g => g.BlogAdministrator).Include(g => g.BlogPermission);
            return View(await quanLyNhaHang.ToListAsync());
        }

        // GET: GrantPermission/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grantPermission = await _context.grantPermission.SingleOrDefaultAsync(m => m.PermissionId == id);
            if (grantPermission == null)
            {
                return NotFound();
            }

            return View(grantPermission);
        }

        // GET: GrantPermission/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.blogAdministrator, "UserId", "FullName");
            ViewData["PermissionId"] = new SelectList(_context.blogPermission, "PermissionId", "BussinessId");
            return View();
        }

        // POST: GrantPermission/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PermissionId,UserId,Description")] GrantPermission grantPermission)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grantPermission);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["UserId"] = new SelectList(_context.blogAdministrator, "UserId", "FullName", grantPermission.UserId);
            ViewData["PermissionId"] = new SelectList(_context.blogPermission, "PermissionId", "BussinessId", grantPermission.PermissionId);
            return View(grantPermission);
        }

        // GET: GrantPermission/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grantPermission = await _context.grantPermission.SingleOrDefaultAsync(m => m.PermissionId == id);
            if (grantPermission == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.blogAdministrator, "UserId", "FullName", grantPermission.UserId);
            ViewData["PermissionId"] = new SelectList(_context.blogPermission, "PermissionId", "BussinessId", grantPermission.PermissionId);
            return View(grantPermission);
        }

        // POST: GrantPermission/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PermissionId,UserId,Description")] GrantPermission grantPermission)
        {
            if (id != grantPermission.PermissionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grantPermission);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GrantPermissionExists(grantPermission.PermissionId))
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
            ViewData["UserId"] = new SelectList(_context.blogAdministrator, "UserId", "FullName", grantPermission.UserId);
            ViewData["PermissionId"] = new SelectList(_context.blogPermission, "PermissionId", "BussinessId", grantPermission.PermissionId);
            return View(grantPermission);
        }

        // GET: GrantPermission/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grantPermission = await _context.grantPermission.SingleOrDefaultAsync(m => m.PermissionId == id);
            if (grantPermission == null)
            {
                return NotFound();
            }

            return View(grantPermission);
        }

        // POST: GrantPermission/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grantPermission = await _context.grantPermission.SingleOrDefaultAsync(m => m.PermissionId == id);
            _context.grantPermission.Remove(grantPermission);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool GrantPermissionExists(int id)
        {
            return _context.grantPermission.Any(e => e.PermissionId == id);
        }
    }
}
