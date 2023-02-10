using G2V.client.datasync.service.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G2V.client.datasync.service.Classes
{
    public class ApiClient : IApiClient
    {
        private IHttpClientFactory _factory;
        private HttpClient? _client = null;
        private string _clientName;

        public ApiClient(IHttpClientFactory httpClientFactory, string ClientName)
        {
            _factory = httpClientFactory;
            _clientName = ClientName;
        }

        #region Generic, Async, static HTTP functions for GET, POST, PUT, and DELETE             

        public async Task<T> GetAsync<T>(string url)
        {
            
            try
            {
                T data;
                _client = _factory.CreateClient(_clientName);
                using HttpResponseMessage response = await _client.GetAsync(url);
                using HttpContent content = response.Content;
                string d = await content.ReadAsStringAsync();
                if (d != null)
                {
                    data = JsonConvert.DeserializeObject<T>(d);
                    return (T)data;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            Object o = new Object();
            return (T)o;
        }

        public async Task<T> PostAsync<T>(string url, HttpContent contentPost)
        {
            T data;
            _client = _factory.CreateClient(_clientName);
            using (HttpResponseMessage response = await _client.PostAsync(url, contentPost))
            using (HttpContent content = response.Content)
            {
                string d = await content.ReadAsStringAsync();
                if (d != null)
                {
                    data = JsonConvert.DeserializeObject<T>(d);
                    return (T)data;
                }
            }
            Object o = new Object();
            return (T)o;
        }

        public async Task<T> PutAsync<T>(string url, HttpContent contentPut)
        {
            T data;
            _client = _factory.CreateClient(_clientName);

            using (HttpResponseMessage response = await _client.PutAsync(url, contentPut))
            using (HttpContent content = response.Content)
            {
                string d = await content.ReadAsStringAsync();
                if (d != null)
                {
                    data = JsonConvert.DeserializeObject<T>(d);
                    return (T)data;
                }
            }
            Object o = new Object();
            return (T)o;
        }

        public async Task<T> DeleteAsync<T>(string url)
        {
            T newT;
            _client = _factory.CreateClient(_clientName);

            using (HttpResponseMessage response = await _client.DeleteAsync(url))
            using (HttpContent content = response.Content)
            {
                string data = await content.ReadAsStringAsync();
                if (data != null)
                {
                    newT = JsonConvert.DeserializeObject<T>(data);
                    return newT;
                }
            }
            Object o = new Object();
            return (T)o;
        }
        #endregion
    }
}
