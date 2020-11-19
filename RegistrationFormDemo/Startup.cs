using System.Diagnostics;
using System.IO;
using RegistrationFormDemo.Models.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Email;

namespace RegistrationFormDemo
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var file = File.CreateText(_configuration.GetSection("SerilogFail").Value);
            var writer = TextWriter.Synchronized(file);

            Serilog.Debugging.SelfLog.Enable(msg => {
                Debug.WriteLine(msg);
                writer.WriteLine(msg);
                writer.Flush();
            });

            //configure serilog
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(_configuration)
                                                 .Enrich.FromLogContext() 
                                                 .CreateLogger();





            Log.Information("****STARTING*****");

            services.AddControllersWithViews();
            services.AddDbContext<RegistrationDemoContext>(
               options => options.UseSqlServer(_configuration.GetConnectionString("RegistrationDemoEntities"))
               );

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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
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
