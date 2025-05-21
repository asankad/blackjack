namespace BlackjackServer.Models;

public enum Suit { Spades, Hearts, Diamonds, Clubs }

public enum Rank
{
    Ace = 1, Two, Three, Four, Five, Six, Seven,
    Eight, Nine, Ten, Jack, Queen, King
}

public class Card
{
    public Suit Suit { get; set; }
    public Rank Rank { get; set; }

    public int Value => Rank switch
    {
        Rank.Jack or Rank.Queen or Rank.King => 10,
        _ => (int)Rank
    };

    public override string ToString() => $"{Rank} of {Suit}";
}
