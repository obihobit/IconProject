using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

public class ApiClient
{
    private readonly RestClient _client;

    public ApiClient(string baseUrl)
    {
        _client = new RestClient(baseUrl, configureSerialization: s => s.UseNewtonsoftJson());
    }

    public async Task<RestResponse<T>> GetAsync<T>(string endpoint) where T : new()
    {
        var request = new RestRequest(endpoint, Method.Get);
        var response = await _client.ExecuteAsync<T>(request);
        return response;
    }
}
