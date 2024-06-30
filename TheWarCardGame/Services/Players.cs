using TheWarCardGame.Interface;
using TheWarCardGame.Model;

namespace TheWarCardGame.Services
{
    public class Players : IPlayers
    {
        private readonly Queue<Card> _deck;
        public string Name { get; }
        public Players(String name)
        {
            Name = name;
            _deck = new Queue<Card>();
        }
        public bool HasCards
        {
            get { return _deck.Count > 0; }
        }
        public int TotalCards
        {
            get { return _deck.Count; }
        }
        public void AddCard(Card card)
        {
            _deck.Enqueue(card);
        }
        public Card FlipCard()
        {
            return _deck.Dequeue();
        }
        public List<Card> FlipWarCard()
        {
            var Card = new List<Card>();
            for (int i = 0; i < 4; i++)
            {
                Card.Add(_deck.Dequeue());
            }
            return Card;
        }
        public void CollectCard(List<Card> cards)
        {
            foreach (Card card in cards)
            {
                _deck.Enqueue(card);
            }
        }
        public bool HasEnoughCard(int count)
        {
            return _deck.Count >= count;
        }

    }
}
