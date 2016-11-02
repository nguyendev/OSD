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
    public class BlogCategoryController : Controller
    {
        private readonly QuanLyNhaHangDbContext _context;

        public BlogCategoryController(QuanLyNhaHangDbContext context)
        {
            _context = context;    
        }

        // GET: BlogCategory
        public async Task<IActionResult> Index()
        {
            var quanLyNhaHang = _context.blogCategory.Include(b => b.BlogAdministrator);
            return View(await quanLyNhaHang.ToListAsync());
        }

        // GET: BlogCategory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogCategory = await _context.blogCategory.SingleOrDefaultAsync(m => m.CategoryId == id);
            if (blogCategory == null)
            {
                return NotFound();
            }

            return View(blogCategory);
        }

        // GET: BlogCategory/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.blogAdministrator, "UserId", "FullName");
            return View();
        }

        // POST: BlogCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,CategoryName,OrderNo,Status,UserId")] BlogCategory blogCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blogCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["UserId"] = new SelectList(_context.blogAdministrator, "UserId", "FullName", blogCategory.UserId);
            return View(blogCategory);
        }

        // GET: BlogCategory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogCategory = await _context.blogCategory.SingleOrDefaultAsync(m => m.CategoryId == id);
            if (blogCategory == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.blogAdministrator, "UserId", "FullName", blogCategory.UserId);
            return View(blogCategory);
        }

        // POST: BlogCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId,CategoryName,OrderNo,Status,UserId")] BlogCategory blogCategory)
        {
            if (id != blogCategory.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blogCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogCategoryExists(blogCategory.CategoryId))
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
            ViewData["UserId"] = new SelectList(_context.blogAdministrator, "UserId", "FullName", blogCategory.UserId);
            return View(blogCategory);
        }

        // GET: BlogCategory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogCategory = await _context.blogCategory.SingleOrDefaultAsync(m => m.CategoryId == id);
            if (blogCategory == null)
            {
                return NotFound();
            }

            return View(blogCategory);
        }

        // POST: BlogCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blogCategory = await _context.blogCategory.SingleOrDefaultAsync(m => m.CategoryId == id);
            _context.blogCategory.Remove(blogCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool BlogCategoryExists(int id)
        {
            return _context.blogCategory.Any(e => e.CategoryId == id);
        }
    }
}
