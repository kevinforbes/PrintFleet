using System;
using RestSharp;

namespace PrintFleetClient
{
    public class PrintFleetClient
    {
        private readonly string _apiBaseUrl;
        private readonly string _apiVersion;
        private readonly string _userName;
        private readonly string _password;

        public string Url { get { return new Uri(new Uri(_apiBaseUrl), _apiVersion).AbsoluteUri; } }

        public PrintFleetClient(string apiBaseUrl, string apiVersion, string userName, string password)
        {
            if (apiBaseUrl == null) throw new ArgumentNullException("apiBaseUrl");

            _apiBaseUrl = apiBaseUrl;
            _apiVersion = apiVersion;
            _userName = userName;
            _password = password;
        }

        public T Execute<T>(RestRequest request) where T : new()
        {
            var client = new RestClient { BaseUrl = Url, Authenticator = new HttpBasicAuthenticator(_userName, _password) };

            var response = client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                throw new InvalidOperationException(response.Content, response.ErrorException);
            }
            return response.Data;
        }
        
        public Device GetDevice(Guid deviceId)
        {
            var request = new RestRequest { Resource = "devices/{deviceId}", RootElement = "Device" };
            request.AddParameter("deviceId", deviceId, ParameterType.UrlSegment);
            return Execute<Device>(request);
        }
    }
}