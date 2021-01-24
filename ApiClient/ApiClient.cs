using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using ApiClient.Response;

namespace ApiClient
{
    public partial class ApiClient
    {
        private readonly HttpClient _httpClient;
        private Uri BaseEndpoint { get; set; }

        public ApiClient(Uri baseEndpoint)
        {
            if (baseEndpoint == null)
            {
                throw new ArgumentNullException("baseEndpoint");
            }
            BaseEndpoint = baseEndpoint;
            _httpClient = new HttpClient();
        }
        /// <summary>
        /// Common method for making GET calls
        /// </summary>
        private async Task<T> GetAsync<T>(Uri requestUrl)
        {
            //addHeaders();
            var response = await _httpClient.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(data);
        }

        /// <summary>
        /// Common method for making POST calls
        /// </summary>
        private async Task<T> PostAsync<T>(Uri requestUrl)
        {
            var response = await _httpClient.PostAsync(requestUrl, null);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(data);
        }
        private async Task<APIResponse<T>> PostAsync<T>(Uri requestUrl, T content)
        {
            addHeaders();
            var response = await _httpClient.PostAsync(requestUrl.ToString(), CreateHttpContent<T>(content));
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<APIResponse<T>>(data);
        }
        private async Task<T> PostAsync<T>(Uri requestUrl, IDictionary<string, string> content)
        {
            var response = await _httpClient.PostAsync(requestUrl, CreateHttpContent(content));
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(data);
        }
        private async Task<T> PostAsync<T>(Uri requestUrl, FormUrlEncodedContent encodedContent)
        {
            var response = await _httpClient.PostAsync(requestUrl, encodedContent);
            response.EnsureSuccessStatusCode();
            var data = response.Content.ReadAsStringAsync().Result;
            //Convert XMl To Json
            if (response.Content.Headers.ContentType.MediaType == "text/xml")
            {
                var json = new JsonMediaTypeFormatter();
                return JsonConvert.DeserializeObject<T>(StringExtensions.Serialize(json, StringExtensions.GetXmlData(data)));
            }
            return JsonConvert.DeserializeObject<T>(data);
        }
        //private async Task<Response<T1>> PostAsync<T1, T2>(Uri requestUrl, T2 content)
        //{
        //    addHeaders();
        //    var response = await _httpClient.PostAsync(requestUrl.ToString(), CreateHttpContent<T2>(content));
        //    response.EnsureSuccessStatusCode();
        //    var data = await response.Content.ReadAsStringAsync();
        //    return JsonConvert.DeserializeObject<Response<T1>>(data);
        //}

        private async Task<T> PostAsync<T, T1>(Uri requestUrl, T1 content)
        {
            var response = await _httpClient.PostAsync(requestUrl, CreateHttpContent(content));
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(data);
        }

        private async void Get(Uri requestUrl)
        {
            var response = _httpClient.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);
        }


        private Uri CreateRequestUri(string relativePath, string queryString = "")
        {
            var endpoint = new Uri(BaseEndpoint, relativePath);
            var uriBuilder = new UriBuilder(endpoint);
            uriBuilder.Query = queryString;
            return uriBuilder.Uri;
        }

        private HttpContent CreateHttpContent<T>(T content)
        {
            var json = JsonConvert.SerializeObject(content, MicrosoftDateFormatSettings);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private static JsonSerializerSettings MicrosoftDateFormatSettings
        {
            get
            {
                return new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                };
            }
        }

        private void addHeaders()
        {
            _httpClient.DefaultRequestHeaders.Remove("userIP");
            _httpClient.DefaultRequestHeaders.Add("userIP", "192.168.1.1");
        }
    }
}
