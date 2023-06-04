using Honeycomb.OpenTelemetry;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Trace;

public static class ServiceCollectionExtensions
{
    public static void AddHoneycombOpenTelemetry(this IServiceCollection services)
    {
        services.ConfigureOpenTelemetryTracerProvider((sp, a) => {
            var honeycombOptions = sp.GetRequiredService<IConfiguration>()
                .GetSection(HoneycombOptions.ConfigSectionName)
                .Get<HoneycombOptions>();
            a.AddHoneycomb(honeycombOptions);
        });
    }
}