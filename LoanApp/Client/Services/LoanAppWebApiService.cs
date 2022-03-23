namespace LoanAppMVC.Services
{
    public class LoanAppWebApiService :IHttpClientService
    {
        private readonly HttpClient _httpClient;

        public LoanAppWebApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public Task<HttpResponseMessage> GetAsync(string? url)
        {
            return _httpClient.GetAsync(url);
        }

        public Task<HttpResponseMessage> DeleteAsync(string? url)
        {
            return _httpClient.DeleteAsync(url);
        }


        public Task<HttpResponseMessage> PostAsJsonAsync<T>(string requestUri, T value)
        {
            return _httpClient.PostAsJsonAsync(requestUri, value);  
        }

        public Task<HttpResponseMessage> PutAsJsonAsync<T>(string requestUri, T value)
        {
            return _httpClient.PutAsJsonAsync(requestUri, value);
        }
    }
}
