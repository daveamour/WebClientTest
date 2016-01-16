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

        //TODO - Implement and test Real Url Validation
        private bool ValidateUrl(string url)
        {
            if (url == "I am an invalid url")
            {
                return false;
            }

            return true;
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
