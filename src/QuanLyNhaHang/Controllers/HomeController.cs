﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using QuanLyNhaHang.Models;
using System.ComponentModel.DataAnnotations;
using static QuanLyNhaHang.Models.AppUser;

namespace QuanLyNhaHang.Controllers
{

    public class HomeController : Controller
    {
        private UserManager<AppUser> _userManager;
        public HomeController(UserManager<AppUser> userMgr)
        {
            _userManager = userMgr;
        }



        [Authorize]
        public IActionResult Index() => View(GetData(nameof(Index)));
        [Authorize(Roles = "Users")]

        [Authorize(Policy = "DCUsers")]
        public IActionResult OtherAction() => View("Index",
        GetData(nameof(OtherAction)));
        private Dictionary<string, object> GetData(string actionName) =>
        new Dictionary<string, object>
        {
            ["Action"] = actionName,
            ["User"] = HttpContext.User.Identity.Name,
            ["Authenticated"] = HttpContext.User.Identity.IsAuthenticated,
            ["Auth Type"] = HttpContext.User.Identity.AuthenticationType,
            ["In Users Role"] = HttpContext.User.IsInRole("Users"),
            ["City"] = CurrentUser.Result.City,
            ["Qualification"] = CurrentUser.Result.Qualifications
        };

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> UserProps()
        {
            return View(await CurrentUser);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UserProps(
        [Required]Cities city,
        [Required]QualificationLevels qualifications)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await CurrentUser;
                user.City = city;
                user.Qualifications = qualifications;
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index");
            }
            return View(await CurrentUser);
        }
        private Task<AppUser> CurrentUser =>
        _userManager.FindByNameAsync(HttpContext.User.Identity.Name);


    }
}
