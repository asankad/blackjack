namespace BlackjackServer.Game;

public class BlackjackGame
{
    private readonly List<Player> _players = new();
    private readonly Deck _deck = new();

    public void AddPlayer(string id, string name)
    {
        if (_players.Count >= 4) throw new Exception("Maximum players reached");
        _players.Add(new Player(id, name));
    }

    public void DealInitialCards()
    {
        foreach (var player in _players)
            for (int i = 0; i < 2; i++)
                player.Hit(_deck.Draw());
    }

    public void PlayerHit(string playerId)
    {
        var player = _players.First(p => p.Id == playerId);
        if (player.HasStood || player.Hand.IsBusted) return;

        player.Hit(_deck.Draw());
    }

    public void PlayerStand(string playerId)
    {
        var player = _players.First(p => p.Id == playerId);
        player.Stand();
    }

    public IEnumerable<Player> GetPlayers() => _players;

    public IEnumerable<Player> GetWinners()
    {
        int best = _players
            .Where(p => !p.Hand.IsBusted)
            .Select(p => p.Hand.Score)
            .DefaultIfEmpty(0)
            .Max();

        return _players.Where(p => p.Hand.Score == best && !p.Hand.IsBusted);
    }

    public bool AllPlayersDone => _players.All(p => p.HasStood || p.Hand.IsBusted);
}
