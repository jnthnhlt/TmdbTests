using System.Threading.Tasks;
using RestSharp;
using RestSharp.Deserializers;

namespace TestClients
{
    public class BaseController: BaseClient
    {
        public IRestClient Client { get; set; }

        public BaseController(IDeserializer serializer, string baseUrl)
        {
            Client = Create(baseUrl);
            Client.AddHandler("application/json", serializer);
            Client.AddHandler("text/json", serializer);
            Client.AddHandler("text/x-json", serializer);
        }

        private async Task<IRestResponse> ExecuteAsync(IRestRequest request)
        {
            var taskCompletion = new TaskCompletionSource<IRestResponse>();
            Client.ExecuteAsync(request, r => taskCompletion.SetResult(r));

            return (RestResponse)(await taskCompletion.Task);

        }
        private Task<IRestResponse<T>> ExecuteAsync<T>(IRestRequest request) where T : new()
        {
            var taskCompletion = new TaskCompletionSource<IRestResponse<T>>();
            Client.ExecuteAsync<T>(request, r => { taskCompletion.SetResult(r); });
 
            return taskCompletion.Task;
        }

        public IRestResponse<T> Get<T>(IRestRequest request) where T : new()
        {
            IRestResponse<T> response = new RestResponse<T>();
            Task.Run(async () => { response = await ExecuteAsync<T>(request); }).Wait();

            return response;
        }

        public IRestResponse Get(IRestRequest request)
        {
            Task<IRestResponse> response = ExecuteAsync(request);

            return response.Result;
        }
    }
}
