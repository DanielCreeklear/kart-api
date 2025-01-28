using Microsoft.EntityFrameworkCore;

public static class ServiceRegistrationExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<KartingCircuitService>();
    }

    public static void AddApplicationServices(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationDbContext>(options => 
            options.UseSqlServer(connectionString));

        services.AddScoped<IKartingCircuitRepository, KartingCircuitRepository>();
        
        services.AddSingleton<KartingCircuitService>();
    }
}