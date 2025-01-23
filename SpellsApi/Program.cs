using Spells;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton(TimeProvider.System);
builder.Services.AddScoped<ISpellsService, SpellsService>();

var app = builder.Build();

app.Use((context, next) =>
{
    var timeProvider = app.Services.GetRequiredService<TimeProvider>();
    var timestamp = timeProvider.GetTimestamp();
    var result = next();
    var elapsed = timeProvider.GetElapsedTime(timestamp);

    app.Logger.LogInformation("Elapsed milliseconds for {Action}: {Elapsed}", context.Request.Path, elapsed.TotalMilliseconds);

    return result;
});
app.RegisterEndpoints();

app.Run();
