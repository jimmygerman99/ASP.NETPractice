namespace GameStore.Api.Dtos;

//Contract between Client and Server 
//Represents a shared agreement between how data will be transferred and used
public record GameDto(
    int Id,
    string Name,
    string Genre,
    decimal Price,
    DateOnly ReleaseDate
);
