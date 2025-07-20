namespace IdentityForge.Web.Extensions;

public static class SerilogExtensions
{
    public static IHostBuilder UseSerilogWithDefaults(this IHostBuilder host)
    {
        return host.UseSerilog((context, serviceProvider, loggerConfig) =>
        {
            loggerConfig
                .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
                .Enrich.WithExceptionDetails(new DestructuringOptionsBuilder()
                    .WithDefaultDestructurers()
                    .WithDestructurers([new DbUpdateExceptionDestructurer()]))
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {SourceContext}: {Message:lj}{NewLine}{Exception}");
        });
    }

    public static IApplicationBuilder UseSerilogRequestLoggingWithDefaults(this IApplicationBuilder app)
    {
        return app.UseSerilogRequestLogging(options =>
        {
            options.IncludeQueryInRequestPath = true;
        });
    }
}

