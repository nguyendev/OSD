using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QuanLyNhaHang.Data;
using QuanLyNhaHang.Areas.Quan_ly.ViewModels;

namespace QuanLyNhaHang.Areas.Quanly.Controllers
{
    [Area("Quan-ly")]
    [Authorize]
    public class TrangChuController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrangChuController(ApplicationDbContext context)
        {
            _context = context;
        }


        [Route("quan-ly")]
        public IActionResult Index()
        {
            DashboardViewModels vm = new DashboardViewModels();
            vm._datban = _context.DATBAN.Where(p => p.TrangThaiDuyet == "A" && p.TrangThai == "1").ToList();
            int temp1 = _context.UserRoles.Where((p => p.RoleId == _context.Roles.Where(e => e.Name == "Admins").SingleOrDefault().Id)).Count();
            int temp2 = _context.UserRoles.Where((p => p.RoleId == _context.Roles.Where(e => e.Name == "Collaborator").SingleOrDefault().Id)).Count();
            vm._countManager = temp1 + temp2;
            vm._member = _context.Users.ToList();
            return View(vm);
        }

        //public JsonResult GetCalendarEvents()
        //{
        //    var eventDetails = _context.DATBAN.Where(o => o.TrangThaiDuyet.Contains("A") && o.TrangThai.Contains("1")).ToList();
        //    eventDetails.Where(p => Convert.ToDateTime(p.Ngay) == ).Count();
        //    var eventList = from item in eventDetails
        //                    select new
        //                    {
        //                        id = item.Id,
        //                        title = item.,
        //                        start = item.NgayTao,
        //                        end = item.NgayDuyet,
        //                        allDay = true,
        //                        editable = false,
        //                        color = ConsoleColor.DarkCyan,
        //                    };

        //    return Json(eventList.ToArray());
        //}
    }
}