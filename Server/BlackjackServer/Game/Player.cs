using BlackjackServer.Models;

namespace BlackjackServer.Game;

public class Player
{
    public string Id { get; set; }
    public string Name { get; set; }
    public Hand Hand { get; } = new();
    public bool HasStood { get; set; }

    public Player(string id, string name)
    {
        Id = id;
        Name = name;
    }

    public void Hit(Card card) => Hand.AddCard(card);
    public void Stand() => HasStood = true;
}
