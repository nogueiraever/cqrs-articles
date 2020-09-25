using System.Collections.Generic;
using System.Net;
using System.Text.Json.Serialization;

namespace Core
{
    public class Response
    {
        public Response(string message, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            Messages = new List<string>() { message };
            StatusCode = statusCode;
        }

        public Response(IEnumerable<string> messages, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            Messages = messages;
            StatusCode = statusCode;
        }

        public Response(object data, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            Data = data;
            StatusCode = statusCode;
        }

        public object Data { get; set; }
        public IEnumerable<string> Messages { get; set; }

        [JsonIgnore]
        public HttpStatusCode StatusCode { get; set; }
    }
}