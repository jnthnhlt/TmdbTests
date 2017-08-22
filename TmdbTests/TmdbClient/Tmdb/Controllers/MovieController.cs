using RestSharp;
using TmdbData;
using JsonSerializer = TestClients.Util.JsonSerializer;

namespace TestClients.Tmdb.Controllers
{
    public class MovieController : BaseController
    {
        public MovieController(string baseUrl, string apiKey) : base(new JsonSerializer(), baseUrl)
        {
            ApiKey = apiKey;
        }

        public string ApiKey;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="movieId"></param>
        /// <param name="language"></param>
        /// <param name="appendToResponse"></param>
        /// <returns></returns>
        public IRestResponse<Movie> GetMovieDetails(int movieId, string language = "", string appendToResponse = "")
        {
            RestRequest request = new RestRequest("/movie/{movie_id}", Method.GET);
            request.AddUrlSegment("movie_id", movieId);

            if (language != "")
                request.AddQueryParameter("language", language);

            if (appendToResponse != "")
                request.AddQueryParameter("append_to_response", appendToResponse);

            request.AddQueryParameter("api_key", ApiKey);

            return Get<Movie>(request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="movieId"></param>
        /// <param name="language"></param>
        /// <param name="appendToResponse"></param>
        /// <returns></returns>
        public IRestResponse GetMovieDetailsResponse(int movieId, string language = "", string appendToResponse = "")
        {
            RestRequest request = new RestRequest("/movie/{movie_id}", Method.GET);
            request.AddUrlSegment("movie_id", movieId);

            if (language != "")
                request.AddQueryParameter("language", language);

            if (appendToResponse != "")
                request.AddQueryParameter("appendToResponse", appendToResponse);

            request.AddQueryParameter("api_key", ApiKey);

            return Get(request);
        }
    }
}