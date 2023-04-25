namespace ObligAtions.Middlewares
{
    public static class MiddlewareServices
    {
        public static IApplicationBuilder UseErrorWrapping(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorWrappingMiddleware>();
        }
    }
}
