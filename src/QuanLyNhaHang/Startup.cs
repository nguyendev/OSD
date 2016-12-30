﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using QuanLyNhaHang.Data;
using QuanLyNhaHang.Models;
using QuanLyNhaHang.Services;
using QuanLyNhaHang.Infrastructure;
using Microsoft.AspNetCore.Http;

namespace QuanLyNhaHang
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();

                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           // services.AddTransient<IPasswordValidator<AppUser>, CustomPasswordValidator>();
          //  services.AddTransient<IUserValidator<AppUser>, CustomUserValidator>();
            //services.AddTransient<IAuthorizationHandler, BlockUsersHandler>();
            //services.AddTransient<IAuthorizationHandler, DocumentAuthorizationHandler>();
            //services.AddAuthorization(opts => {
            //    opts.AddPolicy("DCUsers", policy => {
            //        policy.RequireRole("Users");
            //        policy.RequireClaim(ClaimTypes.StateOrProvince, "DC");
            //    });
            //    opts.AddPolicy("NotBob", policy => {
            //        policy.RequireAuthenticatedUser();
            //        policy.AddRequirements(new BlockUsersRequirement("Bob"));
            //    });
            //    opts.AddPolicy("AuthorsAndEditors", policy => {
            //        policy.AddRequirements(new DocumentAuthorizationRequirement
            //        {
            //            AllowAuthors = true,
            //            AllowEditors = true
            //        });
            //    });
            //});

            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddIdentity<AppUser, IdentityRole>()
                 .AddEntityFrameworkStores<ApplicationDbContext>()
                 .AddDefaultTokenProviders();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                Configuration["Data:QuanLyNhaHang:ConnectionString"]));
            services.AddIdentity<AppUser, IdentityRole>(opts =>
            {

                opts.Cookies.ApplicationCookie.LoginPath = "/Quan-Ly/Account/Login";
                //opts.User.RequireUniqueEmail = true;
                //// opts.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz";
                //opts.Password.RequiredLength = 6;
                //opts.Password.RequireNonAlphanumeric = false;
                //opts.Password.RequireLowercase = false;
                //opts.Password.RequireUppercase = false;
                //opts.Password.RequireDigit = false;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddMvc();

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
            services.AddScoped(typeof(IGenericRepository<BIENBANSUCO>), typeof(BienBanSuCoRepository));
            services.AddScoped(typeof(IGenericRepository<BOPHAN>), typeof(BoPhanRepository));
            services.AddScoped(typeof(IGenericRepository<CHEBIEN>), typeof(CheBienRepository));
            services.AddScoped(typeof(IGenericRepository<DATBAN>), typeof(DatBanRepository));
            services.AddScoped(typeof(IGenericRepository<HOADONNHAPHANG>), typeof(HoaDonNhapHangRepository));
            services.AddScoped(typeof(IGenericRepository<LOAIMONAN>), typeof(LoaiMonAnRepository));
            services.AddScoped(typeof(IGenericRepository<LOAISUCO>), typeof(LoaiSuCoRepository));
            services.AddScoped(typeof(IGenericRepository<LUOTKHACH>), typeof(LuotKhachRepository));
            services.AddScoped(typeof(IGenericRepository<MONAN>), typeof(MonAnRepository));
            services.AddScoped(typeof(IGenericRepository<NGUYENLIEU>), typeof(NguyenLieuRepository));
            services.AddScoped(typeof(IGenericRepository<NGUYENLIEUTRONGKHO>), typeof(NguyenLieuTrongKhoRepository));
            services.AddScoped(typeof(IGenericRepository<NHACUNGCAP>), typeof(NhaCungCapRepository));
            services.AddScoped(typeof(IGenericRepository<NHANVIEN>), typeof(NhanVienRepository));
            services.AddScoped(typeof(IGenericRepository<PHANHOI>), typeof(PhanHoiRepository));
            services.AddScoped(typeof(IGenericRepository<PHIEUCHI>), typeof(PhieuChiRepository));
            services.AddScoped(typeof(IGenericRepository<PHIEUTHU>), typeof(PhieuThuRepository));
            services.AddScoped(typeof(IGenericRepository<THIETHAI>), typeof(ThietHaiRepository));
            services.AddScoped(typeof(IGenericRepository<THUCHI>), typeof(ThuChiRepository));
            services.AddScoped(typeof(IGenericRepository<YEUCAUMONAN>), typeof(YeuCauMonAnRepository));
            services.AddScoped(typeof(IGenericRepository<YEUCAUNHAPHANG>), typeof(YeuCauNhapHangRepository));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseStatusCodePages();
            app.UseDeveloperExceptionPage();
            app.UseApplicationInsightsRequestTelemetry();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseStaticFiles();

            app.UseIdentity();
            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404)
                {
                    context.Request.Path = "/Home/NotFound";
                    await next();
                }
                if (context.Response.StatusCode == 401)
                {
                    context.Request.Path = "/Home/Unauthorized";
                    await next();
                }
            });
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationScheme = "MyCookies",
                SlidingExpiration = true,
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                LoginPath = new PathString("/quan-ly/tai-khoan/dang-nhap")
            });
            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseGoogleAuthentication(new GoogleOptions
            {
                ClientId = "<enter client id here>",
                ClientSecret = "<enter client secret here>"
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "areaRoute",
                     template: "{area:exists}/{controller=Trangchu}/{action=Index}");
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            ApplicationDbContext.CreateExampleAccount(app.ApplicationServices, Configuration).Wait();
            ApplicationDbContext.CreateExampleQuanly(app.ApplicationServices).Wait();
        }
    }
}
