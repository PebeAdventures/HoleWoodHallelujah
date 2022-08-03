using TvSeriesApi;
using TvSeriesApi.Data;
using TvSeriesApi.Data.Context;
using TvSeriesApi.Data.DAL.Interfaces;
using TvSeriesApi.Data.DAL.Repositories;
using Serilog;
using TvSeriesApi.Profiles;

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
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
builder.Services.AddSqlServer<TvSeriesApiContext>(builder.Configuration.GetConnectionString("HollywoodDB"));
builder.Services.AddScoped<IActorRepository, ActorRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<ITvSeriesRepository, TvSeriesRepository>();
builder.Services.AddScoped<IEpisodeRepository, EpisodeRepository>();
builder.Services.AddScoped<ISeasonRepository, SeasonRepository>();
builder.Services.AddScoped<IEpisodeService, EpisodeService>();
builder.Services.AddScoped<IActorService, ActorService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.EnableAnnotations());
var mapper = mapConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
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