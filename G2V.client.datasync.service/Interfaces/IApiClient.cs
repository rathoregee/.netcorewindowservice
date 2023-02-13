
namespace G2V.client.datasync.service.Interfaces
{
    public interface IApiClient
    {
        Task<T> DeleteAsync<T>(string url);
        Task<T> GetAsync<T>(string url);
        Task<T> PostAsync<T>(string url, HttpContent contentPost);
        Task<T> PutAsync<T>(string url, HttpContent contentPut);
    }
}