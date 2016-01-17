using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace WebClient.WebTools
{
    public class WebRequestService
    {
        private readonly IHttpService _httpService;

        public WebRequestService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<string> CallUrl(string url, string data)
        {
            if (!ValidateUrl(url))
            {
                throw new ArgumentException("Invalid Url", nameof(url));
            }

            if (!ValidateData(data))
            {
                throw new ArgumentException("Invalid Json Payload", nameof(data));
            }

            return string.IsNullOrEmpty(data) ? await _httpService.GetRequest(url) : _httpService.PostRequest(url, new Dictionary<string,string>());
        }

        private bool ValidateUrl(string url)
        {
            Uri uriResult;

            return Uri.TryCreate(url, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }

        //TODO - Implement and test real data validation
        //I'm making the assumption that json strings have to be at 1 level only and equate to name value pairs which
        //can be used to post to a web endpoint - so things like { name: "Dave", search: "true" } are valid but extra nesting
        //on top of that is not valid
        private bool ValidateData(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return true;
            }

            //This rules out mismatched braces and objects with too much depth without having to do any heavy lifting with NewtonSoft
            if (data.Count(c => c == '{')!= 1 || data.Count(c => c == '}') != 1)
            {
                return false;
            }

            try
            {
                var myclass = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(data);

                var oMyclass = Newtonsoft.Json.JsonConvert.DeserializeObject<Object>(data);
            }
            catch(JsonReaderException)
            {
                return false;
            }

            return true;
        }
    }
}
