using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MatBlazor.Demo.App
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Since Blazor is running on the server, we can use an application service
            // to read the forecast data.
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
