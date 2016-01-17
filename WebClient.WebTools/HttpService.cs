using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebClient.WebTools
{
    public class HttpService : IHttpService
    {
        public async Task<string> GetRequest(string url)
        {
            string responseString;

            using (var client = new HttpClient())
            {
                responseString = await client.GetStringAsync(url);
            }

            return responseString;
        }

        public string PostRequest(string url, Dictionary<string, string> data)
        {
            return "";
        }
    }
}
