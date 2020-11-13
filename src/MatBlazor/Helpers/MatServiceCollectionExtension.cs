using Microsoft.Extensions.DependencyInjection;

namespace MatBlazor
{
    public static class MatServiceCollectionExtension
    {
        public static void AddMatBlazor(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IMatDialogService, MatDialogService>();
        }
    }
}