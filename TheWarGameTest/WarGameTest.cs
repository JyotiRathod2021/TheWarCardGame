using TheWarCardGame.Model;
using TheWarCardGame.Services;

namespace TheWarGameTest
{
    [TestFixture]
    public class WarGameTest
    {
        [Test]
        public void Game_Should_Initialize_With_Correct_Number_Of_Players()
        {
            int numPlayers = 4;

            var game = new WarGame(numPlayers);

            Assert.AreEqual(numPlayers, game.players.Count); //This checks no of players equal to no of player return by WarGame function
        }

        [Test]
        public void Players_Should_Receive_Equal_Number_Of_Cards()
        {
            int numPlayers = 4;
            var game = new WarGame(numPlayers);

            foreach (var player in game.players)
            {
                Assert.AreEqual(52 / numPlayers, player.TotalCards);
            }
        }

        [Test]
        public void PlayRound_Should_Distribute_Cards_Correctly()
        {
            int numPlayers = 2;
            var game = new WarGame(numPlayers);

            game.PlayRound();

            var player1 = game.players[0];
            var player2 = game.players[1];

            Assert.AreNotEqual(player1.TotalCards, player2.TotalCards); //This checks the total no of card of player1 should not equal to total no of card held by player2 after playing round
        }

        [Test]
        public void War_Should_Resolve_Correctly()
        {
            int numPlayers = 2;
            var game = new WarGame(numPlayers);

            // Arrange for a war scenario
            var player1 = game.players[0];
            var player2 = game.players[1];

            player1.AddCard(new Card(Suit.Clubs, FaceValue.Ace));
            player2.AddCard(new Card(Suit.Spades, FaceValue.Ace));
            for (int i = 0; i < 3; i++)
            {
                player1.AddCard(new Card(Suit.Clubs, FaceValue.Two));
                player2.AddCard(new Card(Suit.Spades, FaceValue.Three));
            }
            player1.AddCard(new Card(Suit.Clubs, FaceValue.Five));
            player2.AddCard(new Card(Suit.Spades, FaceValue.Four));

            game.PlayRound();

            Assert.AreNotEqual(player1.TotalCards, player2.TotalCards);// This checks the no of card not equal to no of card held by 2nd player after playing round
        }

    }
}
