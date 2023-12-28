using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using OData.Swagger.Services;
using TestODataProject;

var builder = WebApplication.CreateBuilder(args);
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Add services to the container.

builder.Services.AddControllers().AddOData(opt =>
{
    opt.AddODataModel();
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
});

builder.Services.AddHealthChecks();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen((config) =>
{
    config.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
    {
        Title = "DataPlatform OData Demo API",
        Description = "Swagger OData Demo",
        Version = "v1"
    });
});
builder.Services.AddOdataSwaggerSupport();
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
builder.Services.AddScoped<ChemicalPriceAndEconomicsService>();
builder.Services.AddScoped<MasService>();
builder.Configuration.AddEnvironmentVariables();
var postgreConnectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? builder.Configuration.GetConnectionString("Postgres");
builder.Services.AddDbContextFactory<PostgresContext>(options =>
{
    options.UseNpgsql(postgreConnectionString);
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
var app = builder.Build();
app.UseHttpsRedirection();

app.UseRouting();
app.UseCors("corsapp");
app.UseODataBatching();
app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthorization();
app.UseODataRouteDebug();
app.UseEndpoints(endpoints => endpoints.MapControllers());
app.UseSwagger(c => c.RouteTemplate = "/odata/{documentName}/swagger.json");
app.UseSwaggerUI(c => { c.SwaggerEndpoint("/odata/v1/swagger.json", "DataPlatform API"); c.RoutePrefix = "odata"; });
app.MapHealthChecks("odata/health");

app.Run();
