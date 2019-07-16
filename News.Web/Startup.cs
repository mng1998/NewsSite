using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using News.Web.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using News.BusinessLayer.Services;
using News.DataLayer.SharedKernel;
using News.DataLayer.Repositories;
using News.BusinessLayer;
using Microsoft.AspNetCore;
using System.IO;
using System.Collections.Generic;
using News.Core.Context;
using News.Common.Const;

namespace News.Web
{
    public class Startup    {
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            this.RegisterAppInfo();

            // Dependency injection.
            services.AddSingleton<IDbFactory, DbFactory>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserRoleService, UserRoleService>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();

            // Automapper config
            AutomapperConfig.Initialize();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>()
              .AddEntityFrameworkStores<ApplicationDbContext>()
              .AddDefaultTokenProviders();

            services.AddMvc().AddRazorPagesOptions(options =>
            {
                options.Conventions.AuthorizePage("/test1", "OnlyAdminAccess");


            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddAuthorization(options =>
            {
                options.AddPolicy("OnlyAdminAccess", policy => policy.RequireRole("Admin"));
            });
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>WebHost.CreateDefaultBuilder(args)
        .UseKestrel()
        .UseContentRoot(Directory.GetCurrentDirectory())
        .UseConfiguration(new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true)
        .Build())
        .UseStartup<Startup>();
        /// <summary>
        /// Register application info.
        /// </summary>
        private void RegisterAppInfo()
        {
            GlobalContext.Instance.ConnectionString = this.Configuration.GetConnectionString(AppConst.DefaultConnection);
            GlobalContext.Instance.EntityNamespace = this.Configuration.GetValue<string>(AppConst.EntityNamespace);
            GlobalContext.Instance.DisappearTable = this.GetArrayItem(AppConst.DisappearTable);
        }

        private IEnumerable<string> GetArrayItem(string sectionName)
        {
            IConfigurationSection myArraySection = this.Configuration.GetSection(sectionName);
            var itemArray = myArraySection.AsEnumerable();
            foreach(KeyValuePair<string, string> item in itemArray)
            {
                if(Equals(item.Value, null))
                {
                    continue;
                }

                yield return item.Value;
            }
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseStatusCodePagesWithReExecute("/Error/{0}");
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "area",
                template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
          
        }
        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            //initializing custom roles 
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            string[] roleNames = { "Admin", "User", "HR" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    //create the roles and seed them to the database: Question 1
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            IdentityUser user = await UserManager.FindByEmailAsync("jignesh@gmail.com");

            if (user == null)
            {
                user = new IdentityUser()
                {
                    UserName = "jignesh@gmail.com",
                    Email = "jignesh@gmail.com",
                };
                await UserManager.CreateAsync(user, "Test@123");
            }
            await UserManager.AddToRoleAsync(user, "Admin");

            IdentityUser user0 = await UserManager.FindByEmailAsync("uyenphuong123@gmail.com");

            if (user == null)
            {
                user = new IdentityUser()
                {
                    UserName = "uyenphuong123@gmail.com",
                    Email = "uyenphuong123@gmail.com",
                };
                await UserManager.CreateAsync(user, "May123@");
            }
            await UserManager.AddToRoleAsync(user, "Admin");

            IdentityUser user1 = await UserManager.FindByEmailAsync("tejas@gmail.com");

            if (user1 == null)
            {
                user1 = new IdentityUser()
                {
                    UserName = "tejas@gmail.com",
                    Email = "tejas@gmail.com",
                };
                await UserManager.CreateAsync(user1, "Test@123");
            }
            await UserManager.AddToRoleAsync(user1, "User");

            IdentityUser user2 = await UserManager.FindByEmailAsync("rakesh@gmail.com");

            if (user2 == null)
            {
                user2 = new IdentityUser()
                {
                    UserName = "Phuong123@gmail.com",
                    Email = "Phuong123@gmail.com",
                };
                await UserManager.CreateAsync(user2, "Test@123");
            }
            await UserManager.AddToRoleAsync(user2, "HR");

        }
    }
}
