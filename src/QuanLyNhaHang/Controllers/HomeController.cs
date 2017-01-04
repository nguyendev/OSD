using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace QuanLyNhaHang.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index() => View();

        [Route("/gioi-thieu")]
        public IActionResult About()
        {
            return View();
        }
        [Route("/thuc-don")]
        public IActionResult Menu()
        {
            return View();
        }
        [Route("/tin-thuc")]
        public IActionResult News()
        {
            return View();
        }
        [Route("/khuyen-mai")]
        public IActionResult Khuyenmai()
        {
            return View();
        }
        [Route("/kien-thuc")]
        public IActionResult Kienthuc()
        {
            return View();
        }
        [Route("/dat-ban")]
        public IActionResult Reseration()
        {
            return View();
        }
        [Route("/phan-hoi")]
        public IActionResult Feedback()
        {
            return View();
        }
        [Route("/thuc-don/thuc-don-chi-tiet")]
        public IActionResult Menudetails()
        {
            return View();
        }
        [Route("/lien-he")]
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult NotFound()
        {
            return View();
        }
        public IActionResult Unauthorized()
        {
            return LocalRedirect("~/quan-ly/tai-khoan/dang-nhap");
        }
    }

}
