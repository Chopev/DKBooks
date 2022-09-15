using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace BookasNoToken
{
    [Binding]
    public class BooksSteps
    {
        public RestClient client = new RestClient("http://localhost:5000/Books");
        public RestRequest request = new RestRequest();
        [Given(@"the user does no have a token")]
        public void GivenTheUserDoesNoHaveAToken()
        {
            request = new RestRequest("http://localhost:5000/Books", Method.Post);
            request.AddHeader("Authorization", "");

        }

        [When(@"the user sends post request to ""(.*)""")]
        public void WhenTheUserSendsPostRequestTo(string p0)
        {
            var response = client.Execute(request);
        }

        [Then(@"the user gets response (.*)")]
        public void ThenTheUserGetsResponse(int p0)
        {
            RestResponse response = client.Execute(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
            var deserialize = JsonConvert.DeserializeObject<dynamic>(response.Content);
            Console.WriteLine(response.Content.ToString());
        }
    }
}
