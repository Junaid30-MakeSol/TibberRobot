using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TibberRobot.Application.Interfaces;
using TibberRobot.Application.Services;
using TibberRobot.Infrastructure;

namespace TibberRobot.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configure)
    {
        services.AddTransient<ITibberRobotService, TibberRobotService>();
        services.AddInfrastructureServices(configure);

        return services;
    }
}
