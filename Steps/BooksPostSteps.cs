using DKBooks.Features;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serializers;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace BooksPost
{
    [Binding]
    public class BooksPostSteps
    {
        public RestClient client = new RestClient("http://localhost:5000/Books");
        public RestRequest request = new RestRequest();

        [When(@"the user makes a post request to ""(.*)""")]
        public void WhenTheUserMakesAPostRequestTo(string p0)
        {
            request = new RestRequest("http://localhost:5000/Books", Method.Post);
            //Token has to be inserted manually.Could not figure out how to get it from the response in LogInSteps
            request.AddHeader("Authorization", Token.token);

            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new { title = "Malazan Book of the Fallen2", author = (new { firstName = "Steven", lastName = "Erikson" }), publisher = "Bantam Books" });

        }

        [Then(@"the user successfully adds a new book to the list")]
        public void ThenTheUserSuccessfullyAddsANewBookToTheList()
        {
            RestResponse response = client.Post(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            var deserialize = JsonConvert.DeserializeObject<dynamic>(response.Content);
        }
    }
}
