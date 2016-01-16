using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebClient.WebTools
{
    public interface IHttpService
    {
        string GetRequest(string url);

        string PostRequest(string url, Dictionary<string, string> data);
    }
}
