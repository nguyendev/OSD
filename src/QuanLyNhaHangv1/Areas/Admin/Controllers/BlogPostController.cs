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
    [Area("admin")]
    public class BlogPostController : Controller
    {
        private readonly QuanLyNhaHangDbContext _context;

        public BlogPostController(QuanLyNhaHangDbContext context)
        {
            _context = context;    
        }

        // GET: BlogPost
        public async Task<IActionResult> Index()
        {
            var quanLyNhaHang = _context.blogPost.Include(b => b.BlogAdminstrator).Include(b => b.BlogCategory);
            return View(await quanLyNhaHang.ToListAsync());
        }

        // GET: BlogPost/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPost = await _context.blogPost.SingleOrDefaultAsync(m => m.PostId == id);
            if (blogPost == null)
            {
                return NotFound();
            }

            return View(blogPost);
        }

        // GET: BlogPost/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.blogAdministrator, "UserId", "FullName");
            ViewData["CategoryId"] = new SelectList(_context.blogCategory, "CategoryId", "CategoryName");
            return View();
        }

        // POST: BlogPost/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostId,Brief,CategoryId,Content,CreateDate,Picture,Status,Tags,Title,UserId,ViewNo")] BlogPost blogPost)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blogPost);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["UserId"] = new SelectList(_context.blogAdministrator, "UserId", "FullName", blogPost.UserId);
            ViewData["CategoryId"] = new SelectList(_context.blogCategory, "CategoryId", "CategoryName", blogPost.CategoryId);
            return View(blogPost);
        }

        // GET: BlogPost/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPost = await _context.blogPost.SingleOrDefaultAsync(m => m.PostId == id);
            if (blogPost == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.blogAdministrator, "UserId", "FullName", blogPost.UserId);
            ViewData["CategoryId"] = new SelectList(_context.blogCategory, "CategoryId", "CategoryName", blogPost.CategoryId);
            return View(blogPost);
        }

        // POST: BlogPost/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PostId,Brief,CategoryId,Content,CreateDate,Picture,Status,Tags,Title,UserId,ViewNo")] BlogPost blogPost)
        {
            if (id != blogPost.PostId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blogPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogPostExists(blogPost.PostId))
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
            ViewData["UserId"] = new SelectList(_context.blogAdministrator, "UserId", "FullName", blogPost.UserId);
            ViewData["CategoryId"] = new SelectList(_context.blogCategory, "CategoryId", "CategoryName", blogPost.CategoryId);
            return View(blogPost);
        }

        // GET: BlogPost/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPost = await _context.blogPost.SingleOrDefaultAsync(m => m.PostId == id);
            if (blogPost == null)
            {
                return NotFound();
            }

            return View(blogPost);
        }

        // POST: BlogPost/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blogPost = await _context.blogPost.SingleOrDefaultAsync(m => m.PostId == id);
            _context.blogPost.Remove(blogPost);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool BlogPostExists(int id)
        {
            return _context.blogPost.Any(e => e.PostId == id);
        }
    }
}
