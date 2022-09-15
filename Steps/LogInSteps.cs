using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace LogIn
{
    [Binding]
    public class LogInSteps
    {
        public RestClient client = new RestClient("http://localhost:5000/Authentication/login");
        public RestRequest request = new RestRequest();
        [When(@"the user logs in")]
        public void WhenTheUserLogsIn()
        {
            request = new RestRequest("http://localhost:5000/Authentication/login", Method.Post);
            request.AddJsonBody(new { emailAddress = "dchopev@gmail.com", password = "123456789" });

        }
        [Then(@"the user receives a valid token")]
        public void ThenTheUserReceivesAValidToken()
        {
            RestResponse response = client.Post(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var deserialize = JsonConvert.DeserializeObject<dynamic>(response.Content);
            Console.WriteLine(response.Content.ToString());
            // var token = JsonConvert.DeserializeObject<dynamic>(response.Content);
            // var t=  Console.WriteLine(token.token);
            //  var b = ("Bearer" +" " + t);


        }
    }
}
