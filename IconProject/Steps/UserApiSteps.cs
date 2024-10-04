using RestSharp;
using TechTalk.SpecFlow;

[Binding]
public class UserApiSteps
{
    private readonly ApiClient _apiClient;
    private RestResponse<UserResponse> _response;

    public UserApiSteps()
    {
        _apiClient = new ApiClient("https://reqres.in");
    }

    [Given(@"I send a GET request to ""(.*)""")]
    public async Task GivenISendAGETRequestTo(string endpoint)
    {
        _response = await _apiClient.GetAsync<UserResponse>(endpoint);
    }

    [Then(@"response status code should be (.*)")]
    public void ThenTheResponseStatusCodeShouldBe(int statusCode)
    {
        Assert.Equal(statusCode, (int)_response.StatusCode);
    }

    [Then(@"response should contain (.*) users")]
    public void ThenTheResponseShouldContainUsers(int userCount)
    {
        Assert.Equal(userCount, _response.Data.Data.Count);
    }

    [Then(@"page number should be (.*)")]
    public void ThenThePageNumberShouldBe(int pageNumber)
    {
        Assert.Equal(pageNumber, _response.Data.Page);
    }

    [Then(@"user with first name ""(.*)"", last name ""(.*)"", email ""(.*)"", and avatar URL ""(.*)"" should be present")]
    public void ThenTheUserWithFirstNameLastNameEmailAndAvatarShouldBePresent(string firstName, string lastName, string email, string avatarUrl)
    {
        var user = _response.Data.Data.FirstOrDefault(u => u.FirstName == firstName && u.LastName == lastName);
        Assert.NotNull(user);
        Assert.Equal(email, user.Email);
        Assert.Equal(avatarUrl, user.Avatar);
    }

    [Then(@"no users should be returned")]
    public void ThenNoUsersShouldBeReturned()
    {
        Assert.Empty(_response.Data.Data); 
    }
}
