using System;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MatBlazor.Components.MatToast;
using Microsoft.Extensions.DependencyInjection;
using MatBlazor.Services.Toast;

namespace MatBlazor.DependencyInjection
{
    public static class MatToastExtension
    {
        /// <summary>
        /// Adds a singleton <see cref="IBaseMatToastContainer"/> instance to the DI <see cref="IServiceCollection"/> with the specified <see cref="Configuration"/>
        /// </summary>
        public static IServiceCollection AddMatToaster(this IServiceCollection services, Configuration configuration)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));
            services.TryAddScoped<IBaseMatToastContainer>(builder => new MatBlazor.Services.Toast.MatToaster(configuration));
            return services;
        }

        /// <summary>
        /// Adds a singleton <see cref="IBaseMatToastContainer"/> instance to the DI <see cref="IServiceCollection"/> with the default <see cref="Configuration"/>
        /// </summary>
        public static IServiceCollection AddMatToaster(this IServiceCollection services)
        {
            return AddMatToaster(services, new Configuration());
        }

        /// <summary>
        /// Adds a singleton <see cref="IBaseMatToastContainer"/> instance to the DI <see cref="IServiceCollection"/> with an action for configuring the default <see cref="Configuration"/>
        /// </summary>
        public static IServiceCollection AddMatToaster(this IServiceCollection services, Action<Configuration> configure)
        {
            if (configure == null) throw new ArgumentNullException(nameof(configure));

            var options = new Configuration();
            configure(options);

            return AddMatToaster(services, options);
        }
    }
}
