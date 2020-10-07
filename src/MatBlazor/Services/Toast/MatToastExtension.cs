using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace MatBlazor
{
    public static class MatToastExtension
    {
        /// <summary>
        /// Adds a singleton <see cref="IMatToaster"/> instance to the DI <see cref="IServiceCollection"/> with the specified <see cref="MatToastConfiguration"/>
        /// </summary>
        public static IServiceCollection AddMatToaster(this IServiceCollection services, MatToastConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }
            services.TryAddScoped<IMatToaster>(builder => new MatToaster(configuration));
            return services;
        }

        /// <summary>
        /// Adds a singleton <see cref="IMatToaster"/> instance to the DI <see cref="IServiceCollection"/> with the default <see cref="MatToastConfiguration"/>
        /// </summary>
        public static IServiceCollection AddMatToaster(this IServiceCollection services)
        {
            return AddMatToaster(services, new MatToastConfiguration());
        }

        /// <summary>
        /// Adds a singleton <see cref="IMatToaster"/> instance to the DI <see cref="IServiceCollection"/> with an action for configuring the default <see cref="MatToastConfiguration"/>
        /// </summary>
        public static IServiceCollection AddMatToaster(this IServiceCollection services,
            Action<MatToastConfiguration> configure)
        {
            if (configure == null)
            {
                throw new ArgumentNullException(nameof(configure));
            }

            var options = new MatToastConfiguration();
            configure(options);

            return AddMatToaster(services, options);
        }
    }
}