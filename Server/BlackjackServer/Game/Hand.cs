using BlackjackServer.Models;

namespace BlackjackServer.Game;

public class Hand
{
    public List<Card> Cards { get; } = new();

    public void AddCard(Card card) => Cards.Add(card);

    public int Score
    {
        get
        {
            int total = Cards.Sum(c => c.Value);
            int aceCount = Cards.Count(c => c.Rank == Rank.Ace);

            // Try to convert Aces from 1 to 11 without busting
            while (aceCount > 0 && total + 10 <= 21)
            {
                total += 10;
                aceCount--;
            }

            return total;
        }
    }

    public bool IsBlackjack => Cards.Count == 2 && Score == 21;
    public bool IsBusted => Score > 21;
}
