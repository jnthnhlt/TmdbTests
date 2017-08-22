using NUnit.Framework;
using TestClients.Tmdb.Controllers;

namespace TmdbTests.Tests
{
    public class BaseTest
    {
        public BaseTest()
        {
            BaseUrl = TestContext.Parameters["baseUrl"];
            ApiKey = TestContext.Parameters["apiKey"];
        }

        public static string ApiKey;
        public static string BaseUrl;
        public MovieController Movies;

        
    }
}
