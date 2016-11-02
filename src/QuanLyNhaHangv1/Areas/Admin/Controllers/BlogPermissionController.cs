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
    public class BlogPermissionController : Controller
    {
        private readonly QuanLyNhaHangDbContext _context;

        public BlogPermissionController(QuanLyNhaHangDbContext context)
        {
            _context = context;    
        }

        // GET: BlogPermission
        public async Task<IActionResult> Index(string id)
        {
            var quanLyNhaHangDbContext = _context.blogPermission.Where(x => x.BussinessCode == id);
            return View(await quanLyNhaHangDbContext.ToListAsync());
        }

        // GET: BlogPermission/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPermission = await _context.blogPermission.SingleOrDefaultAsync(m => m.PermissionId == id);
            if (blogPermission == null)
            {
                return NotFound();
            }

            return View(blogPermission);
        }

        // GET: BlogPermission/Create
        public IActionResult Create()
        {
            ViewData["BussinessCode"] = new SelectList(_context.blogBusiness, "BussinessCode", "BussinessCode");
            return View();
        }

        // POST: BlogPermission/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PermissionId,BussinessCode,Description,PermissionName")] BlogPermission blogPermission)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blogPermission);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["Bussinesscode"] = new SelectList(_context.blogBusiness, "BussinessCode", "BussinessCode", blogPermission.BussinessCode);
            return View(blogPermission);
        }

        // GET: BlogPermission/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPermission = await _context.blogPermission.SingleOrDefaultAsync(m => m.PermissionId == id);
            if (blogPermission == null)
            {
                return NotFound();
            }
            ViewData["BussinessCode"] = new SelectList(_context.blogBusiness, "BusinessCode", "BusinessCode", blogPermission.BussinessCode);
            return View(blogPermission);
        }

        // POST: BlogPermission/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PermissionId,BussinessCode,Description,PermissionName")] BlogPermission blogPermission)
        {
            //if (id != blogPermission.PermissionId)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blogPermission);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogPermissionExists(blogPermission.PermissionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", new { id = blogPermission.BussinessCode});
            }
            ViewBag.BussinessCode = new SelectList(_context.blogBusiness, "BusinessCode", "BusinessCode", blogPermission.BussinessCode);
            return View(blogPermission);
        }

        // GET: BlogPermission/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPermission = await _context.blogPermission.SingleOrDefaultAsync(m => m.PermissionId == id);
            if (blogPermission == null)
            {
                return NotFound();
            }

            return View(blogPermission);
        }

        // POST: BlogPermission/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blogPermission = await _context.blogPermission.SingleOrDefaultAsync(m => m.PermissionId == id);
            _context.blogPermission.Remove(blogPermission);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool BlogPermissionExists(int id)
        {
            return _context.blogPermission.Any(e => e.PermissionId == id);
        }
    }
}
