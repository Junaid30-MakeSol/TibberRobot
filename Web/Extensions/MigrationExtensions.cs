using Microsoft.EntityFrameworkCore;
using TibberRobot.Infrastructure.Data;

namespace Web.Extensions;

public static class MigrationExtensions
{
    public static void ApplyMigrations(IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        using ApplicationDbContext dbContext =
            scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        dbContext.Database.Migrate();
    }
}