using ObligAtions.Interface;
using ObligAtions.ViewModel;
using System.Net;
using System.Text.Json;

namespace ObligAtions.Middlewares
{
    public class ErrorWrappingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorWrappingMiddleware> _logger;
        private readonly IHistory _history;

        public ErrorWrappingMiddleware(RequestDelegate next, ILogger<ErrorWrappingMiddleware> logger, IHistory history)
        {
            _next = next;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _history = history;
        }
        private static void writeErrorResponse(HttpContext Context, string mess)
        {
            Context.Response.ContentType = "application/json";

            using (var writer = new Utf8JsonWriter(Context.Response.BodyWriter))
            {
                writer.WriteStartObject();
                writer.WriteNumber("statusCode", StatusCodes.Status404NotFound);
                writer.WriteString("description", HttpStatusCodeDescriptions.Unhandled);
                writer.WriteString("data", mess.ToString());
                writer.WriteEndObject();
                writer.Flush();
            }
        }
        private static string GetResourceName(HttpContext httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException(nameof(httpContext));

            Endpoint endpoint = httpContext.GetEndpoint();
            if (endpoint == null && (httpContext.Request.Path.ToString() == "/signin-oidc" || httpContext.Request.Path.ToString() == "/favicon.ico"))
            {
                return httpContext.Request.Path.ToString();
            }
            else if (endpoint == null)
            {
                return httpContext.Request.Path.ToString();
            }
            return endpoint.DisplayName;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                var parameters = context.Request.Query;
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                string routeName = GetResourceName(context); // get routeName 
                var statusCode = context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                string errorlog = "[" + statusCode + "]/[" + routeName + "]: " + ex.Message;
                HistoryViewModel result = new HistoryViewModel()
                {
                    Desc = errorlog,
                    type = 0,
                    ResourceName = context.Request.Path,
                };                
                // write to Logging Table                
                await _history.CreateHistory(result);
                writeErrorResponse(context, ex.Message);
            }
        }
    }
}
