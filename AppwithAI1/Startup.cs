using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AppwithAI1.Data;
using static AppwithAI1.Pages.UploadJsonModel;

namespace AppwithAI1
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
            services.AddRazorPages();

            var connectionString = Configuration.GetConnectionString("AppwithAI1ContextConnection") ?? throw new InvalidOperationException("Connection string 'AppwithAI1ContextConnection' not found.");
            services.AddDbContext<AppwithAI1Context>(options =>
                options.UseSqlServer(connectionString));

            services.AddDefaultIdentity<AppwithAI1.Areas.Identity.Data.AppwithAI1User>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<AppwithAI1Context>();

            services.AddTransient<UploadJsonPageModel>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
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
                endpoints.MapRazorPages();
            });
        }
    }
}
