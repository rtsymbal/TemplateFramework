using System.Linq;
using System.Net;
using System.Text;
using FluentAssertions;
using Newtonsoft.Json;
using RestSharp;

namespace TemplateFramework.Base.Extensions.Rest
{
    public static class RestRequestExtensions
    {
        public static void WithAuthorization(this IRestRequest request, string token)
        {
            request.AddHeader("Authorization", $"Bearer {token}");
        }

        public static RestResponse<T> Get<T>(this IRestRequest request, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return request.Execute<T>(Method.GET, statusCode);
        }

        public static RestResponse<T> Post<T>(this IRestRequest request, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return request.Execute<T>(Method.POST, statusCode);
        }

        public static RestResponse Put(this IRestRequest request, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return request.Execute(Method.PUT, statusCode);
        }

        public static RestResponse Delete(this IRestRequest request, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return request.Execute(Method.DELETE, statusCode);
        }

        private static RestResponse Execute(this IRestRequest request, Method method, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            var client = RestFactory.CreateClient();
            request.Method = method;

            var response = client.Execute(request);

            return GetRestResponseRawData(request, response, statusCode);
        }

        private static RestResponse<T> Execute<T>(this IRestRequest request, Method method, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            var client = RestFactory.CreateClient();
            request.Method = method;

            var response = client.Execute(request);

            return GetRestResponseRawData<T>(request, response, statusCode);
        }

        private static RestResponse GetRestResponseRawData(IRestRequest request, IRestResponse response,
            HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            response.StatusCode.Should().Be(statusCode, CreateErrorMessage(request, response, statusCode));

            return new RestResponse(response, response.Content);
        }

        private static RestResponse<T> GetRestResponseRawData<T>(IRestRequest request, IRestResponse response,
            HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            response.StatusCode.Should().Be(statusCode, CreateErrorMessage(request, response, statusCode));

            var content = JsonConvert.DeserializeObject<T>(response.Content);

            return new RestResponse<T>(response, content);
        }

        private static string CreateErrorMessage(IRestRequest request, IRestResponse response, HttpStatusCode statusCode)
        {
            var message = new StringBuilder().AppendLine($"Expected: {statusCode}")
                .AppendLine($"Actual: {response.StatusCode}")
                .AppendLine($"Uri: {request.Resource}")
                .AppendLine($"Response Uri: {response.ResponseUri}");

            AddRequestParametersToMessage(message, request);

            message.AppendLine($"Response: {response.Content}");
            message.AppendLine($"Response error: {response.ErrorException}");

            return message.ToString();
        }

        private static void AddRequestParametersToMessage(StringBuilder message, IRestRequest request)
        {
            if (!request.Parameters.Any())
            {
                return;
            }

            message.Append("Request:");
            request.Parameters.ForEach(parameter =>
            {
                var textToLog = parameter.Value?.ToString() ?? parameter.ToString();
                message.AppendLine($"Parameter[{parameter.Name}]: {textToLog}");
            });
        }
    }

    public class RestResponse
    {
        public RestResponse(IRestResponse response, string content)
        {
            Response = response;
            Content = content;
        }

        public IRestResponse Response { get; set; }
        public string Content { get; set; }
    }

    public class RestResponse<T>
    {
        public RestResponse(IRestResponse response, T content)
        {
            Response = response;
            Content = content;
        }

        public IRestResponse Response { get; set; }
        public T Content { get; set; }
    }
}
