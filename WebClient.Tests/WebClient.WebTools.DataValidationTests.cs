using System;
using System.Threading.Tasks;
using FakeItEasy;
using NUnit.Framework;
using WebClient.WebTools;

namespace WebClient.Tests
{
    [TestFixture]
    public class DataValidationTests
    {
        private readonly IHttpService _fakeHttpService;
        private const string ValidUrl = "http://tempuri.org";

        public DataValidationTests()
        {
            _fakeHttpService = A.Fake<IHttpService>();
        }

        [Test]
        public void WebClient_CallUrlWithInvalidDataScenario001_ArgumentExceptionThrown()
        {
            var webRequestService = new WebRequestService(_fakeHttpService);

            const string invalidData = "{{ name: \"Dave\" }";

            Assert.That(() => webRequestService.CallUrl(ValidUrl, invalidData), Throws.Exception.TypeOf<ArgumentException>().With.Property("ParamName").EqualTo("data"));
        }

        [Test]
        public void WebClient_CallUrlWithInvalidDataScenario002_ArgumentExceptionThrown()
        {
            var webRequestService = new WebRequestService(_fakeHttpService);

            const string invalidData = "{ name: \"Dave\", thing: { foo: true, bar: false } }";

            Assert.That(() => webRequestService.CallUrl(ValidUrl, invalidData), Throws.Exception.TypeOf<ArgumentException>().With.Property("ParamName").EqualTo("data"));
        }

        [Test]
        public void WebClient_CallUrlWithInvalidDataScenario003_ArgumentExceptionThrown()
        {
            var webRequestService = new WebRequestService(_fakeHttpService);

            const string invalidData = "{ name: \"Dave\", \"Age\" : 48, \"Sex\" : male }";

            Assert.That(() => webRequestService.CallUrl(ValidUrl, invalidData), Throws.Exception.TypeOf<ArgumentException>().With.Property("ParamName").EqualTo("data"));
        }

        [Test]
        public async Task WebClient_CallUrlWithValidDataScenario001_ArgumentExceptionNotThrown()
        {
            var webRequestService = new WebRequestService(_fakeHttpService);

            const string validData = "{ name: \"Dave\" }";

            await webRequestService.CallUrl(ValidUrl, validData);

            //No need to assert, just checking no exception is thrown
        }

        [Test]
        public async Task WebClient_CallUrlWithValidDataScenario002_ArgumentExceptionNotThrown()
        {
            var webRequestService = new WebRequestService(_fakeHttpService);

            const string validData = "{ name: \"Dave\", \"Age\" : 48 }";

            await webRequestService.CallUrl(ValidUrl, validData);

            //No need to assert, just checking no exception is thrown
        }

        [Test]
        public async Task WebClient_CallUrlWithValidDataScenario003_ArgumentExceptionNotThrown()
        {
            var webRequestService = new WebRequestService(_fakeHttpService);

            const string validData = "{ name: \"Dave\", \"Age\" : 48, \"Sex\" : \"male\" }";

            await webRequestService.CallUrl(ValidUrl, validData);

            //No need to assert, just checking no exception is thrown
        }
    }
}
