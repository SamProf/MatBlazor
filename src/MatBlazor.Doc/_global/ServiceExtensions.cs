using MatBlazor;
using MatBlazor.Demo.Models;
using MatBlazor.DevUtils.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


    public static class ServiceExtensions
    {
        public static void AddDocApp(this IServiceCollection services, AppModel appModel)
        {
            services.AddMatBlazor();
            services.AddSingleton(_ => appModel);
            services.AddSingleton(sp => appModel.NavModel);

         var generatorCache = new ConcurrentDictionary<string, AssemblyDocumentationGenerator>();

        services.AddSingleton(_ => new Func<Assembly, AssemblyDocumentationGenerator>(a => generatorCache.GetOrAdd(
            a.FullName, aa => new AssemblyDocumentationGenerator(a, appModel.AppAssembly))));

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
