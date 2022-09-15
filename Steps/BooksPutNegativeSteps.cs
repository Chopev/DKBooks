using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace DKBooks.Features
{
    [Binding]
    public class BooksPutNegativeSteps
    {
        public RestClient client = new RestClient("http://localhost:5000/Books");
        public RestRequest request = new RestRequest();

        [When(@"the user makes a put request to ""(.*)"" with integers for title and publisher")]
        public void WhenTheUserMakesAPutRequestToWithIntegersForTitleAndPublisher(string p0)
        {
            request = new RestRequest("http://localhost:5000/Books", Method.Put);
            //Token has to be inserted manually.Could not figure out how to get it from the response in LogInSteps
            request.AddHeader("Authorization", Token.token);
            request.AddJsonBody(new { bookToUpdate = (new { id = "12", title = "3" , publusher = "4" }) });
            request.RequestFormat = DataFormat.Json;
        }
        
        [Then(@"the response shoud be (.*) Bad Request")]
        public void ThenTheResponseShoudBeBadRequest(int p0)
        {
            RestResponse response = client.Put(request);     
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            var deserialize = JsonConvert.DeserializeObject<dynamic>(response.Content);
            Console.WriteLine(response.Content.ToString());
        }
    }
}
