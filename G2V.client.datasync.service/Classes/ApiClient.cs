﻿using G2V.client.datasync.service.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace G2V.client.datasync.service.Classes
{
    public class ApiClient : IApiClient
    {
        private IHttpClientFactory _factory;
        private HttpClient? _client = null;
        private string _clientName;
        private const string mediaType = "application/json";

        public ApiClient(IHttpClientFactory factory, string clientName)
        {
            _factory = factory;
            _clientName = clientName;
        }

        #region Generic, Async, static HTTP functions for GET, POST, PUT, and DELETE
        public async Task<T> GetAsync<T>(string url)
        {
            _client = _factory.CreateClient(_clientName);
            SetupHeaders(_client);
            using HttpResponseMessage response = await _client.GetAsync(url);
            using HttpContent content = response.Content;
            string data = await content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(data);
            return result != null ? result : (T)new Object();
        }

        public async Task<T> PostAsync<T>(string url, HttpContent contentPost)
        {            
            _client = _factory.CreateClient(_clientName);
            SetupHeaders(_client);
            using HttpResponseMessage response = await _client.PostAsync(url, contentPost);
            using HttpContent content = response.Content;
            string data = await content.ReadAsStringAsync();            
            var result = JsonConvert.DeserializeObject<T>(data);
            return result != null ? result : (T)new Object();
        }

        public async Task<T> PutAsync<T>(string url, HttpContent contentPut)
        {            
            _client = _factory.CreateClient(_clientName);
            SetupHeaders(_client);
            using HttpResponseMessage response = await _client.PutAsync(url, contentPut);
            using HttpContent content = response.Content;
            string data = await content.ReadAsStringAsync();         
            var result = JsonConvert.DeserializeObject<T>(data);
            return result != null ? result : (T)new Object();
        }

        public async Task<T> DeleteAsync<T>(string url)
        {            
            _client = _factory.CreateClient(_clientName);
            SetupHeaders(_client);
            using HttpResponseMessage response = await _client.DeleteAsync(url);
            using HttpContent content = response.Content;
            string data = await content.ReadAsStringAsync();           ;
            var result = JsonConvert.DeserializeObject<T>(data);
            return result != null ? result : (T)new Object();
        }
        #endregion

        protected static void SetupHeaders(HttpClient client)
        {
            client.DefaultRequestHeaders.Clear();

            client.DefaultRequestHeaders.Accept.Add
                (new MediaTypeWithQualityHeaderValue
                (mediaType));
        }
    }
}