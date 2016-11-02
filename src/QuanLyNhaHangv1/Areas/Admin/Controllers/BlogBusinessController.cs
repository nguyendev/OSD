using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHangv1.Data;
using QuanLyNhaHangv1.Models;
using QuanLyNhaHangv1.Models.BussinessModels;

namespace QuanLyNhaHangv1.Areas.Admin.Controllers
{
    [Area("admin")]
    public class BlogBusinessController : Controller
    {
        private readonly QuanLyNhaHangDbContext _context;

        public BlogBusinessController(QuanLyNhaHangDbContext context)
        {
            _context = context;
        }

        // GET: BlogBusiness
        public async Task<IActionResult> Index()
        {
            return View(await _context.blogBusiness.ToListAsync());
        }

        // GET: BlogBusiness/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogBusiness = await _context.blogBusiness.SingleOrDefaultAsync(m => m.BussinessId == id);
            if (blogBusiness == null)
            {
                return NotFound();
            }

            return View(blogBusiness);
        }

        // GET: BlogBusiness/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BlogBusiness/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BussinessId,BusinessName")] BlogBusiness blogBusiness)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blogBusiness);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(blogBusiness);
        }

        // GET: BlogBusiness/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogBusiness = await _context.blogBusiness.SingleOrDefaultAsync(m => m.BussinessId == id);
            if (blogBusiness == null)
            {
                return NotFound();
            }
            return View(blogBusiness);
        }

        // POST: BlogBusiness/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("BussinessId,BusinessName")] BlogBusiness blogBusiness)
        {
            if (id != blogBusiness.BussinessId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blogBusiness);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogBusinessExists(blogBusiness.BussinessId))
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
            return View(blogBusiness);
        }

        // GET: BlogBusiness/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogBusiness = await _context.blogBusiness.SingleOrDefaultAsync(m => m.BussinessId == id);
            if (blogBusiness == null)
            {
                return NotFound();
            }

            return View(blogBusiness);
        }

        // POST: BlogBusiness/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var blogBusiness = await _context.blogBusiness.SingleOrDefaultAsync(m => m.BussinessId == id);
            _context.blogBusiness.Remove(blogBusiness);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool BlogBusinessExists(string id)
        {
            return _context.blogBusiness.Any(e => e.BussinessId == id);
        }



        //GET: /Business/UpdateBusiness --C?p nh?t danh s�ch nghi?p v?
        public ActionResult UpdateBusiness()
        {
            ReflectionControllerAction rc = new ReflectionControllerAction();
            List<Type> listControllerType = rc.GetControllers("Controllers");
            List<string> listControllerOld = _context.blogBusiness.Select(c => c.BussinessId).ToList();
            List<string> listPermistionOld = _context.blogPermission.Select(p => p.PermissionName).ToList();
            foreach (var c in listControllerType)
            {
                if (!listControllerOld.Contains(c.Name))
                {
                    BlogBusiness b = new BlogBusiness() { BussinessId = c.Name, BusinessName = "Ch?a c� m� t?" };
                    _context.blogBusiness.Add(b);
                }
                List<string> listPermission = rc.GetActions(c);
                foreach (var p in listPermission)
                {
                    if (!listPermistionOld.Contains(c.Name + "-" + p))
                    {
                        BlogPermission permission = new BlogPermission() { PermissionName = c.Name + "-" + p, Description = "Ch?a c� m� t?", BussinessId = c.Name };
                        _context.blogPermission.Add(permission);
                    }
                }
            }
            _context.SaveChanges();
            TempData["err"] = "<div class='alert alert-info' role='alert'><span class='glyphicon glyphicon-exclamation-sign' aria-hidden='true'></span><span class='sr-only'></span> C?p nh?t th�nh c�ng</div>";
            return RedirectToAction("Index");
        }
    }
}