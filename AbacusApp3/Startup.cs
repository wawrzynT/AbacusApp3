using AbacusApp3.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbacusApp3
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

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();


            services.AddAuthentication()
                .AddGoogle(options =>
            {
                IConfigurationSection googleAuthNSection =
                Configuration.GetSection("Authentication:Google");

                options.ClientId = googleAuthNSection["ClientId"];
                options.ClientSecret = googleAuthNSection["ClientSecret"];
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
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

            MyIdentityDataInitializer.SeedData(userManager, roleManager);


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Ksiegowanie3}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });


        }
    }

    internal class MyIdentityDataInitializer
    {
        public static void SeedData(UserManager<IdentityUser> userManager,
RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }
        // name - poprawny adres email
        // password - min 8 znaków, ma³a i du¿a litera, cyfra i znak specjalny
        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Admin",
                };
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync("Owner").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Owner",
                };
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Rentier").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Rentier",
                };
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
        }

        public static void SeedOneUser(UserManager<IdentityUser> userManager,
        string name, string password, string role = null)
        {
            if (userManager.FindByNameAsync(name).Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = name, // musi byæ taki sam jak email, inaczej nie zadzia³a
                    Email = name
                };
                IdentityResult result = userManager.CreateAsync(user, password).Result;
                if (result.Succeeded && role != null)
                {
                    userManager.AddToRoleAsync(user, role).Wait();
                }
            }
        }
        public static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            SeedOneUser(userManager, "normaluser@localhost", "nUpass1!");
            SeedOneUser(userManager, "wawrzyn.t@gmail2.com", "aUpass1!",  "Admin");
            SeedOneUser(userManager, "owneruser@localhost", "oUpass1!", "Owner");
            SeedOneUser(userManager, "rentieruser@localhost", "rUpass1!", "Rentier");
        }
    }

}
