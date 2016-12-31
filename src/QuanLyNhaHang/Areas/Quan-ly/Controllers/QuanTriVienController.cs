using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using QuanLyNhaHang.Models;
using QuanLyNhaHang.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using ImageSharp;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace QuanLyNhaHang.Areas.Admin.Controllers
{
    [Area("Quan-ly")]
    [Authorize(Roles = "Admins")]
    public class QuanTriVienController : Controller
    {
        // GET: /<controller>/
        private UserManager<AppUser> _userManager;
        private IUserValidator<AppUser> _userValidator;
        private IPasswordValidator<AppUser> _passwordValidator;
        private IPasswordHasher<AppUser> _passwordHasher;
        private IHostingEnvironment _environment;

        public QuanTriVienController(UserManager<AppUser> userManager,
            IUserValidator<AppUser> userValid,
            IPasswordValidator<AppUser> passValid,
            IPasswordHasher<AppUser> passwordHash, IHostingEnvironment environment)
        {
            _userManager = userManager;
            _userValidator = userValid;
            _passwordHasher = passwordHash;
            _passwordValidator = passValid;
            _environment = environment;
        }
        [Route("quan-ly/quan-tri-vien")]
        public ViewResult Index()
        {
            return View(_userManager.Users);
        }
        [Route("quan-ly/quan-tri-vien/tao-nguoi-dung")]
        public ViewResult Create() => View();

        [HttpPost]
        [Route("quan-ly/quan-tri-vien/tao-nguoi-dung")]
        public async Task<IActionResult> Create(CreateModel model, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                var uploads = Path.Combine(_environment.WebRootPath, "uploads");
                model.Avatar = Path.Combine(uploads, file.FileName);
                if (file.Length > 0)
                {
                    try
                    {
                        using (var fileStream = new FileStream(model.Avatar, FileMode.Create))
                        {
                            
                            Image image = new Image(file.OpenReadStream());
                            image.Resize(128,128)
                                 .Save(fileStream);
                            model.Avatar = Path.Combine("~\\uploads", file.FileName);
                            file.CopyTo(fileStream);
                        }
                    }
                    catch (Exception e)
                    {
                    }

                    


                }
                AppUser user = new AppUser
                {
                    UserName = model.Name,
                    Email = model.Email,
                    ImageUrl = model.Avatar

                };
                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            else
            {
                ModelState.AddModelError("", "User Not Found");
            }
            return View("Index", _userManager.Users);
        }
        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
        [Route("quan-ly/quan-tri-vien/chinh-sua-nguoi-dung/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(string id, string email,
        string password)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                user.Email = email;
                IdentityResult validEmail
                = await _userValidator.ValidateAsync(_userManager, user);
                if (!validEmail.Succeeded)
                {
                    AddErrorsFromResult(validEmail);
                }
                IdentityResult validPass = null;
                if (!string.IsNullOrEmpty(password))
                {
                    validPass = await _passwordValidator.ValidateAsync(_userManager,
                    user, password);
                    if (validPass.Succeeded)
                    {
                        user.PasswordHash = _passwordHasher.HashPassword(user,
                        password);
                    }
                    else
                    {
                        AddErrorsFromResult(validPass);
                    }
                }
                if ((validEmail.Succeeded && validPass == null)
                || (validEmail.Succeeded
                && password != string.Empty && validPass.Succeeded))
                {
                    IdentityResult result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        AddErrorsFromResult(result);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "User Not Found");
            }
            return View(user);
        }
        

    }
}
