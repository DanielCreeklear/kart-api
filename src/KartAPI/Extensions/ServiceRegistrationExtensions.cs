using Microsoft.Extensions.DependencyInjection;

public static class ServiceRegistrationExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<KartingCircuitService>();
    }
}