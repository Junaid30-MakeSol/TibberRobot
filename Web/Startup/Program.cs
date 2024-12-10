using TibberRobot.Application;
using Web.Extensions;
using Web.Startup.Helpers;

#region Members
const string CORSPolicyName = "LocalPolicy";
#endregion


var builder = WebApplication.CreateBuilder(args);

ConfigurationHelper.ConfigureAppSettingsAndKeyVault(builder.Configuration, builder.Environment.ContentRootPath, builder.Environment.EnvironmentName);
var services = builder.Services;

ServiceCollectionHelper.AddCors(services, CORSPolicyName, ConfigurationHelper.GetAllowedURLs(builder.Configuration));

// Add services to the container.
services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddApplicationServices(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(CORSPolicyName);
app.UseAuthorization();

app.MapControllers();
MigrationExtensions.ApplyMigrations(app);
app.Run();

