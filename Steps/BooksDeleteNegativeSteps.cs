using DKBooks.Features;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace BooksDeleteNegative
{
    [Binding]
    public class BooksDeleteNegativeSteps
    {
        public RestClient client = new RestClient("http://localhost:5000/Books");
        public RestRequest request = new RestRequest();

        [When(@"the users makes a delete request to ""(.*)"" with an invalid ID")]
        public void WhenTheUsersMakesADeleteRequestToWithAnInvalidID(string p0)
        {
            request = new RestRequest("http://localhost:5000/Books", Method.Delete);
            //Token has to be inserted manually.Could not figure out how to get it from the response in LogInSteps
            request.AddHeader("Authorization", Token.token);
            request.AddParameter("BookId", "122222222222");
            request.RequestFormat = DataFormat.Json;

        }

        [Then(@"the response should be (.*) Bad Request")]
        public void ThenTheResponseShouldBeBadRequest(int p0)
        {
            RestResponse response = client.Execute(request);
            //Response message should be asserted too
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));

            var deserialize = JsonConvert.DeserializeObject<dynamic>(response.Content);
            Console.WriteLine(response.Content.ToString());
        }
    }
}
