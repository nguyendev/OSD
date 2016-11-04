using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHangv1.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuanLyNhaHangv1.Models;
using QuanLyNhaHangv1.Models.DataModels;

namespace QuanLyNhaHangv1.Areas.Admin.Controllers
{
    [Area("admin")]
    public class BlogGrantPermissionController : Controller
    {
        private readonly QuanLyNhaHangDbContext _context;
        public BlogGrantPermissionController(QuanLyNhaHangDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int id)
        {
            //L?y t?t c? nghi?p v? (controller) trong csdl
            var listcontrol = _context.blogBusiness.AsEnumerable();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in listcontrol)
            {
                items.Add(new SelectListItem() { Text = item.BusinessName, Value = item.BusinessCode });
            }
            //L?u ra bi?n
            ViewBag.items = items;

            //L?y danh sách quy?n ???c c?p
            var listgranted = from g in _context.grantPermission
                              join p in _context.blogPermission on g.PermissionId equals p.PermissionId
                              where g.UserId == id
                              select new SelectListItem() { Value = p.PermissionId.ToString(), Text = p.Description };

            //L?u ra bi?n
            ViewBag.listgranted = listgranted;
            //L?u id c?a ng??i dùng ?ang ???c c?p ra

            //Session["usergrant"] = id;
            //L?y ng??i dùng
            var temp = _context.blogAdministrator.Single(x => x.UserId == id);
            //L?u tên ra bi?n
            ViewBag.usergrant = temp.UserName + "(" + temp.FullName + ")";
            return View();
        }

        public JsonResult getPermissions(string id, int usertemp)
        {
            //l?y t?t c? các permission c?a user và c?a bussiness
            var listgranted = (from g in _context.grantPermission
                               join p in _context.blogPermission on g.PermissionId equals p.PermissionId
                               where g.UserId == usertemp && p.BussinessCode == id
                               select new PermissionAction { PermissionId = p.PermissionId, PermissionName = p.PermissionName, Description = p.Description, IsGranted = true}).ToList();
            //l?y t?t c? các permission c?a business hi?n t?i
            var listpermission = from p in _context.blogPermission
                                 where p.BussinessCode == id
                                 select new PermissionAction { PermissionId = p.PermissionId, PermissionName = p.PermissionName, Description = p.Description, IsGranted = false };
            //l?y các id c?a permission ?ã ???c gán cho ng??i dùng
            var listpermissionId = listgranted.Select(p => p.PermissionId);

            //so sánh ki?m xem permissionid nào c?a business mà ch?a có trong listgrant thì ??a vào (isGrant = false)
            foreach (var item in listpermission)
            {
                if (!listpermissionId.Contains(item.PermissionId))
                    listgranted.Add(item);
            }
            return Json(listgranted.OrderBy(x => x.Description));
                        
        }

        public string updatePermission(int id, int usertemp)
        {
            string msg = "";
            var grant = _context.grantPermission.Single(x => x.UserId == id && x.PermissionId == usertemp);
            if (grant == null)
            {
                GrantPermission g = new GrantPermission() { PermissionId = id, UserId = usertemp, Description =""};
                _context.grantPermission.Add(g);
                msg = "<div class='alert alert-success'>Quy?n c?p thành công</div>";
            }
            else
            {
                _context.grantPermission.Remove(grant);
                msg = "<div class='alert alert-danger'>Quy?n h?y thành công</div>";
            }
            _context.SaveChanges();
            return msg;
        }
    }
}