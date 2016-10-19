using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using QuanLyNhaHang.Data;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using QuanLyNhaHang.Infrastructure;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace QuanLyNhaHang
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddTransient<IPasswordValidator<AppUser>,
                    CustomPasswordValidator>();
            services.AddTransient<IUserValidator<AppUser>, CustomUserValidator>();
            services.AddTransient<IAuthorizationHandler, BlockUsersHandler>();
            services.AddTransient<IAuthorizationHandler, DocumentAuthorizationHandler>();
            services.AddAuthorization(opts => {
                opts.AddPolicy("DCUsers", policy => {
                    policy.RequireRole("Users");
                    policy.RequireClaim(ClaimTypes.StateOrProvince, "DC");
                });
                opts.AddPolicy("NotBob", policy => {
                    policy.RequireAuthenticatedUser();
                    policy.AddRequirements(new BlockUsersRequirement("Bob"));
                });
                opts.AddPolicy("AuthorsAndEditors", policy => {
                    policy.AddRequirements(new DocumentAuthorizationRequirement
                    {
                        AllowAuthors = true,
                        AllowEditors = true
                    });
                });
            });


            services.AddApplicationInsightsTelemetry(Configuration);


            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(
                Configuration["Data:QuanLyNhaHang:ConnectionString"]));
            services.AddIdentity<AppUser, IdentityRole>(opts =>
            {
                opts.Cookies.ApplicationCookie.LoginPath = "/Admin/Account/Login";
                opts.User.RequireUniqueEmail = true;
               // opts.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz";
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            })
            .AddEntityFrameworkStores<AppIdentityDbContext>();

            services.AddMvc();
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
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseStaticFiles();
            app.UseIdentity();
            app.UseClaimsTransformation(LocationClaimsProvider.AddClaims);
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

            AppIdentityDbContext.CreateAdminAccount(app.ApplicationServices, Configuration).Wait();
        }
    }
}
