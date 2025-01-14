using System.Text.Json;
using System.Text.Json.Serialization;
using JSONPlaceholder.TestFramework.Business.Models;
using JSONPlaceholder.TestFramework.Core.Utilities;
using RestSharp;
using RestSharp.Serializers.Json;

namespace JSONPlaceholder.TestFramework.Business.Client;

public class JsonPlaceholderClient
{
    private Logger<JsonPlaceholderClient> logger = new();
    private readonly RestClient client;

    public JsonPlaceholderClient(string url)
    {
        var serializerOptions = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        client = new RestClient(
            baseUrl: new (url),
            configureSerialization: s => s.UseSystemTextJson(serializerOptions),
            useClientFactory: true
        );
    }

    public async Task<RestResponse<List<User>>> GetUsersAsync()
    {
        var request = new RestRequest("/users");

        logger.Info($"Starting GET request to {request.Resource}");
        var response = await client.ExecuteGetAsync<List<User>>(request);

        logger.Info($"Response: Status code: {response.StatusDescription}\nContent:{response.Content}\n");

        return response;
    }

    public async Task<RestResponse<User>> CreateUserAsync(User user)
    {
        var request = new RestRequest("/users").AddJsonBody(user);

        logger.Info($"Starting POST request to {request.Resource} with adding to body {user}");
        var response = await client.ExecutePostAsync<User>(request);
        
        logger.Info($"Response: Status code: {response.StatusDescription}\nContent:{response.Content}\n");

        return response;
    }

    public async Task<RestResponse> GetInvalidResource()
    {
        var request = new RestRequest("/invalidendpoint");

        logger.Info($"Starting GET request to {request.Resource}");
        var response = await client.ExecuteGetAsync(request);

        logger.Info($"Response: Status code: {response.StatusDescription}\nContent:{response.Content}\n");

        return response;
    }

}
