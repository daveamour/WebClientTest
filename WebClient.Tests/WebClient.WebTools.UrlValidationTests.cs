using System;
using FakeItEasy;
using NUnit.Framework;
using WebClient.WebTools;

namespace WebClient.Tests
{
    [TestFixture]
    public class UrlValidationTests
    {
        private readonly IHttpService _fakeHttpService;

        public UrlValidationTests()
        {
            _fakeHttpService = A.Fake<IHttpService>();
        }

        [Test]
        public void WebClient_CallUrlWithInvalidUrlScenario001_ArgumentExceptionThrown()
        {
            var webRequestService = new WebRequestService(_fakeHttpService);

            const string invalidUrl = "sdfsdfsdfdsfsdfdfsd";

            Assert.That(() => webRequestService.CallUrl(invalidUrl, "{ name: \"Dave\" }"), Throws.Exception.TypeOf<ArgumentException>().With.Property("ParamName").EqualTo("url"));
        }

        [Test]
        public void WebClient_CallUrlWithInvalidUrlScenario002_ArgumentExceptionThrown()
        {
            var webRequestService = new WebRequestService(_fakeHttpService);

            const string invalidUrl = "http:/tempuri.org";

            Assert.That(() => webRequestService.CallUrl(invalidUrl, "{ name: \"Dave\" }"), Throws.Exception.TypeOf<ArgumentException>().With.Property("ParamName").EqualTo("url"));
        }

        [Test]
        public void WebClient_CallUrlWithInvalidUrlScenario003_ArgumentExceptionThrown()
        {
            var webRequestService = new WebRequestService(_fakeHttpService);

            const string invalidUrl = "http:///tempuri.org";

            Assert.That(() => webRequestService.CallUrl(invalidUrl, "{ name: \"Dave\" }"), Throws.Exception.TypeOf<ArgumentException>().With.Property("ParamName").EqualTo("url"));
        }

        [Test]
        public void WebClient_CallUrlWithInvalidUrlScenario004_ArgumentExceptionThrown()
        {
            var webRequestService = new WebRequestService(_fakeHttpService);

            const string invalidUrl = "ht tp://tempuri.org";

            Assert.That(() => webRequestService.CallUrl(invalidUrl, "{ name: \"Dave\" }"), Throws.Exception.TypeOf<ArgumentException>().With.Property("ParamName").EqualTo("url"));
        }

        [Test]
        public void WebClient_CallUrlWithInvalidUrlScenario005_ArgumentExceptionThrown()
        {
            var webRequestService = new WebRequestService(_fakeHttpService);

            const string invalidUrl = "http://tempuri.org..";

            Assert.That(() => webRequestService.CallUrl(invalidUrl, "{ name: \"Dave\" }"), Throws.Exception.TypeOf<ArgumentException>().With.Property("ParamName").EqualTo("url"));
        }

        [Test]
        public void WebClient_CallUrlWithValidUrlScenario001_ArgumentExceptionNotThrown()
        {
            var webRequestService = new WebRequestService(_fakeHttpService);

            const string validUrl = "http://tempuri.org";

            webRequestService.CallUrl(validUrl, "{ name: \"Dave\" }");

            //No need to assert, just checking no exception is thrown
        }

        [Test]
        public void WebClient_CallUrlWithValidUrlScenario002_ArgumentExceptionNotThrown()
        {
            var webRequestService = new WebRequestService(_fakeHttpService);

            const string validUrl = "https://tempuri.org";

            webRequestService.CallUrl(validUrl, "{ name: \"Dave\" }");

            //No need to assert, just checking no exception is thrown
        }

        [Test]
        public void WebClient_CallUrlWithValidUrlScenario003_ArgumentExceptionNotThrown()
        {
            var webRequestService = new WebRequestService(_fakeHttpService);

            const string validUrl = "http://tempuri.org/";

            webRequestService.CallUrl(validUrl, "{ name: \"Dave\" }");

            //No need to assert, just checking no exception is thrown
        }

        [Test]
        public void WebClient_CallUrlWithValidUrlScenario004_ArgumentExceptionNotThrown()
        {
            var webRequestService = new WebRequestService(_fakeHttpService);

            const string validUrl = "https://tempuri.org/";

            webRequestService.CallUrl(validUrl, "{ name: \"Dave\" }");

            //No need to assert, just checking no exception is thrown
        }

        [Test]
        public void WebClient_CallUrlWithValidUrlScenario005_ArgumentExceptionNotThrown()
        {
            var webRequestService = new WebRequestService(_fakeHttpService);

            const string validUrl = "http://tempuri.org/service";

            webRequestService.CallUrl(validUrl, "{ name: \"Dave\" }");

            //No need to assert, just checking no exception is thrown
        }

        [Test]
        public void WebClient_CallUrlWithValidUrlScenario006_ArgumentExceptionNotThrown()
        {
            var webRequestService = new WebRequestService(_fakeHttpService);

            const string validUrl = "https://tempuri.org/service";

            webRequestService.CallUrl(validUrl, "{ name: \"Dave\" }");

            //No need to assert, just checking no exception is thrown
        }

        [Test]
        public void WebClient_CallUrlWithValidUrlScenario007_ArgumentExceptionNotThrown()
        {
            var webRequestService = new WebRequestService(_fakeHttpService);

            const string validUrl = "http://tempuri.org/service/myservice";

            webRequestService.CallUrl(validUrl, "{ name: \"Dave\" }");

            //No need to assert, just checking no exception is thrown
        }

        [Test]
        public void WebClient_CallUrlWithValidUrlScenario008_ArgumentExceptionNotThrown()
        {
            var webRequestService = new WebRequestService(_fakeHttpService);

            const string validUrl = "https://tempuri.org/service/myservice";

            webRequestService.CallUrl(validUrl, "{ name: \"Dave\" }");

            //No need to assert, just checking no exception is thrown
        }

        [Test]
        public void WebClient_CallUrlWithValidUrlScenario009_ArgumentExceptionNotThrown()
        {
            var webRequestService = new WebRequestService(_fakeHttpService);

            const string validUrl = "http://tempuri.org/service/myservice.aspx";

            webRequestService.CallUrl(validUrl, "{ name: \"Dave\" }");

            //No need to assert, just checking no exception is thrown
        }

        [Test]
        public void WebClient_CallUrlWithValidUrlScenario010_ArgumentExceptionNotThrown()
        {
            var webRequestService = new WebRequestService(_fakeHttpService);

            const string validUrl = "https://tempuri.org/service/myservice.aspx";

            webRequestService.CallUrl(validUrl, "{ name: \"Dave\" }");

            //No need to assert, just checking no exception is thrown
        }

        [Test]
        public void WebClient_CallUrlWithValidUrlScenario011_ArgumentExceptionNotThrown()
        {
            var webRequestService = new WebRequestService(_fakeHttpService);

            const string validUrl = "http://tempuri.org/service/myservice.asp";

            webRequestService.CallUrl(validUrl, "{ name: \"Dave\" }");

            //No need to assert, just checking no exception is thrown
        }

        [Test]
        public void WebClient_CallUrlWithValidUrlScenario012_ArgumentExceptionNotThrown()
        {
            var webRequestService = new WebRequestService(_fakeHttpService);

            const string validUrl = "https://tempuri.org/service/myservice.asp";

            webRequestService.CallUrl(validUrl, "{ name: \"Dave\" }");

            //No need to assert, just checking no exception is thrown
        }

        [Test]
        public void WebClient_CallUrlWithValidUrlScenario013_ArgumentExceptionNotThrown()
        {
            var webRequestService = new WebRequestService(_fakeHttpService);

            const string validUrl = "http://tempuri.org/service/my%20service.asp";

            webRequestService.CallUrl(validUrl, "{ name: \"Dave\" }");

            //No need to assert, just checking no exception is thrown
        }

        [Test]
        public void WebClient_CallUrlWithValidUrlScenario014_ArgumentExceptionNotThrown()
        {
            var webRequestService = new WebRequestService(_fakeHttpService);

            const string validUrl = "https://tempuri.org/service/my%20service.asp";

            webRequestService.CallUrl(validUrl, "{ name: \"Dave\" }");

            //No need to assert, just checking no exception is thrown
        }
    }
}
