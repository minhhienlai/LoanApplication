namespace LoanAppMVC.Services
{
    public interface IHttpClientService
    {
        Task<HttpResponseMessage> GetAsync(string? url);
        Task<HttpResponseMessage> PostAsJsonAsync<T>(string requestUri, T value);
        Task<HttpResponseMessage> PutAsJsonAsync<T>(string requestUri, T value);
        Task<HttpResponseMessage> DeleteAsync(string? url);

    }
}
