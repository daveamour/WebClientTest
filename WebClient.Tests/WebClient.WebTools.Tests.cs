using System;
using System.Collections.Generic;
using FakeItEasy;
using NUnit.Framework;
using WebClient.WebTools;

namespace WebClient.Tests
{
    [TestFixture]
    public class WebClientTests
    {
        private readonly IHttpService _fakeHttpService;
        private const string ServiceUrl = "http://tempuri.og/servicetest";

        public WebClientTests()
        {
            _fakeHttpService = A.Fake<IHttpService>();
        }

        [Test]
        public void WebClient_CreateWebRequestService_InstanceIsNotNull()
        {
            var webRequestService = new WebRequestService(_fakeHttpService);

            Assert.IsNotNull(webRequestService);
        }

        [Test]
        public void WebClient_CreateWebRequestService_InstanceIsOfCorrectType()
        {
            var webRequestService = new WebRequestService(_fakeHttpService);

            Assert.IsInstanceOf(typeof(WebRequestService), webRequestService);
        }

        [Test]
        public void WebClient_CallUrlWithValidArgs_NoExceptionThrown()
        {
            var webRequestService = new WebRequestService(_fakeHttpService);

            webRequestService.CallUrl(ServiceUrl, "{ name: \"Dave\" }");

            //No need to explicitly assert anything, we just want no exception
        }

        [Test]
        public void WebClient_CallUrlWithInvalidUrl_ArgumentExceptionThrown()
        {
            var webRequestService = new WebRequestService(_fakeHttpService);

            Assert.That(() => webRequestService.CallUrl("I am an invalid url", "{ name: \"Dave\" }"), Throws.Exception.TypeOf<ArgumentException>().With.Property("ParamName").EqualTo("url"));
        }

        [Test]
        public void WebClient_CallUrlWithInvalidData_ArgumentExceptionThrown()
        {
            var webRequestService = new WebRequestService(_fakeHttpService);

            Assert.That(() => webRequestService.CallUrl(ServiceUrl, "bad json"), Throws.Exception.TypeOf<ArgumentException>().With.Property("ParamName").EqualTo("data"));
        }

        [Test]
        public void WebClient_CallUrlWithValidArgsAndNullData_GetRequestIsMade()
        {
            var webRequestService = new WebRequestService(_fakeHttpService);

            var url = ServiceUrl;

            webRequestService.CallUrl(url, null);

            A.CallTo(() => _fakeHttpService.GetRequest(url)).MustHaveHappened();
        }

        [Test]
        public void WebClient_CallUrlWithValidArgsAndEmptyStringForData_GetRequestIsMade()
        {
            var webRequestService = new WebRequestService(_fakeHttpService);

            var url = ServiceUrl;

            var data = "";

            webRequestService.CallUrl(url, data);

            A.CallTo(() => _fakeHttpService.GetRequest(url)).MustHaveHappened();
        }

        [Test]
        public void WebClient_CallUrlWithValidArgsAndRealData_PostRequestIsMade()
        {
            var webRequestService = new WebRequestService(_fakeHttpService);

            var url = ServiceUrl;

            var data = "{ name: \"Dave\" }";

            webRequestService.CallUrl(url, data);

            A.CallTo(() => _fakeHttpService.PostRequest(url, A<Dictionary<string,string>>.Ignored)).MustHaveHappened();
        }
    }
}
