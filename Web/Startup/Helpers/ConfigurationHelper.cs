using Serilog;
using Web.Startup.AppSettings;

namespace Web.Startup.Helpers;

internal static class ConfigurationHelper
{
    internal static void ConfigureAppSettingsAndKeyVault(ConfigurationManager configuration, string contentRootPath, string environmentName)
    {
        configuration.SetBasePath(contentRootPath)
                .AddJsonFile("Configs/appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"Configs/appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
    }

    internal static string[] GetAllowedURLs(ConfigurationManager configuration)
    {
        var allowedURLsString = configuration.GetSection(AppSettingsSections.CORSPolicy).GetSection("AllowedURLs").Value ??
            ThrowConfigurationException<string>($"{AppSettingsSections.CORSPolicy}.AllowedURLs");

        return allowedURLsString.Split(',');
    }

    #region Private common helper methods

    /// <summary>
    /// Throws a configuration exception with a specified error message.
    /// </summary>
    /// <typeparam name="T">The type of the configuration property.</typeparam>
    /// <param name="property">The name of the configuration property.</param>
    /// <returns>Throws a <see cref="ConfigurationException"/>.</returns>
    internal static T ThrowConfigurationException<T>(string property)   // To be private as soon as Cosmos Config is moved here
    {
        var message = $"Configuration error for property {property}, type {typeof(T).Name}";
        Log.Error(message);
        throw new ConfigurationException(message);
    }
    #endregion
}