using System.Text.Json.Serialization;
using CsgoMatchData.Logic.Providers;
using CsgoMatchData.Logic.Providers.Interfaces;
using CsgoMatchData.Logic.Services;
using CsgoMatchData.Logic.Services.Interfaces;
using CsgoMatchData.Parser.Services;

var builder = WebApplication.CreateBuilder(args);

var fileName = builder.Configuration["FileName"];
var contentRoot = builder.Configuration.GetValue<string>(WebHostDefaults.ContentRootKey);
var filePath = $"{contentRoot}/{fileName}";

var rounds = MatchDataParserService.GetRoundsFromFile(filePath);
builder.Services.AddSingleton<IMatchDataProvider>(new MatchDataProvider(rounds));
builder.Services.AddScoped<IKillDeathCountService, KillDeathCountService>();
builder.Services.AddScoped<IMatchTeamsService, MatchTeamsService>();
builder.Services.AddScoped<IRoundResultService, RoundResultService>();
builder.Services.AddScoped<IMatchResultService, MatchResultService>();
builder.Services.AddScoped<IKillDistanceService, KillDistanceService>();

builder
    .Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(_ => true));

app.Run();
