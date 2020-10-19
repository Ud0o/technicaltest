using JustEatTechnicalTest.Services.Interfaces;
using JustEatTechnicalTest.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Text;
using System.Net.Http.Headers;

namespace JustEatTechnicalTest
{
    public class Startup
    {
        private readonly string _username;
        private readonly string _password;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _username = configuration["Credentials:Username"];
            _password = configuration["Credentials:Password"];
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddControllersWithViews();
            services.AddScoped<ISearchService, SearchService>();

            services.AddHttpClient("justeat", c =>
            {
                c.BaseAddress = new Uri("https://public.je-apis.com");
              
                c.DefaultRequestHeaders.Add("Accept-Tenant", "uk");
                c.DefaultRequestHeaders.Add("Accept-Language", "en-GB");
                c.DefaultRequestHeaders.Add("Host", "public.je-apis.com");

                c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue
                ("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_username}:{_password}")));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();
            //Commented out so the exe can be run locally
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
