using Microsoft.Extensions.DependencyInjection;

namespace ITMS.External.MatBlazor
{
    public static class MatServiceCollectionExtension
    {
        public static void AddMatBlazor(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IMatPortalService, MatPortalService>();
            serviceCollection.AddScoped<IMatDialogService, MatDialogService>();
        }
    }
}