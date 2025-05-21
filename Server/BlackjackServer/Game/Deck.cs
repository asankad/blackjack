using BlackjackServer.Models;

namespace BlackjackServer.Game;

public class Deck
{
    private readonly List<Card> _cards = new();

    public Deck()
    {
        foreach (Suit suit in Enum.GetValues<Suit>())
            foreach (Rank rank in Enum.GetValues<Rank>())
                _cards.Add(new Card { Suit = suit, Rank = rank });

        Shuffle();
    }

    private void Shuffle()
    {
        var rng = new Random();
        _cards.Sort((a, b) => rng.Next(-1, 2));
    }

    public Card Draw()
    {
        if (_cards.Count == 0)
            throw new InvalidOperationException("Deck is empty");

        var card = _cards[0];
        _cards.RemoveAt(0);
        return card;
    }
}
