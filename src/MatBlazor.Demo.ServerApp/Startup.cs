using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MatBlazor.Demo.Models;
using MatBlazor.Demo.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.FileProviders.Embedded;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Primitives;

namespace MatBlazor.Demo.ServerApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<HttpClient>();
            services.AddRazorPages();
            services.AddServerSideBlazor(c =>
            {
                //c.MaxBufferedUnacknowledgedRenderBatches = Int32.MaxValue;
                c.DetailedErrors = true;
            });
            services.AddSignalR(c =>
            {
                c.EnableDetailedErrors = true;
                c.StreamBufferCapacity = Int32.MaxValue;
                c.MaximumReceiveMessageSize = long.MaxValue;
                
            });



            services.AddSingleton<AppModel>();
            services.AddScoped<UserAppModel>();
            services.AddScoped<DemoUserService>();
            services.AddMatToaster(config =>
            {
                //example MatToaster customizations
                config.PreventDuplicates = false;
                config.NewestOnTop = true;
                config.ShowCloseButton = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();

            app.UseStaticFiles();


//            app.UseEmbeddedBlazorContent(typeof(MatBlazor.BaseMatDomComponent).Assembly);
//
//            app.UseEmbeddedBlazorContent(typeof(MatBlazor.Demo.Pages.Index).Assembly);

            app.UseRouting();


          


            
            app.UseEndpoints(endpoints =>
            {
                
                endpoints.MapBlazorHub(c =>
                {
                    c.ApplicationMaxBufferSize = long.MaxValue;
                    c.TransportMaxBufferSize = long.MaxValue;
                });
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}