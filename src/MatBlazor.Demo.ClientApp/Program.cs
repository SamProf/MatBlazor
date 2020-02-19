using MatBlazor.Demo.Models;
using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using MatBlazor.Demo.Services;
using Toolbelt.Blazor.Extensions.DependencyInjection;

namespace MatBlazor.Demo.ClientApp
{
#if !PREVIEW
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IWebAssemblyHostBuilder CreateHostBuilder(string[] args) =>
            BlazorWebAssemblyHost.CreateDefaultBuilder()
                .UseBlazorStartup<Startup>();
    }
#else
    public class Program
        {
            public static async Task Main(string[] args)
            {
                var builder = WebAssemblyHostBuilder.CreateDefault(args);
                builder.RootComponents.Add<App>("app");
    
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
                .UseLocalTimeZone()
                .RunAsync();
    
            }
        }
#endif
}