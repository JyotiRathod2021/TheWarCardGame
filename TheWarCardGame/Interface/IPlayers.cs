
using TheWarCardGame.Model;

namespace TheWarCardGame.Interface
{
    public interface IPlayers
    {
        string Name { get; }
        int TotalCards {  get; }
        bool HasCards { get; }
        void AddCard(Card card);
        Card FlipCard();
        List<Card> FlipWarCard();
        void CollectCard(List<Card> cards);
        bool HasEnoughCard(int count);
    }
}
