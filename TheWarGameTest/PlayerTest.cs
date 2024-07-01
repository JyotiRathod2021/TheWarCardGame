using TheWarCardGame.Model;
using TheWarCardGame.Services;

namespace TheWarGameTest
{
    [TestFixture]
    public class PlayerTest
    {
        [Test]
        public void Player_Should_Add_Cards_To_Deck()
        {
            var player = new Players("TestPlayer");
            var card = new Card(Suit.Hearts, FaceValue.Ace);

            player.AddCard(card);

            Assert.AreEqual(1, player.TotalCards);
        }

        [Test]
        public void Player_Should_Flip_Top_Card()
        {
            var player = new Players("TestPlayer");
            var card = new Card(Suit.Hearts, FaceValue.Ace);

            player.AddCard(card);
            var flippedCard = player.FlipCard();

            Assert.AreEqual(card, flippedCard);  //This checks the card is equal to card which flipped by player
            Assert.AreEqual(0, player.TotalCards); //This checks the count is 0 after player flipped the card
        }

        [Test]
        public void Player_Should_Collect_Cards()
        {
            var player = new Players("TestPlayer");
            var cards = new List<Card>
            {
                new Card(Suit.Hearts, FaceValue.Ace),
                new Card(Suit.Clubs, FaceValue.King)
            };

            player.CollectCard(cards);

            Assert.AreEqual(2, player.TotalCards); //This check the total no of collected card is 2
        }

        [Test]
        public void Player_Should_Flip_War_Cards()
        {
            var player = new Players("TestPlayer");
            var cards = new List<Card>
            {
                new Card(Suit.Hearts, FaceValue.Two),
                new Card(Suit.Clubs, FaceValue.Three),
                new Card(Suit.Diamonds, FaceValue.Four),
                new Card(Suit.Spades, FaceValue.Five)
            };

            foreach (var card in cards)
            {
                player.AddCard(card);
            }

            var flippedCards = player.FlipWarCard();

            Assert.AreEqual(4, flippedCards.Count); //This checks the count is equal to flippedWarCard
            Assert.AreEqual(0, player.TotalCards); //This checks the count is equal to 0 after flipping all flippedWarCard
        }
    }
}
