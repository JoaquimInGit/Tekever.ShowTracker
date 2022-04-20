using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Tekever.ShowTracker.Application;
using Tekever.ShowTracker.Repository;
using Tekever.ShowTracker.Repository.Contexts;
using Tekever.ShowTracker.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
/*
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});*/
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddPersistenceServices(builder.Environment, builder.Configuration);
builder.Services.AddServices();
builder.Services.AddApplication(builder.Configuration);
builder.Services.Configure<ShowTrackerConnection>(
builder.Configuration.GetSection("TekeverShowsStoreDatabase"));

builder.Services.AddDbContext<ShowTrackerContext>();

builder.Services.ConfigureServices();
builder.Services.AddCors(o =>
    o.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("https://www.accounts.google.com/", "https://localhost:7276/")
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    }));

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Access", policy =>
    {
        policy.RequireRole("user");
    });
});

var app = builder.Build();

using var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetRequiredService<ShowTrackerContext>();
//db.Database.EnsureDeleted();
db.Database.EnsureCreated();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
/*
app.Use(async (context, next) =>
{
    var pls = context.Request.Headers.Authorization.ToString();
    if (!string.IsNullOrEmpty(jwt))
    {
        context.Request.Headers.Add("Authorization", "Bearer " + jwt);
    }
    else
    {
        var jwtCookies = context.Request.Cookies["token"];
        if (!string.IsNullOrEmpty(jwtCookies))
        {
            context.Request.Headers.Add("Authorization", "Bearer " + jwtCookies);
        }
    }

    await next();
});*/
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();
