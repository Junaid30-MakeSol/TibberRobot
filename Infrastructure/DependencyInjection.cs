using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TibberRobot.Infrastructure.Common.Interfaces;
using TibberRobot.Infrastructure.Data;
using TibberRobot.Infrastructure.Interfaces;
using TibberRobot.Infrastructure.Repositories;

namespace TibberRobot.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        //var server = configuration["server"] ?? "localhost";
        //var database = configuration["database"] ?? "TibberRobotDB";
        //var port = configuration["port"] ?? "1433";
        //var password = configuration["password"] ?? "Bscs14f018";
        //var user = configuration["user"] ?? "sa";

        //var connectionString = $"Data Source={server}, {port}; Initial Catalog={database}; user id={user};password={password};Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";
        //Guard.Against.Null(connectionString, message: "Connection string 'DefaultConnection' not found.");

        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        services.AddScoped<ITiberRobotRepository, TiberRobotRepository>();

        services.AddSingleton(TimeProvider.System);

        return services;
    }
}
