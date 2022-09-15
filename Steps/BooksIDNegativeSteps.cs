using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace BooksIDNegative
{
    [Binding]
    public class BooksIDNegativeSteps
    {
        public RestClient client = new RestClient("http://localhost:5000/Books");
        public RestRequest request = new RestRequest();
        private const string id = "/1";
        [When(@"the user makes a request to ""(.*)"" without a token")]
        public void WhenTheUserMakesARequestToWithoutAToken(string p0)
        {
            request = new RestRequest("http://localhost:5000/Books" + id, Method.Get);
            // var response = client.Execute(request);

        }

        [Then(@"the result should be a response (.*) Unauthorized")]
        public void ThenTheResultShouldBeAResponseUnauthorized(int p0)
        {
            RestResponse response = client.Execute(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
            // var response = client.Execute(request);
            var deserialize = JsonConvert.DeserializeObject<dynamic>(response.Content);
            Console.WriteLine(response.Content.ToString());
        }
    }
}