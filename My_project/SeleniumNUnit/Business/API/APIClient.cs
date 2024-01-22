using NLog;
using RestSharp;
using SeleniumNUnit.Core.API;

namespace SeleniumNUnit.Business.API
{
    public class APIClient
    {
        private readonly RestClient client;
        private IRequestBuilder _builder;

        public APIClient(string baseUrl)
        {
            var options = new RestClientOptions(baseUrl);
            client = new RestClient(options);
            LogManager.GetCurrentClassLogger().Info("Created new RestClient");
        }

        public async Task<RestResponse> CreateUser(string payload)
        {
            _builder = new RequestBuilder(Endpoints._createUser);
            LogManager.GetCurrentClassLogger().Trace("Creating POST request");

            var request = _builder
                .SetFormat(DataFormat.Json)
                .SetMethod(Method.Post)
                .AddHeader("Accept", "application/json")
                .AddBody(payload)
                .Create();

            LogManager.GetCurrentClassLogger().Info("Created new user");
            return await client.ExecuteAsync(request);
        }

        public async Task<RestResponse> GetUsersList()
        {
            _builder = new RequestBuilder(Endpoints._getKistOfUsers);
            LogManager.GetCurrentClassLogger().Trace("Creating GET request");

            var request = _builder
                .SetFormat(DataFormat.Json)
                .SetMethod(Method.Get)
                .AddHeader("Accept", "application/json")
                .Create();

            LogManager.GetCurrentClassLogger().Info("Created GET request");
            return await client.ExecuteAsync(request);
        }

        public async Task<RestResponse> GetResponseInvalidEndpoint()
        {
            _builder = new RequestBuilder(Endpoints._invalidEndpoint);
            LogManager.GetCurrentClassLogger().Trace("Creating invalid GET request");

            var request = _builder
                .SetFormat(DataFormat.Json)
                .SetMethod(Method.Get)
                .AddHeader("Accept", "application/json")
                .Create();

            LogManager.GetCurrentClassLogger().Info("Created invalid GET request");
            return await client.ExecuteAsync(request);
        }
    }
}