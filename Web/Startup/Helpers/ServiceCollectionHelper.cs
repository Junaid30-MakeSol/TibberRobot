namespace Web.Startup.Helpers;

public static class ServiceCollectionHelper
{
    internal static void AddCors(IServiceCollection services, string corsPolicyName, string[] allowedURLs) =>
     services.AddCors(options =>
     {
         options.AddPolicy(name: corsPolicyName,
             builder =>
             {
                 if (string.IsNullOrEmpty(allowedURLs[0]))
                     builder.AllowAnyOrigin();
                 else
                     builder.WithOrigins(allowedURLs);

                 builder.AllowAnyHeader()
                 .AllowAnyMethod();
             });
     });
}

