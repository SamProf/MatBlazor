using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EmbeddedBlazorContent;
using MatBlazor.Demo.Models;
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
using MatBlazor.DependencyInjection;
using MatBlazor.Services.Toast;

namespace MatBlazor.Demo.ServerApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<HttpClient>();
            services.AddSingleton<AppModel>();
            services.AddScoped<UserAppModel>();
            services.AddRazorPages();
            services.AddServerSideBlazor().AddSignalR().AddHubOptions<ComponentHub>(o =>
            {
                o.MaximumReceiveMessageSize = 1024 * 1024 * 100;
            });
            //services.AddServerSideBlazor();

            services.AddMatToaster(config =>
            {
                //example MatToaster customizations
                config.PositionClass = MatBlazor.MatToaster.Helpers.Position.BottomRight;
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


            app.UseEmbeddedBlazorContent(typeof(MatBlazor.BaseMatDomComponent).Assembly);

            app.UseEmbeddedBlazorContent(typeof(MatBlazor.Demo.Pages.Index).Assembly);

            app.UseRouting();


            app.UseSignalR(route => route.MapHub<ComponentHub>(ComponentHub.DefaultPath, o =>
            {
                o.ApplicationMaxBufferSize = 1024 * 1024 * 100; // larger size
                o.TransportMaxBufferSize = 1024 * 1024 * 100; // larger size
            }));


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}