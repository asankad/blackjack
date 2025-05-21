using System.Collections.Concurrent;

namespace BlackjackServer.Game;

public class GameManager
{
    private readonly ConcurrentDictionary<string, BlackjackGame> _games = new();

    public string CreateGame()
    {
        var id = Guid.NewGuid().ToString();
        var game = new BlackjackGame();
        _games[id] = game;
        return id;
    }

    public BlackjackGame? GetGame(string id)
    {
        _games.TryGetValue(id, out var game);
        return game;
    }
}
