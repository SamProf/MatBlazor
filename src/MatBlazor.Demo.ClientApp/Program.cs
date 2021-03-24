using MatBlazor.Demo.Models;
using MatBlazor.Demo.Services;
using MatBlazor.Doc;
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
            builder.RootComponents.Add<MatBlazor.Doc.DocApp>("app");

            builder.Services.AddTransient(sp => new HttpClient
                {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});

            
            builder.Services.AddDocApp(new AppModel(typeof(Pages.Index).Assembly, DemoNavModel.Default()));
            builder.Services.AddScoped<DemoUserService>();
           

            await builder
                .Build()
                .RunAsync();
        }
    }
}