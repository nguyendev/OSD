using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

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
            builder.Entity<BIENBANSUCO>().HasAlternateKey(c => c.MaBienBan);
            builder.Entity<BOPHAN>().HasAlternateKey(c => c.MaBP);
            builder.Entity<BOPHAN>().HasAlternateKey(c => c.TenBP);
            builder.Entity<CHEBIEN>().HasAlternateKey(c => new {c.MaMon, c.MaNL });
            builder.Entity<HOADONNHAPHANG>().HasAlternateKey(c => c.MaHD);
            builder.Entity<LOAIMONAN>().HasAlternateKey(c => c.MaLoaiMon);
            builder.Entity<LOAIMONAN>().HasAlternateKey(c => c.TenLoaiMon);
            builder.Entity<LOAISUCO>().HasAlternateKey(c => c.MaLoaiSuCo);
            builder.Entity<LOAISUCO>().HasAlternateKey(c => c.TenLoaiSuCo);
            builder.Entity<LUOTKHACH>().HasAlternateKey(c => c.MaLuot);
            builder.Entity<LUOTKHACH>().HasAlternateKey(c => new {c.SoBan, c.ThoiGianVao });
            builder.Entity<MONAN>().HasAlternateKey(c => c.MaMon);
            builder.Entity<MONAN>().HasAlternateKey(c => c.TenMon);
            builder.Entity<NGUYENLIEU>().HasAlternateKey(c => c.MaNL);
            builder.Entity<NGUYENLIEU>().HasAlternateKey(c => c.TenNL);
            builder.Entity<NGUYENLIEUTRONGKHO>().HasAlternateKey(c => c.MaNL);
            builder.Entity<NHACUNGCAP>().HasAlternateKey(c => c.MaNCC);
            builder.Entity<NHACUNGCAP>().HasAlternateKey(c => c.TenNCC);
            builder.Entity<NHANVIEN>().HasAlternateKey(c => c.MaNV);
            builder.Entity<NHANVIEN>().HasAlternateKey(c => new {c.TenNV,c.SoDT,c.DiaChi,c.CMND });
            //builder.Entity<PHIEUCHI>().HasAlternateKey(c => c.MaPC);
            //builder.Entity<PHIEUTHU>().HasAlternateKey(c => c.MaPT);
            builder.Entity<YEUCAUNHAPHANG>().HasAlternateKey(c => c.MaYeuCau);
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

            string usernamemanager = configuration["Data:ManagerUser:Name"];
            string emailmanager = configuration["Data:ManagertUser:Email"];
            string passwordmanager = configuration["Data:ManagerUser:Password"];
            string rolemanager = configuration["Data:ManagerUser:Role"];

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
            //Tao tai khoan manager
            if (await userManager.FindByNameAsync(usernamemanager) == null)
            {
                if (await roleManager.FindByNameAsync(rolemanager) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(rolemanager));
                }
                AppUser usermanager = new AppUser
                {
                    UserName = usernamemanager,
                    Email = emailmanager
                };
                IdentityResult result = await userManager
                .CreateAsync(usermanager, passwordmanager);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(usermanager, roleadmin);
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
        public static async Task CreateExampleQuanly(IServiceProvider serviceProvider)
        {
            SeedData.CreateExampleBophan(serviceProvider).Wait();
            SeedData.CreateExampleBienbansuco(serviceProvider).Wait();
            
            SeedData.CreateExampleDatban(serviceProvider).Wait();

        }
        // public DbSet<BlogCategory> blogCategory { get; set; }
        // public DbSet<GrantPermission> grantPermission { get; set; }
        public DbSet<BIENBANSUCO> BIENBANSUCO { get; set; }
        public DbSet<BOPHAN> BOPHAN { get; set; }
        public DbSet<CHEBIEN> CHEBIEN { get; set; }
        public DbSet<DATBAN> DATBAN { get; set; }
        public DbSet<HOADONNHAPHANG> HOADONNHAHANG { get; set; }
        public DbSet<LOAIMONAN> LOAIMONAN { get; set; }
        public DbSet<LOAISUCO> LOAISUCO { get; set; }
        public DbSet<LUOTKHACH> LUOTKHACH { get; set; }
        public DbSet<MONAN> MONAN { get; set; }
        public DbSet<NGUYENLIEU> NGUYENLIEU { get; set; }
        public DbSet<NGUYENLIEUTRONGKHO> NGUYENLIEUTRONGKHO { get; set; }
        public DbSet<NHACUNGCAP> NHACUNGCAP { get; set; }
        public DbSet<NHANVIEN> NHANVIEN { get; set; }
        public DbSet<PHANHOI> PHANHOI { get; set; }
        public DbSet<PHIEUCHI> PHIEUCHI { get; set; }
        public DbSet<PHIEUTHU> PHIEUTHU { get; set; }
        public DbSet<THIETHAI> THIETHAI { get; set; }
        public DbSet<THUCHI> THUCHI { get; set; }
        public DbSet<YEUCAUMONAN> YEUCAUMONAN { get; set; }
        public DbSet<YEUCAUNHAPHANG> YEUCAUNHAPHANG { get; set; }
    }
}
