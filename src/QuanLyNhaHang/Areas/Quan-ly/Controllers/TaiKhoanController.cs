﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http.Authentication;
using System.Security.Claims;
using QuanLyNhaHang.Models;
using QuanLyNhaHang.Areas.Admin.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace QuanLyNhaHang.Areas.Admin.Controllers
{
    [Area("Quan-ly")]
    public class TaiKhoanController : Controller
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        public TaiKhoanController(UserManager<AppUser> userMgr,
        SignInManager<AppUser> signinMgr)
        {
            _userManager = userMgr;
            _signInManager = signinMgr;
        }


        [AllowAnonymous]
        [Route("quan-ly/tai-khoan/dang-nhap")]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [Route("quan-ly/tai-khoan/dang-nhap")]
        public async Task<IActionResult> Login(LoginModel details,
            string returnUrl)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await _userManager.FindByEmailAsync(details.Email);
                if (user != null)
                {
                    await _signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result =
                    await _signInManager.PasswordSignInAsync(
                    user, details.Password, false, false);
                    if (result.Succeeded)
                    {
                        return Redirect("/quan-ly/");
                    }
                }
                ModelState.AddModelError(nameof(LoginModel.Email),
                "Invalid user or password");
            }
            return View(details);
        }

        [Authorize]
        [Route("quan-ly/tai-khoan/dang-xuat")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return LocalRedirect("~/quan-ly");
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }



        [AllowAnonymous]
        [Route("quan-ly/tai-khoan/dang-nhap-google")]
        public IActionResult GoogleLogin(string returnUrl)
        {
            string redirectUrl = Url.Action("GoogleResponse", "Account",
            new { ReturnUrl = returnUrl });
            AuthenticationProperties properties = _signInManager
            .ConfigureExternalAuthenticationProperties("Google", redirectUrl);
            return new ChallengeResult("Google", properties);
        }
        [AllowAnonymous]
        [Route("quan-ly/tai-khoan/google-phan-hoi")]
        public async Task<IActionResult> GoogleResponse(string returnUrl = "/")
        {
            ExternalLoginInfo info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return RedirectToAction(nameof(Login));
            }
            var result = await _signInManager.ExternalLoginSignInAsync(
            info.LoginProvider, info.ProviderKey, false);
            if (result.Succeeded)
            {
                return Redirect(returnUrl);
            }
            else
            {
                AppUser user = new AppUser
                {
                    Email = info.Principal.FindFirst(ClaimTypes.Email).Value,
                    UserName =
                info.Principal.FindFirst(ClaimTypes.Email).Value
                };
                IdentityResult identResult = await _userManager.CreateAsync(user);
                if (identResult.Succeeded)
                {
                    identResult = await _userManager.AddLoginAsync(user, info);
                    if (identResult.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, false);
                        return Redirect(returnUrl);
                    }
                }
                return AccessDenied();
            }
        }
    }
}
