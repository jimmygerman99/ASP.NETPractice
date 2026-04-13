using GameStore.Api.Dtos;
//We configure all the settings with everything
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();



const string GetGameEndpointName = "GetGame";
//http pipelines, this is where we make all the requests. This example is using the get and we are going to call the function and get Hello World
List<GameDto> games = [
    new (1, "MineCraft", "Adventure", 19.99M, new DateOnly(2009,08,29 )),
    new (2, "Fortnite", "Battle Royale", 0.00M, new DateOnly(2009,08,29 )),
    new (3, "COD B02", "Shooter", 59.99M, new DateOnly(2009,08,29 )),
    new (4, "COD MW2", "Shooter", 59.99M, new DateOnly(2009,08,29 )),
    new (5, "Apex Legends", "Battle Royale", 0.00M, new DateOnly(2009,08,29 )),
];
//Get /games
app.MapGet("/games", () => games)
.WithName(GetGameEndpointName);


//Get /games/Id
app.MapGet("/games/{id}", (int id) =>
{
    var game = games.Find(game => game.Id == id);
    

    return game is null ? Results.NotFound() : Results.Ok(game);
})
.WithName(GetGameEndpointName);



//Post

app.MapPost("/games", (CreateGameDto newGame) =>
{
    GameDto game = new(
        games.Count +  1,
        newGame.Name,
        newGame.Genre,
        newGame.Price,
        newGame.ReleaseDate
    );
    games.Add(game);

    return Results.CreatedAtRoute(GetGameEndpointName, new {id = game.Id}, game);
});

//Put
app.MapPut("/games/{id}", (int id, UpdateGameDto updatedGame) =>
{
    var index = games.FindIndex(game => game.Id == id);
    if(index == -1)
    {
        
    }
    games[index] = new GameDto(
        id,
        updatedGame.Name,
        updatedGame.Genre,
        updatedGame.Price,
        updatedGame.ReleaseDate
    );

    return Results.NoContent();
});

//Delete
app.MapDelete("/games/{id}", (int id) => {
    
    var index = games.Find(game => game.Id == id);

    if(index is null)
    {
        return Results.NotFound();
    }

    games.Remove(index);

    return Results.NoContent();
});


    




app.Run();
