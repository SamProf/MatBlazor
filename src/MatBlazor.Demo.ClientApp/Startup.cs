using System;
using System.Net.Http;
using MatBlazor.Demo.Models;
using MatBlazor.Demo.Services;
using Microsoft.Extensions.DependencyInjection;
using Toolbelt.Blazor.Extensions.DependencyInjection;

namespace MatBlazor.Demo.ClientApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services, string baseAddress)
        {
            services.AddSingleton(new HttpClient { BaseAddress = new Uri(baseAddress) });
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
#if !PREVIEW
        using Microsoft.AspNetCore.Components.Builder;
        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
            app.UseLocalTimeZone();
        }
#endif

}
}