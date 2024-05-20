namespace Controller.Middleware
{
    public class MiddlewareList
    {
        public static IApplicationBuilder CustomMiddleware(IApplicationBuilder builder)
        {
            builder.UseMiddleware<ExceptionMiddleware>();
            return builder;
        }
    }
}
