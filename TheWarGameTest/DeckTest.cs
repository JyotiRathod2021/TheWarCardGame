using TheWarCardGame.Interface;
using TheWarCardGame.Model;
using TheWarCardGame.Services;

namespace TheWarGameTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Deck_Should_Have_52_Cards_After_Initialization()
        {
            IDeck deck = new Deck();
            Assert.AreEqual(52, deck.Cards.Count);
        }

        [Test]
        public void Deck_Should_Contain_All_Suits_And_Values()
        {
            var deck = new Deck();
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (FaceValue faceValue in Enum.GetValues(typeof(FaceValue)))
                {
                    Assert.IsTrue(deck.Cards.Any(c => c.Suit == suit && c.FaceValue == faceValue));
                }
            }
        }

        [Test]
        public void Deck_Should_Shuffle_Cards()
        {
            var deck = new Deck();
            var originalOrder = deck.Cards.ToList();
            deck.ShuffleCard();
            var shuffledOrder = deck.Cards;

            CollectionAssert.AreNotEqual(originalOrder, shuffledOrder);
        }
    }
}