using RestSharp;

namespace TestClients
{
    public interface IBaseClient
    {
        IRestClient Create(string baseUrl);
    }
    public class BaseClient : IBaseClient
    {
        public IRestClient Create(string baseUrl)
        {
            return new RestClient(baseUrl);
        }
    }
}
