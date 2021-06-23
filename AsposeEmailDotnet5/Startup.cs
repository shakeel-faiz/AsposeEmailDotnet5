using AsposeEmailDotnet5.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AsposeEmailDotnet5
{
    public class Startup
    {
        public static IWebHostEnvironment WebHostEnvironment { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession();

            services.AddControllersWithViews();
            services.AddHttpContextAccessor();
            services.AddTransient<IAsposeEmailCloudApiService, AsposeEmailCloudApiService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            WebHostEnvironment = env;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "AsposeConversionRoute",
                    pattern: "{product}/Conversion",
                    defaults: new { controller = "Conversion", action = "Conversion" }
                    );

                endpoints.MapControllerRoute(
                    name: "AsposeTest",
                    pattern: "{product}/Test",
                    defaults: new { controller = "Test", action = "Conversion" }
                    );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
