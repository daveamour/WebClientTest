using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using WebClient.WebTools;

namespace WebClient.Tests
{
    [TestFixture]
    public class IntegrationTests
    {
        [Test]
        public void HttpService_TryCreateService_ServiceIsCreated()
        {
            var httpService = new HttpService();

            //No need for any implicit asserts, just testing that we can new up a concrete HttpService without throwing an exception
        }

        [Test]
        public void HttpService_TryCreateService_ServiceImplementsIHttpServiceInterface()
        {
            var httpService = new HttpService();

            Assert.IsInstanceOf(typeof(IHttpService), httpService);
        }

        [Test]
        public async Task HttpService_GetRequestCalledWithValidUrl_NoExceptionThrown()
        {
            var httpService = new HttpService();

            await httpService.GetRequest("http://www.paxium.co.uk");

            //No need for any implicit asserts, just testing that we can call GetRequest with a valid url without an exception being thrown
        }

        [Test]
        public void HttpService_GetRequestCalledWithValidUrlAndValidData_NoExceptionThrown()
        {
            var httpService = new HttpService();

            const string url = "http://www.paxium.co.uk";

            var data = new Dictionary<string, string> {{"name", "Dave"}};

            httpService.PostRequest(url, data);

            //No need for any implicit asserts, just testing that we can call PostRequest with a valid url without an exception being thrown
        }

        [Test]
        public async Task HttpService_GetRequestCalledWithValidUrl_StringReturnedWithLengthGreaterThanOne()
        {
            var httpService = new HttpService();

            var result = await httpService.GetRequest("http://www.paxium.co.uk");

            Assert.IsTrue(result.Length > 1);
        }

        [Test]
        public async Task HttpService_GetRequestCalledWithValidUrl_StringReturnedWithExpectedContent()
        {
            var httpService = new HttpService();

            var result = await httpService.GetRequest("http://www.paxium.co.uk");

            Assert.IsTrue(result.Contains("Paxium are a small, family run IT solutions business."));
        }
    }
}
