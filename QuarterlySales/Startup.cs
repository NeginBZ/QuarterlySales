using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using QuarterlySales.Models;
using Microsoft.AspNetCore.Identity; // add here

namespace QuarterlySales
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }



        public IConfiguration Configuration { get; }



        // Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting(options => {
                options.LowercaseUrls = true;
                options.AppendTrailingSlash = true;
            });



            services.AddMemoryCache();
            services.AddSession();


            services.AddControllersWithViews().AddNewtonsoftJson();
            services.AddDbContext<SalesContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("SalesContext")));

            //PasswordConfiguration
            services.AddIdentity<User, IdentityRole>(option =>
            {
                option.Password.RequiredLength = 6;
                option.Password.RequireUppercase = true;
            }).AddEntityFrameworkStores<SalesContext>().AddDefaultTokenProviders();
        }



        // Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "pagesortfilter",
                pattern: "{controller=Home}/{action=Index}/page/{pagenumber}/size/{pagesize}/sort/{sortfield}/{sortdirection}/filterby/employee-{employee}/year-{year}/qtr-{quarter}");

                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            SalesContext.CreateAdminUser(app.ApplicationServices).Wait();
        }
    }
}

