using MatBlazor.Demo.Models;
using MatBlazor.Demo.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MatBlazor.Demo.ClientApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddTransient(sp => new HttpClient
                {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});

            builder.Services.AddSingleton<AppModel>();
            builder.Services.AddScoped<UserAppModel>();
            builder.Services.AddScoped<DemoUserService>();
            builder.Services.AddMatToaster(config =>
            {
                //example MatToaster customizations
                config.PreventDuplicates = false;
                config.NewestOnTop = true;
                config.ShowCloseButton = true;
            });

            await builder
                .Build()
                .RunAsync();
        }
    }
}