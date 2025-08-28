using System.Net.Http.Headers;
using System.Text.Json;

namespace GeekShopping.Web.Utils
{
    public static class HttpClientExtensions
    {
        private static MediaTypeHeaderValue contentType = new MediaTypeHeaderValue("application/json");

        public static async Task<T> ReadContentAs<T>(this HttpResponseMessage responseMessage)
        {
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonSerializer.Deserialize<T>(responseData, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            else
            {
                throw new ApplicationException($"Request failed with status code: {responseMessage.StatusCode}");
            }
        }

        public static Task<HttpResponseMessage> PostAsJson<T>(this HttpClient httpClient, string url, T data)
        {
            var content = JsonSerializer.Serialize(data);
            var stringContent = new StringContent(content);
            stringContent.Headers.ContentType = contentType;
            return httpClient.PostAsync(url, stringContent);
        }

        public static Task<HttpResponseMessage> PutAsJson<T>(this HttpClient httpClient, string url, T data)
        {
            var content = JsonSerializer.Serialize(data);
            var stringContent = new StringContent(content);
            stringContent.Headers.ContentType = contentType;
            return httpClient.PutAsync(url, stringContent);
        }

        public static Task<HttpResponseMessage> DeleteAsync(this HttpClient httpClient, string url, long id)
        {
            return httpClient.DeleteAsync(url + id);
        }

        public static Task<HttpResponseMessage> GetAsync(this HttpClient httpClient, string url, long? id = null)
        {
            if (id.HasValue)
                url = url + id.Value;

            return httpClient.GetAsync($"{url}" );
        }
    }
}
