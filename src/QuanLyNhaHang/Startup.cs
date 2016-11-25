using Microsoft.AspNetCore.Builder;
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
                //opts.Cookies.ApplicationCookie.LoginPath = "/QuanLyWebsite/Account/Login";
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
            services.AddScoped(typeof(IGenericRepository<NHANVIEN>), typeof(NhanVienRepository));
            services.AddScoped(typeof(IGenericRepository<NHACUNGCAP>), typeof(NhaCungCapRepository));

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

            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseGoogleAuthentication(new GoogleOptions
            {
                ClientId = "<enter client id here>",
                ClientSecret = "<enter client secret here>"
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "areaRoute",
                     template: "{area:exists}/{controller=Admin}/{action=Index}");
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            ApplicationDbContext.CreateExampleAccount(app.ApplicationServices, Configuration).Wait();
        }
    }
}
