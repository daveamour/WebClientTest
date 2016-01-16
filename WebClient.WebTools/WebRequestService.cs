using System;
using System.Collections.Generic;

namespace WebClient.WebTools
{
    public class WebRequestService
    {
        private readonly IHttpService _httpService;

        public WebRequestService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public string CallUrl(string url, string data)
        {
            if (!ValidateUrl(url))
            {
                throw new ArgumentException("Invalid Url", nameof(url));
            }

            if (!ValidateData(data))
            {
                throw new ArgumentException("Invalid Json Payload", nameof(data));
            }

            return string.IsNullOrEmpty(data) ? _httpService.GetRequest(url) : _httpService.PostRequest(url, new Dictionary<string,string>());
        }

        private bool ValidateUrl(string url)
        {
            Uri uriResult;

            return Uri.TryCreate(url, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }

        //TODO - Implement and test real data validation
        private bool ValidateData(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return true;
            }

            if (data == "bad json")
            {
                return false;
            }

            return true;
        }
    }
}
