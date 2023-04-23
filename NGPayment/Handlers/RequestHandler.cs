using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NGPayments.Handlers
{
    public class RequestHandler
    {
        private readonly RestClient Instance;

        public RequestHandler()
        {
            this.Instance = new RestClient();
            this.Instance.AddDefaultHeader("Content-Type", "application/json");
        }

        public RequestHandler(string _baseUrl)
        {
            this.Instance = new RestClient(_baseUrl);
        }

        public async Task<T> Get<T>(string _resourceUrl, ICollection<KeyValuePair<string, string>> _customHeaders = null)
        {
            var request = new RestRequest(_resourceUrl, Method.Get);
            request.AddHeaders(_customHeaders);
            var response = await this.Instance.ExecuteAsync<T>(request);
            if (response.Content.Contains("jsonp"))
            {
                var jsonResult = response.Content.Replace("jsonp (", "")
                   .Replace(")", "");
                return JsonConvert.DeserializeObject<T>(jsonResult);
            }
            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        public async Task<T> Post<T, U>(string _resourceUrl, U _payload, ICollection<KeyValuePair<string, string>> _customHeaders = null)
        {
            var request = new RestRequest(_resourceUrl, Method.Post);
            request.AddHeaders(_customHeaders);
            if (_payload != null) request.AddBody(_payload);
            var response = await this.Instance.ExecuteAsync<T>(request);
            if (response.Content.Contains("jsonp"))
            {
                var jsonResult = response.Content.Replace("jsonp (", "")
                   .Replace(")", "");
                return JsonConvert.DeserializeObject<T>(jsonResult);
            }
            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        public async Task<T> Put<T, U>(string _resourceUrl, U _payload, ICollection<KeyValuePair<string, string>> _customHeaders = null)
        {
            var request = new RestRequest(_resourceUrl, Method.Put);
            request.AddHeaders(_customHeaders);
            if (_payload != null) request.AddBody(_payload);
            var response = await this.Instance.ExecuteAsync<T>(request);
            if (response.Content.Contains("jsonp"))
            {
                var jsonResult = response.Content.Replace("jsonp (", "")
                   .Replace(")", "");
                return JsonConvert.DeserializeObject<T>(jsonResult);
            }
            return JsonConvert.DeserializeObject<T>(response.Content);
        }
        public async Task<T> Delete<T>(string _resourceUrl, ICollection<KeyValuePair<string, string>> _customHeaders = null)
        {
            var request = new RestRequest(_resourceUrl, Method.Delete);
            request.AddHeaders(_customHeaders);
            var response = await this.Instance.ExecuteAsync<T>(request);
            if (response.Content.Contains("jsonp"))
            {
                var jsonResult = response.Content.Replace("jsonp (", "")
                   .Replace(")", "");
                return JsonConvert.DeserializeObject<T>(jsonResult);
            }
            return JsonConvert.DeserializeObject<T>(response.Content);
        }
    }
}
