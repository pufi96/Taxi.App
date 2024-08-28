using RestSharp;
using Taxi.App.Common;

namespace Taxi.App;

public static class Api
{
    private static RestClient _client;
    private static bool authorizationSet = false;

    public static string BaseUrl { get; set; } = "https://localhost:7020/api/";

    public static RestClient Client
    {
        get
        {
            if (_client == null)
            {
                _client = new RestClient(BaseUrl);
            }

            var user = SecureStorage.Default.GetUser();

            if (user != null && !authorizationSet)
            {
                authorizationSet = true;
                _client.AddDefaultHeader("Authorization", "Bearer " + user.Token);
            }

            return _client;
        }
    }
}
