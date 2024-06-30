using TheWarCardGame.Interface;
using TheWarCardGame.Model;

namespace TheWarCardGame.Services
{
    public class Deck : IDeck
    {
        public List<Card> Cards { get; }
        public Deck()
        {
            Cards = new List<Card>();
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (FaceValue facevalue in Enum.GetValues(typeof(FaceValue)))
                {
                    Cards.Add(new Card(suit, facevalue));
                }
            }

        }
        public void ShuffleCard()
        {
            Random rng = new Random();
            int n = Cards.Count;
            for (int i = n - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                var value = Cards[i];
                Cards[i] = Cards[j];
                Cards[j] = value;
            }

        }
    }
}
