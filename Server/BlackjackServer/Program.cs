using BlackjackServer.Game;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<GameManager>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
