﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace QuanLyNhaHang.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<AppUser>().ToTable("Users");
        }
        public DbSet<BlogBusiness> blogBusiness { get; set; }
        //public DbSet<BlogPost> blogPost { get; set; }
        public DbSet<BlogPermission> blogPermission { get; set; }
        // public DbSet<BlogCategory> blogCategory { get; set; }
        // public DbSet<GrantPermission> grantPermission { get; set; }
        public static async Task CreateExampleAccount(IServiceProvider serviceProvider,
            IConfiguration configuration)
        {
            UserManager<AppUser> userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string usernameadmin = configuration["Data:AdminUser:Name"];
            string emailadmin = configuration["Data:AdminUser:Email"];
            string passwordadmin = configuration["Data:AdminUser:Password"];
            string roleadmin = configuration["Data:AdminUser:Role"];

            string usernameguest = configuration["Data:GuestUser:Name"];
            string emailguest = configuration["Data:GuestUser:Email"];
            string passwordguest = configuration["Data:GuestUser:Password"];
            string roleguest = configuration["Data:GuestUser:Role"];


            //Tao tai khoan admin
            if (await userManager.FindByNameAsync(usernameadmin) == null)
            {
                if (await roleManager.FindByNameAsync(roleadmin) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleadmin));
                }
                AppUser useradmin = new AppUser
                {
                    UserName = usernameadmin,
                    Email = emailadmin
                };
                IdentityResult result = await userManager
                .CreateAsync(useradmin, passwordadmin);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(useradmin, roleadmin);
                }
            }

            //tao tai khoan khach
            if (await userManager.FindByNameAsync(usernameguest) == null)
            {
                if (await roleManager.FindByNameAsync(roleguest) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleguest));
                }
                AppUser userguest = new AppUser
                {
                    UserName = usernameguest,
                    Email = emailguest
                };
                IdentityResult result = await userManager
                .CreateAsync(userguest, passwordguest);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(userguest, roleguest);
                }
            }
        }
        // public DbSet<BlogCategory> blogCategory { get; set; }
        // public DbSet<GrantPermission> grantPermission { get; set; }
        public DbSet<BIENBANSUCO> BIENBANSUCO { get; set; }
        public DbSet<BOPHAN> BOPHAN { get; set; }
        public DbSet<CHEBIEN> CHEBIEN { get; set; }
        public DbSet<HOADONNHAPHANG> HOADONNHAHANG { get; set; }
        public DbSet<LUOTKHACH> LUOTKHACH { get; set; }
        public DbSet<MONAN> MONAN { get; set; }
        public DbSet<NGUYENLIEU> NGUYENLIEU { get; set; }
        public DbSet<NGUYENLIEUTRONGKHO> NGUYENLIEUTRONGKHO { get; set; }
        public DbSet<NHACUNGCAP> NHACUNGCAP { get; set; }
        public DbSet<NHANVIEN> NHANVIEN { get; set; }
        public DbSet<NHAPHANG> NHAPHANG { get; set; }
        public DbSet<PHIEUCHI> PHIEUCHI { get; set; }
        public DbSet<PHIEUTHU> PHIEUTHU { get; set; }
        public DbSet<SOTHUCHI> SOTHUCHI { get; set; }
        public DbSet<THIETHAI> THIETHAI { get; set; }
        public DbSet<YEUCAUMONAN> YEUCAUMONAN { get; set; }

    }
}
