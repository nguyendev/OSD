using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace QuanLyNhaHang.Areas.Quanly.Controllers
{
    [Area("Quan-ly")]
    [Authorize]
    public class TrangChuController : Controller
    {
        [Route("quan-ly")]
        public IActionResult Index()
        {
            return View();
        }
    }
}