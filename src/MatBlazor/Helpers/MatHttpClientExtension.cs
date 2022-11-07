using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ITMS.External.MatBlazor
{
    public static class MatHttpClientExtension
    {
        public static async Task<T> GetJsonAsync<T>(this HttpClient httpClient, string requestUri)
        {
            var stringContent = await httpClient.GetStringAsync(requestUri);

            return JsonSerializer.Deserialize<T>(stringContent, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        }
    }
}