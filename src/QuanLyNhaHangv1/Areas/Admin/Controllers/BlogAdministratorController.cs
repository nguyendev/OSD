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
    public class BlogAdministratorController : Controller
    {
        private readonly QuanLyNhaHangDbContext _context;

        public BlogAdministratorController(QuanLyNhaHangDbContext context)
        {
            _context = context;    
        }

        // GET: BlogAdministrator
        public async Task<IActionResult> Index()
        {
            return View(await _context.blogAdministrator.ToListAsync());
        }

        // GET: BlogAdministrator/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogAdministrator = await _context.blogAdministrator.SingleOrDefaultAsync(m => m.UserId == id);
            if (blogAdministrator == null)
            {
                return NotFound();
            }

            return View(blogAdministrator);
        }

        // GET: BlogAdministrator/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BlogAdministrator/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Allowed,Avatar,Email,FullName,IsAdmin,Password,UserName")] BlogAdministrator blogAdministrator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blogAdministrator);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(blogAdministrator);
        }

        // GET: BlogAdministrator/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogAdministrator = await _context.blogAdministrator.SingleOrDefaultAsync(m => m.UserId == id);
            if (blogAdministrator == null)
            {
                return NotFound();
            }
            return View(blogAdministrator);
        }

        // POST: BlogAdministrator/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,Allowed,Avatar,Email,FullName,IsAdmin,Password,UserName")] BlogAdministrator blogAdministrator)
        {
            if (id != blogAdministrator.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blogAdministrator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogAdministratorExists(blogAdministrator.UserId))
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
            return View(blogAdministrator);
        }

        // GET: BlogAdministrator/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogAdministrator = await _context.blogAdministrator.SingleOrDefaultAsync(m => m.UserId == id);
            if (blogAdministrator == null)
            {
                return NotFound();
            }

            return View(blogAdministrator);
        }

        // POST: BlogAdministrator/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blogAdministrator = await _context.blogAdministrator.SingleOrDefaultAsync(m => m.UserId == id);
            _context.blogAdministrator.Remove(blogAdministrator);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool BlogAdministratorExists(int id)
        {
            return _context.blogAdministrator.Any(e => e.UserId == id);
        }
    }
}
