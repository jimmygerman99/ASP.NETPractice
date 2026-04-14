using GameStore.Api.Dtos;
using GameStore.Api.endpoints;
//We configure all the settings with everything
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGamesEndpoints();


app.Run();
