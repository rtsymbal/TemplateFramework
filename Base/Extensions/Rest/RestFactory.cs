using RestSharp;

namespace TemplateFramework.Base.Extensions.Rest
{
    public static class RestFactory
    {
        private const int DefaultTimeoutInMilliseconds = 30 * 1000;

        public static IRestClient CreateClient(int timeout)
        {
            return new RestClient
            {
                Timeout = timeout
            };
        }

        public static IRestClient CreateClient()
        {
            return CreateClient(DefaultTimeoutInMilliseconds);
        }

        public static IRestRequest CreateRequest(string url)
        {
            return new RestRequest(url);
        }
    }
}
