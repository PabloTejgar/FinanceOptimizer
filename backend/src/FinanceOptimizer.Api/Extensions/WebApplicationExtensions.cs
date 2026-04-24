using FinanceOptimizer.Api.Endpoints;

namespace FinanceOptimizer.Api.Extensions;

/// <summary>
/// Provides extension methods for configuring the HTTP request pipeline.
/// </summary>
public static class WebApplicationExtensions
{
    /// <summary>
    /// Configures the API middleware and endpoints.
    /// </summary>
    public static WebApplication UseApiPipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/openapi/v1.json", "Finance Optimizer API v1");
                options.RoutePrefix = "swagger";
            });
        }

        app.UseCors("Frontend");
        app.MapHealthChecks("/health");
        app.MapGet("/", () => Results.Ok(new
        {
            Application = "Finance Optimizer",
            Status = "Running"
        }))
        .WithTags("System");

        app.MapTransactionEndpoints();

        return app;
    }
}