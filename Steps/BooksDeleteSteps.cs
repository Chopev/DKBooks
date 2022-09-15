using DKBooks.Features;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace BooksDelete
{
    [Binding]
    public class BooksDeleteSteps
    {
        public RestClient client = new RestClient("http://localhost:5000/Books");
        public RestRequest request = new RestRequest();

        [When(@"the user makes delete request to ""(.*)""")]
        public void WhenTheUserMakesDeleteRequestTo(string p0)
        {
            request = new RestRequest("http://localhost:5000/Books", Method.Delete);
            //Token has to be inserted manually.Could not figure out how to get it from the response in LogInSteps
            request.AddHeader("Authorization", Token.token);
            request.AddParameter("BookId", "8");
            request.RequestFormat = DataFormat.Json;

        }

        [Then(@"the book should be deleted")]
        public void ThenTheBookShouldBeDeleted()
        {
            RestResponse response = client.Delete(request);
            //Response message should be asserted too
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var deserialize = JsonConvert.DeserializeObject<dynamic>(response.Content);
            Console.WriteLine(response.Content.ToString());
        }
    }
}
