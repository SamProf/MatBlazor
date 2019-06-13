using MatBlazor.Demo.Models;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MatBlazor.Demo.ClientApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSingleton<AppModel>();
            services.AddScoped<UserAppModel>();
            services.AddMatToaster(config =>
            {
                //example MatToaster customizations
                config.PositionClass = MatBlazor.Position.BottomRight;
                config.PreventDuplicates = false;
                config.NewestOnTop = true;
                config.ShowCloseButton = true;
            });
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
