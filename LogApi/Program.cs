using LogApi;
using LogApi.BusinessObjects.Configuration;
using LogApi.BusinessObjects.Loggers;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ILogConfigurationProvider, LogLogConfigurationProvider>();
// We could have probably better performance if this was singleton.
// Would have to take into consideration at what point is the config changing.
// If we just use primitive appsettings.json like POC then singleton is better
// But if it can be changed dynamically in database without restarting site, then this is more safe.
builder.Services.AddTransient<ILogApiLogger>(x =>
{
    var configProvider = (ILogConfigurationProvider)x.GetService(typeof(ILogConfigurationProvider));

    if (configProvider == null)
    {
        throw new ArgumentException("Could not retrieve configProvider.", nameof(configProvider));
    }

    return LogApiLoggerFactory.CreateLogger(configProvider.GetLoggerDestination());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();