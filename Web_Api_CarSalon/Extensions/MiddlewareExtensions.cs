using Web_Api_CarSalon.Middlewares;

namespace Web_Api_CarSalon.Extensions
{
    public static class MiddlewareExtensions
    {
        public static void UseGlobalExceptionHandler(this WebApplication app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
