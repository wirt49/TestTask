using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Tests
{
    [TestFixture]
    public class ApiTestsTemplate
    {
        private RestClient client;
        private const string baseUrl = ""; 

        [SetUp]
        public void Setup()
        {
            client = new RestClient(baseUrl);
        }

        [Test]
        public void TestGetLoginFailTotal()
        {
            var request = new RestRequest("/loginfailtotal", Method.Get);
            request.AddParameter("username", "testuser");
            request.AddParameter("fail_count", 5);
            request.AddParameter("fetch_limit", 10);

            RestResponse response = client.Execute(request);

            Assert.IsNotNull(response.Content);
            Assert.IsFalse(string.IsNullOrWhiteSpace(response.Content));
            Assert.IsTrue(response.ContentType.StartsWith("application/json"));
        }

        [Test]
        public void TestResetLoginFailTotal()
        {
            var request = new RestRequest("/resetloginfailtotal", Method.Put);
            request.AddParameter("username", "testuser");

            RestResponse response = client.Execute(request);

            Assert.IsNotNull(response.Content);
            Assert.IsFalse(string.IsNullOrWhiteSpace(response.Content));
            Assert.AreEqual(response.Content, "Login fail count reset successfully.");

        }
    }
}
