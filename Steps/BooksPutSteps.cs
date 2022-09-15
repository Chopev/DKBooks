using DKBooks.Features;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Net;
using System.Net.NetworkInformation;
using TechTalk.SpecFlow;

namespace BooksPut
{
    [Binding]
    public class BooksPutSteps
    {
        public RestClient client = new RestClient("http://localhost:5000/Books");
        public RestRequest request = new RestRequest();
    

        [When(@"the user makes a Put reguest to ""(.*)""")]
        public void WhenTheUserMakesAPutReguestTo(string p0)
        {
           
            request = new RestRequest("http://localhost:5000/Books", Method.Put);    
            request.AddHeader("Authorization", Token.token);
            request.AddJsonBody(new { bookToUpdate = (new { id = "12", title = "com" }) });
            request.RequestFormat = DataFormat.Json;

        }

        [Then(@"the selected book should be edited")]
        public void ThenTheSelectedBookShouldBeEdited()
        {
            RestResponse response = client.Put(request);
            //Response message should be asserted too
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            var deserialize = JsonConvert.DeserializeObject<dynamic>(response.Content);
            Console.WriteLine(response.Content.ToString());
        }
    }
}