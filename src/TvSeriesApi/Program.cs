using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;
using TvSeriesApi;
using TvSeriesApi.Data.Context;
using TvSeriesApi.Data.DAL.Interfaces;
using TvSeriesApi.Data.DAL.Repositories;

using Serilog;

using TvSeriesApi.Profiles;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var mapConfig = new AutoMapper.MapperConfiguration(c =>
{
    c.AddProfile(new ActorProfile());
    c.AddProfile(new EpisodeProfile());
    c.AddProfile(new GenreProfile());
    c.AddProfile(new SeasonProfile());
    c.AddProfile(new TvSeriesProfile());
});

var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();

builder.Services.AddCors(p => p.AddPolicy("default", builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
builder.Services.AddSqlServer<TvSeriesApiContext>(builder.Configuration.GetConnectionString("HollywoodDB"));
builder.Services.AddScoped<IActorRepository, ActorRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<ITvSeriesRepository, TvSeriesRepository>();
builder.Services.AddScoped<IEpisodeRepository, EpisodeRepository>();
builder.Services.AddScoped<ISeasonRepository, SeasonRepository>();
builder.Services.AddScoped<IEpisodeService, EpisodeService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<ITVSeriesService, TVSeriesService>();
builder.Services.AddScoped<IActorService, ActorService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ISeasonService, SeasonService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(swagger =>
{
    swagger.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "JWT Token Authentication API",
            Description = "ASP.NET Core 3.1 Web API"
        });
    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
        });
    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}

            }
        });
    swagger.EnableAnnotations();
});

var mapper = mapConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

var app = builder.Build();
app.UseAuthentication();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("corsapp");
app.UseAuthorization();

app.MapControllers();

app.Run();