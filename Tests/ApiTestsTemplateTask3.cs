using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Models;

namespace TestTask.Tests
{
    [TestFixture]
    [TestOf("TestAPI")]
    public class ApiTestsTemplateTask3
    {
        private RestClient client;
        private const string baseUrl = ""; 

        [SetUp]
        public void Setup()
        {
            client = new RestClient(baseUrl);
        }

        [Test, Description("Validates that the response contains the correct data for the specified user and fail count")]
        public void TestGetLoginFailTotalWithUsernameAndFailCount()
        {
            var request = new RestRequest("/loginfailtotal", Method.Get);
            request.AddParameter("username", "testuser");
            request.AddParameter("fail_count", 5);

            RestResponse response = client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

            Assert.IsNotNull(response.Content);
            Assert.IsFalse(string.IsNullOrWhiteSpace(response.Content));
            Assert.IsTrue(response.ContentType?.StartsWith("application/json"));

            var responseData = JsonConvert.DeserializeObject<List<LoginFailTotalResponseModel>>(response.Content);

            // Validate response data
            foreach (var data in responseData)
            {
                Assert.IsNotNull(data.Username);
                Assert.IsNotNull(data.FailCount);
                Assert.GreaterOrEqual(data.FailCount, 5); // Ensure fail_count is greater than or equal to 5
            }
        }

        [Test, Description("Tests the PUT/resetloginfailtotal endpoint " +
            "by resetting the login fail count for a specific user and validates the success message in the response")]
        public void TestResetLoginFailTotal()
        {
            var request = new RestRequest("/resetloginfailtotal", Method.Put);
            request.AddParameter("username", "testuser");

            RestResponse response = client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

            Assert.IsNotNull(response.Content);
            Assert.IsFalse(string.IsNullOrWhiteSpace(response.Content));
            Assert.That(response.Content, Is.EqualTo("Login fail count reset successfully."));
        }

        [Test, Description("Validates that the API responds with a 'NotFound' status code and an appropriate error message")]
        public void TestGetLoginFailTotalWithInvalidUsername()
        {
            var request = new RestRequest("/loginfailtotal", Method.Get);
            request.AddParameter("username", "invaliduser");

            RestResponse response = client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NotFound));

            Assert.IsNotNull(response.Content);
            Assert.IsFalse(string.IsNullOrWhiteSpace(response.Content));
            Assert.That(response.Content, Is.EqualTo("User not found"));
        }

        [Test, Description("Validates that the API responds with a 'BadRequest'" +
            " status code and an appropriate error message")]
        public void TestResetLoginFailTotalWithMissingUsername()
        {
            var request = new RestRequest("/resetloginfailtotal", Method.Put);

            RestResponse response = client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.BadRequest));

            Assert.IsNotNull(response.Content);
            Assert.IsFalse(string.IsNullOrWhiteSpace(response.Content));
            Assert.That(response.Content, Is.EqualTo("Username is required"));
        }

        [Test, Description("Validates that the API responds with a BadRequest status code and an appropriate error message when " +
            "for invalid 'fail_count' parameter")]
        public void TestGetLoginFailTotalWithInvalidFailCount()
        {
            var request = new RestRequest("/loginfailtotal", Method.Get);
            request.AddParameter("username", "testuser");
            request.AddParameter("fail_count", "invalid"); // Invalid fail_count value

            RestResponse response = client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.BadRequest));

            Assert.IsNotNull(response.Content);
            Assert.IsFalse(string.IsNullOrWhiteSpace(response.Content));
            Assert.That("Invalid parameters provided", Is.EqualTo(response.Content));
        }

        [Test, Description("Ensure sensitive data like password is not exposed in error response")]
        public void TestSensitiveDataNotExposedInErrorResponses()
        {
            var request = new RestRequest("/loginfailtotal", Method.Get);
            request.AddParameter("username", "nonexistentuser");

            RestResponse response = client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NotFound));

            Assert.IsNotNull(response.Content);
            Assert.IsFalse(string.IsNullOrWhiteSpace(response.Content));
            Assert.IsFalse(response.Content.Contains("Password"));
        }
    }
}
