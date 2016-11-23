using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhaHang.Infrastructure;
using QuanLyNhaHang.Models;

namespace QuanLyNhaHang.Areas.QuanLyWebsite.Controllers
{
    public class NhanVienController : Controller
    {
        private readonly IGenericRepository<NhanVien> _repository;

        public NhanVienController(IGenericRepository<NhanVien> repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}