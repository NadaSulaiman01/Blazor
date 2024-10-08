using System;
using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GamesClient
{
    private readonly List<GameSummary> games = [
    new(){
        Id = 1,
        Name = "Game 1",
        Genre = "Racing",
        Price = 11.99M,
        ReleaseDate = new DateOnly(1993,01,03)
    },
        new(){
        Id = 2,
        Name = "Game 2",
        Genre = "Kids and Family",
        Price = 13.99M,
        ReleaseDate = new DateOnly(2001,03,06)
    },
        new(){
        Id = 3,
        Name = "Game 3",
        Genre = "Roleplaying",
        Price = 99.99M,
        ReleaseDate = new DateOnly(2024,06,06)
    }

    ];

    public GameSummary[] getGames() => [.. this.games];

    public void AddGame(GameDetails game)
    {
        Genre genre = GetGenreById(game.GenreId);

        GameSummary gameSummary = new()
        {
            Id = games.Count + 1,
            Name = game.Name,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate,
            Genre = genre.Name
        };
        games.Add(gameSummary);
    }


    public GameDetails GetGame(int id)
    {
        GameSummary gameSummary = GetGameSummaryById(id);
        var genre = new GenresClient().GetGenres().Single(g =>
        string.Equals(gameSummary.Genre, g.Name, StringComparison.OrdinalIgnoreCase));

        return new GameDetails()
        {
            Id = gameSummary.Id,
            Name = gameSummary.Name,
            Price = gameSummary.Price,
            GenreId = genre.Id.ToString(),
            ReleaseDate = gameSummary.ReleaseDate

        };


    }

    public void UpdateGame(GameDetails gameDetails){
        GameSummary existingGameSummary = GetGameSummaryById(gameDetails.Id);
        Genre genre = GetGenreById(gameDetails.GenreId);

        existingGameSummary.Name = gameDetails.Name;
        existingGameSummary.Genre = genre.Name;
        existingGameSummary.Price = gameDetails.Price;
        existingGameSummary.ReleaseDate = gameDetails.ReleaseDate;
    }
    public void DeleteGame(int id){
        var game = GetGameSummaryById(id);
        games.Remove(game);
    }
    
    private static Genre GetGenreById(string? genreId)
    {
        ArgumentException.ThrowIfNullOrEmpty(genreId);
        return new GenresClient().GetGenres().Single(g => g.Id == int.Parse(genreId));
    }

    private GameSummary GetGameSummaryById(int id)
    {
        GameSummary? gameSummary = games.Single(g => g.Id == id);
        ArgumentNullException.ThrowIfNull(gameSummary);
        return gameSummary;
    }
}
