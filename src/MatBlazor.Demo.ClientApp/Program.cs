using MatBlazor.Demo.Models;
using MatBlazor.Demo.Services;
using MatBlazor.Demo.Pages;
using MatBlazor.Doc;
using MatBlazor.Doc.Demo;
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
            var services = builder.Services;
            services.AddTransient(sp => new HttpClient
                {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});


            var useDocFrameModel = Environment.GetEnvironmentVariable("USE_DOC_APPFRAME_DEMO") == "true";
            AppModel appModel = useDocFrameModel ?
                new DocFrameAppModel() :
                new MatBlazorDocumentationAppModel();

            services.AddDocApp(appModel);

            //builder.Services.AddDocApp(new AppModel(typeof(Pages.Index), DemoNavModel.Default()));
            services.AddScoped<DemoUserService>();
           

            await builder.Build().RunAsync();
        }
    }
}