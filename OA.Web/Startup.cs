using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OA.Core.Data;
using OA.Core.Dto;
using OA.Core.Models;
using OA.Repository;
using OA.Repository.Interfaces;
using OA.Services;
using OA.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace OA.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 1;


            }).AddEntityFrameworkStores<ApplicationDbContext>(); ;

            services.AddControllersWithViews()
                .AddViewLocalization().AddRazorRuntimeCompilation();


            // localization middleware
            services.AddLocalization(options =>
            {
                options.ResourcesPath = "Resources";
            });

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("ar-EG");
                var cultures = new CultureInfo[]
                {
                    new CultureInfo("ar-EG"),
                    new CultureInfo("en-US")
                    //new CultureInfo("fr-FR")
                };

                options.SupportedCultures = cultures;
                options.SupportedUICultures = cultures;
            });

            /////////////////////

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            #region Service Injected
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IOrderRepository, OrderRepository>();


            services.AddTransient<IOrderService, OrderService>();

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRequestLocalization();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

// Auto data migration
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetService<ApplicationDbContext>().Database.Migrate();

                var userManager = scope.ServiceProvider.GetService<UserManager<IdentityUser>>();
                var user = userManager.FindByNameAsync("admin@oa.com").Result;
                if (user == null)
                {
                    user = new IdentityUser
                    {
                        UserName = "admin@oa.com",
                        Email = "admin@oa.com",

                    };
                    var result = userManager.CreateAsync(user, "admin").Result;

                    // add data
                    IOrderService _orderService = scope.ServiceProvider.GetService<IOrderService>();
                    _orderService.Insert(
                            new OrderDto { Customer = "Sayed", Phone = 01224906035,
                                OrderDetails = new OrderDetailDto[]
                            {
                                new OrderDetailDto{ItemNo="item 1",Description="desc 1",Quantity=1,Price=10 },
                                new OrderDetailDto{ItemNo="item 2",Description="desc 2",Quantity=2,Price=20 },
                                new OrderDetailDto{ItemNo="item 3",Description="desc 3",Quantity=2,Price=30 },

                            } });

                    _orderService.Insert(
                            new OrderDto
                            {
                                Customer = "Allam",
                                Phone = 01224906035,
                                OrderDetails = new OrderDetailDto[]
                            {
                                new OrderDetailDto{ItemNo="item 10",Description="desc 10",Quantity=1,Price=10 },
                                new OrderDetailDto{ItemNo="item 20",Description="desc 20",Quantity=2,Price=20 },
                                new OrderDetailDto{ItemNo="item 30",Description="desc 30",Quantity=2,Price=30 },

                            }
                            });


                }


            }

        }
    }
}
