using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace AzureShop.Extensions.HealthCheck;
public static class Extensions
{
    public static WebApplication MapHealtCheck(this WebApplication app)
    {
        app.MapGet("/health", async (http) =>
        {
            http.Response.StatusCode = StatusCodes.Status200OK;
            await http.Response.WriteAsync("OK");
        });

        // comment added for testing

        return app;
    }
}

