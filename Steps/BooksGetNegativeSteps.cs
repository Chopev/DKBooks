using DKBooks.Features;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace BooksGetNegative
{
    [Binding]
    
    
        public class BooksGetNegativeSteps
        {
            public RestClient client = new RestClient("http://localhost:5000/Books");
            public RestRequest request = new RestRequest();
            [When(@"the user enters an integer for AuthorFirstName")]
            [When(@"the user enters an integer for a parameter")]
            public void WhenTheUserEntersAnIntegerForAParameter()
            {
                request = new RestRequest("http://localhost:5000/Books", Method.Get);
                //Token must be entered manually
                request.AddHeader("Authorization", Token.token);
                request.AddParameter("AuthorFirstName", "1");
            }

            [Then(@"The response code is (.*)")]
            public void ThenTheResponseCodeIs(int p0)
            {
                RestResponse response = client.Execute(request);
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
                //Wanted to assert "AuthorLastName": ["Must provide Authors`s last name as well in order to filter by author "] but could not do it   
                var deserialize = JsonConvert.DeserializeObject<dynamic>(response.Content);
                Console.WriteLine(response.Content.ToString());
            }
        }
    }
