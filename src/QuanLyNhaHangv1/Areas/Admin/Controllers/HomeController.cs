using Microsoft.AspNetCore.Mvc;
using QuanLyNhaHangv1.Data;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHangv1.Models.BussinessModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace QuanLyNhaHangv1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly QuanLyNhaHangDbContext _context;
        // GET: /<controller>/
        public HomeController(QuanLyNhaHangDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            string passwordMD5 = Comon.EncryptMD5(username + password);
            var user = await _context.blogAdministrator.SingleOrDefaultAsync(m => m.UserName == username && m.Password == passwordMD5 && m.Allowed == 1);
            //if (user != null)
            //{
                //Set value to session
              //  HttpContext.Session.SetString("Name", "Sourav Kayal");

                //Get Value from Session
                RedirectToAction("Index");
            //}
            ViewBag.error = "Đăng nhập sai hoặc bạn không có quyền vào";
            return View();


        }
        public IActionResult Logout()
        {
            return RedirectToAction("Login");
        }

    }
}