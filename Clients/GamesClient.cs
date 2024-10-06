using System;
using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GamesClient
{
    private readonly List<GameSummary> games = [
    new(){
        Id = 1,
        Name = "Game 1",
        Genre = "Fantasy",
        Price = 11.99M,
        ReleaseDate = new DateOnly(1993,01,03)
    },
        new(){
        Id = 2,
        Name = "Game 2",
        Genre = "Action",
        Price = 13.99M,
        ReleaseDate = new DateOnly(2001,03,06)
    },
        new(){
        Id = 3,
        Name = "Game 3",
        Genre = "Story",
        Price = 99.99M,
        ReleaseDate = new DateOnly(2024,06,06)
    }

    ];

    public GameSummary[] getGames() => [.. this.games];

}
