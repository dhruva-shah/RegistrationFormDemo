using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using MHS.P4.OnlineReferrals.Models;
using MHS.P4.OnlineReferrals.Models.Database;
using MHS.P4.OnlineReferrals.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Email;

namespace MHS.P4.OnlineReferrals
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
                .WriteTo.Email(
                    new EmailConnectionInfo()
                    {
                        FromEmail = "it@patientcaresolutions.com",
                        ToEmail = "dshah@patientcaresolutions.com",
                        MailServer = "192.168.80.249",
                        Port = 25,
                        EnableSsl = false,
                        EmailSubject = "P4 Online Referrals error",
                        ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => true
                    },
                    outputTemplate: "[[{Timestamp:HH:mm:ss} {Level} {MachineName} {EnvironmentUserName}] {Message}{NewLine}{Exception}]",
                    restrictedToMinimumLevel: LogEventLevel.Error,
                    batchPostingLimit: 100
                ).CreateLogger();





            Log.Information("****STARTING*****");

            services.AddControllersWithViews();
            services.AddDbContext<P4OnlineReferralsContext>(
               options => options.UseSqlServer(_configuration.GetConnectionString("P4OnlineReferralsEntities"))
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
