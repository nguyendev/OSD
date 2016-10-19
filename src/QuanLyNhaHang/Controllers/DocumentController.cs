using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhaHang.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace QuanLyNhaHang.Controllers
{
    public class DocumentController : Controller
    {
        private ProtectedDocument[] docs = new ProtectedDocument[] {
                new ProtectedDocument { Title = "Q3 Budget", Author = "Alice",
                    Editor = "Joe"},
                new ProtectedDocument { Title = "Project Plan", Author = "Bob",
                    Editor = "Alice"}
        };

        private IAuthorizationService authService;
        public DocumentController(IAuthorizationService auth)
        {
            authService = auth;
        }
        public async Task<IActionResult> Edit(string title)
        {
            ProtectedDocument doc = docs.FirstOrDefault(d => d.Title == title);
            bool authorized = await authService.AuthorizeAsync(User,
            doc, "AuthorsAndEditors");
            if (authorized)
            {
                return View("Index", doc);
            }
            else
            {
                return new ChallengeResult();
            }
        }
        public ViewResult Index() => View(docs);
        public ViewResult Edit(string title)
        {
            return View("Index", docs.FirstOrDefault(d => d.Title == title));
        }
    }
}
