using DKBooks.Features;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace BooksGet
{
    [Binding]
    public class BooksGetSteps
    {
        public RestClient client = new RestClient("http://localhost:5000/Books");
        public RestRequest request = new RestRequest();

        [When(@"the user makes a get request to ""(.*)""")]
        public void WhenTheUserMakesAGetRequestTo(string p0)
        {
            request = new RestRequest("http://localhost:5000/Books", Method.Get);
            //Token has to be inserted manually.Could not figure out how to get it from the response in LogInSteps
            request.AddHeader("Authorization", Token.token);

        }

        [Then(@"the response returns a list of available books")]
        public void ThenTheResponseReturnsAListOfAvailableBooks()
        {
            RestResponse response = client.Get(request);
            //I wanted to check the response but didn't know how so I did just the status.Using the Console.Writeline to see what I am actually getting as a response  
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var deserialize = JsonConvert.DeserializeObject<dynamic>(response.Content);
            Console.WriteLine(response.Content.ToString());
        }
    }
}

