using MatBlazor;
using MatBlazor.Demo.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public static class ServiceExtensions
    {
        public static void AddDocApp(this IServiceCollection services, AppModel appModel)
        {
            services.AddMatBlazor();
            services.AddSingleton(_ => appModel);
            services.AddSingleton(sp => appModel.NavModel);

        services.AddScoped<UserAppModel>();
            services.AddMatToaster(config =>
            {
                //example MatToaster customizations
                config.PreventDuplicates = false;
                config.NewestOnTop = true;
                config.ShowCloseButton = true;
            });
        }

      

    }
