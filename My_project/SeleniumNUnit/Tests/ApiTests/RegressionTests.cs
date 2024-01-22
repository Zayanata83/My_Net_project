using NUnit.Framework;
using SeleniumNUnit.Business.API;
using SeleniumNUnit.Business.API.APIUtils;
using System.Net;
using User = SeleniumNUnit.Business.API.Models.Response.User;
using NLog;
using SeleniumNUnit.Configurations.AppConfigurations;
using RestSharp;

namespace SeleniumNUnit.Tests.ApiTests
{
    [TestFixture]
    public class RegressionTests
    {
        private APIClient api = new APIClient(AppConfiguration.GetConfiguration().AppSettings.Settings["apiSite"].Value);
        private string createdName = "Karlom Figaro";
        private string createdUserName = "Nootam";


        [Test]
        [Category ("API")]
        public void ValidateUserCanBeCreated()
        {
            string payload = "{\"name\":\"Karlom Figaro\",\"username\":\"Nootam\"}";

            RestResponse response = api.CreateUser(payload).Result;
            LogManager.GetCurrentClassLogger().Info("Got Post response");
            User user = ResponseConverter.GetDeserializedObject<User>(response);

            string errorMessage = response.ErrorMessage;
            LogManager.GetCurrentClassLogger().Info($"Got Error message - {errorMessage}");
            HttpStatusCode statusCode = response.StatusCode;
            var code = (int)statusCode;
            LogManager.GetCurrentClassLogger().Info($"Got Status code - {statusCode} - {code}");

            Assert.AreEqual(201, code, $"Status code must be 201, but we got => {code}");
            Assert.IsNotEmpty(user.Id.ToString(), $"User's id must be not empty, but we got => {user.Id}");
            Assert.AreEqual("Karlom Figaro", user.Name, $"Created name must be {createdName}, but we got => {user.Name}");
            Assert.AreEqual("Nootam", user.Username, $"Created username must be {createdUserName}, but we got => {user.Username}");
            Assert.IsNull(errorMessage, $"Error message must be null, but we got {errorMessage}");                         
        }

        [Test]
        [Category("API")]
        public void ValidateUsersListReceivedSuccessfully()
        {
            RestResponse response = api.GetUsersList().Result;
            LogManager.GetCurrentClassLogger().Info("Got Get response");
            List<User> content = ResponseConverter.GetDeserializedCollection<User>(response);

            HttpStatusCode statusCode = response.StatusCode;
            var code = (int)statusCode;
            LogManager.GetCurrentClassLogger().Info($"Got Status code - {statusCode} - {code}");
            var isContainAllFields = WorkWithContent.IsUsersListContainAllDataCorrectly(content);

            Assert.AreEqual(200, code, $"Status code must be 200, but we got => {code}");
            Assert.AreEqual(true, isContainAllFields, "User's list doesn't contain all needed fields");
        }

        [Test]
        [Category("API")]
        public void ValidateResponseHeaderForListOfUsers()
        {
            RestResponse response = api.GetUsersList().Result;
            LogManager.GetCurrentClassLogger().Info("Got Get response");
            var headers = response.ContentHeaders;
            string headerValue = WorkWithContent.GetHeaderValue(headers, "Content-Type");
            LogManager.GetCurrentClassLogger().Info($"Got header - {headerValue}");

            string errorMessage = response.ErrorMessage;
            LogManager.GetCurrentClassLogger().Info($"Got Error message - {errorMessage}");
            HttpStatusCode statusCode = response.StatusCode;
            var code = (int)statusCode;
            LogManager.GetCurrentClassLogger().Info($"Got Status code - {statusCode} - {code}");

            Assert.AreEqual("application/json; charset=utf-8", headerValue, $"Value of header is not application/json, charset=utf-8, but we got => {headerValue}");
            Assert.AreEqual(200, code, $"Status code must be 200, but we got {code}");
            Assert.IsNull(errorMessage, $"Error message must be null, but we got {errorMessage}");
        }

        [Test]
        [Category("API")]
        public void ValidateResponseDataOfUsersList()
        {
            RestResponse response = api.GetUsersList().Result;
            LogManager.GetCurrentClassLogger().Info("Got Get response");
            List<User> content = ResponseConverter.GetDeserializedCollection<User>(response);

            int usersNumber = content.Count();
            int numberOfIds = content.Select(user => user.Id).Distinct().ToList().Count;
            LogManager.GetCurrentClassLogger().Info($"Got number of ids - {numberOfIds}");

            bool isEmptyNameOrUsername = content.Any(data => String.IsNullOrEmpty(data.Name.ToString()) || String.IsNullOrEmpty(data.Username.ToString()));
            bool isEmptyCompanyName = content.Any(data => String.IsNullOrEmpty(data.Company.Name.ToString()));

            string errorMessage = response.ErrorMessage;
            LogManager.GetCurrentClassLogger().Info($"Got Error message - {errorMessage}");
            HttpStatusCode statusCode = response.StatusCode;
            var code = (int)statusCode;
            LogManager.GetCurrentClassLogger().Info($"Got Status code - {statusCode} - {code}");

            Assert.AreEqual(10, usersNumber, $"List of users must contain 10 users, but contains {usersNumber}");
            Assert.AreEqual(10, numberOfIds, $"Not all ids are unique, we must have 10 Ids, but have only => {numberOfIds}");
            Assert.IsFalse(isEmptyNameOrUsername, "Some name or username is empty");
            Assert.IsFalse(isEmptyCompanyName, "Some company name is empty");
            Assert.AreEqual(200, code, $"Status code must be 200, but we got => {code}");
            Assert.IsNull(errorMessage, $"Error message must be null, but we got => {errorMessage}");
        }

        [Test]
        [Category("API")]
        public void ValidateIfUserIsNotifiedIfResourceDoesntExist()
        {
            RestResponse response = api.GetResponseInvalidEndpoint().Result;
            LogManager.GetCurrentClassLogger().Info("Got Not found error response");
            string errorMessage = response.ErrorMessage;
            LogManager.GetCurrentClassLogger().Info($"Got Error message - {errorMessage}");
            HttpStatusCode statusCode = response.StatusCode;
            var code = (int)statusCode;
            LogManager.GetCurrentClassLogger().Info($"Got Status code - {statusCode} - {code}");

            Assert.AreEqual(404, code, $"Status code must be 404, but we got => {code}");
            Assert.IsNull(errorMessage, $"Error message must be null, but we got => {errorMessage}");
        }
    }
}