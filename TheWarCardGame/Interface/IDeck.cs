using TheWarCardGame.Model;

namespace TheWarCardGame.Interface
{
    public interface IDeck
    {
        List<Card> Cards { get; }
        void ShuffleCard();
    }
}
