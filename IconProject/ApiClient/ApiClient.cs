using RestSharp;

public class ApiClient
{
    private readonly RestClient _client;

    public ApiClient(string baseUrl)
    {
        _client = new RestClient(baseUrl);
    }

    public async Task<RestResponse<T>> GetAsync<T>(string endpoint) where T : new()
    {
        var request = new RestRequest(endpoint, Method.Get);
        return await _client.ExecuteAsync<T>(request);
    }
}
