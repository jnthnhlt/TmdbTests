using System.Net;
using NUnit.Framework;
using RestSharp;
using TestClients.Tmdb.Controllers;
using TmdbData;
using TmdbTests.Util;

namespace TmdbTests.Tests.Movies
{
    [TestFixture]
    public class GetDetailsTests : BaseTest
    {
        public IRestResponse<Movie> Response;

        [OneTimeSetUp]
        public void SetUp()
        {
            Movies = new MovieController(BaseTest.BaseUrl, BaseTest.ApiKey);
        }

        [TestCase(76341, HttpStatusCode.OK, TestName = "Should Return 200 HTTP Response with Valid Id")]
        [TestCase(123121, HttpStatusCode.NotFound, TestName = "Should Return 404 HTTP Response with Invalid Id")]
        [TestCase(123121, HttpStatusCode.OK, TestName = "Example of a failing test")]
        public void ShouldReturnProperHttpResponse(int id, HttpStatusCode expectedStatusCode)
        {
            Response = Movies.GetMovieDetails(id);
            Assert.That(Response.StatusCode, Is.EqualTo(expectedStatusCode), "Response: " + Response.StatusCode + "; Response: " +Response.Content);
        }

        [Test, TestCaseSource(typeof(Import), nameof(Import.MovieDataTestCases))]
        public void ShouldGetCorrectMovieTitle(Movie movie, string cultureCode)
        {
            Response = Movies.GetMovieDetails(movie.id, cultureCode);
            Assert.That(Response.Data.title, Is.EqualTo(movie.title));
        }

        [TestCase("alternative_titles", TestName = "Should Return Alternative Titles with Appending Alternative Titles Resource")]
        [TestCase("images", TestName = "Should Return Images with Appending Image Resource")]
        public void ShouldGetAdditionalResources_WhenUsingValidId(string resource)
        {
            Response = Movies.GetMovieDetails(76341, "", resource);
            Assert.That(Response.Data, Has.Property(resource));
        }
    }
}