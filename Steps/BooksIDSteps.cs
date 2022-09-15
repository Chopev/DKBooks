using DKBooks.Features;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace BooksID
{
    [Binding]
    public class BooksIDSteps
    {
        public RestClient client = new RestClient("http://localhost:5000/Books");
        public RestRequest request = new RestRequest();
        private const string id = "/1";
        [When(@"the user sends a get request with ID to ""(.*)""")]
        public void WhenTheUserSendsAGetRequestWithIDTo(string p0)
        {
            request = new RestRequest("http://localhost:5000/Books" + id, Method.Get);
            //Token shoudl be added manually
            request.AddHeader("Authorization", Token.token);



        }

        [Then(@"the user should get the book with that ID")]
        public void ThenTheUserShouldGetTheBookWithThatID()
        {

            RestResponse response = client.Get(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var deserialize = JsonConvert.DeserializeObject<dynamic>(response.Content);
            Console.WriteLine(response.Content.ToString());
        }
    }
}

