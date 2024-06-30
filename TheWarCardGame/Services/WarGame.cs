
using TheWarCardGame.Interface;
using TheWarCardGame.Model;

namespace TheWarCardGame.Services
{
    public class WarGame : IWarGame
    {

        private readonly int _numPlayers;
        public readonly List<IPlayers> players;
        private readonly IDeck _deck;
        private readonly List<string> _history;

        public WarGame(int numPlayers)
        {
            _numPlayers = numPlayers;
            players = new List<IPlayers>();
            for (int i = 0; i < _numPlayers; i++)
            {
                players.Add(new Players($"Player {i + 1}"));
            }
            _deck = new Deck();
            _history = new List<string>();
            DistributeCards();
        }

        private void DistributeCards()
        {
            _deck.ShuffleCard();
            var shuffledCards = new Queue<Card>(_deck.Cards);

            int playerIndex = 0;
            while (shuffledCards.Count > 0)
            {
                players[playerIndex].AddCard(shuffledCards.Dequeue());
                playerIndex = (playerIndex + 1) % _numPlayers;
            }
        }

        public void Play()
        {
            while (players.Count(p => p.HasCards) > 1)
            {
                PlayRound();
            }
        }

        public void PlayRound()
        {
            var playedCards = new Dictionary<IPlayers, Card>();
            foreach (var player in players)
            {
                if (player.HasCards)
                {
                    var card = player.FlipCard();
                    playedCards.Add(player, card);
                    _history.Add($"{player.Name} plays {card}");
                }
            }

            var highestCardValue = playedCards.Values.Max(c => c.Value);
            var winners = playedCards.Where(pc => pc.Value.Value == highestCardValue).Select(pc => pc.Key).ToList();

            if (winners.Count == 1)
            {
                winners[0].CollectCard(playedCards.Values.ToList());
                _history.Add($"{winners[0].Name} wins the round");
            }
            else
            {
                _history.Add("War begins!!!");
                PlayWar(winners, playedCards.Values.ToList());
            }
        }

        private void PlayWar(List<IPlayers> warPlayers, List<Card> DepositCard)
        {
            bool warResolved = false;

            while (!warResolved && warPlayers.Count > 1)
            {
                var warCards = new Dictionary<IPlayers, List<Card>>();

                for (int i = warPlayers.Count - 1; i >= 0; i--)
                {
                    var player = warPlayers[i];
                    if (player.HasEnoughCard(4))
                    {
                        var cards = player.FlipWarCard();
                        warCards.Add(player, cards);
                        DepositCard.AddRange(cards);
                        _history.Add($"{player.Name} places 3 cards face-down and 1 card face-up: {cards[3]}");
                    }
                    else
                    {
                        _history.Add($"{player.Name} does not have enough cards to continue the war and loses.");
                        warPlayers.RemoveAt(i);
                    }
                }

                if (warPlayers.Count == 1)
                {
                    warPlayers[0].CollectCard(DepositCard);
                    _history.Add($"{warPlayers[0].Name} wins the war and collects all cards");
                    warResolved = true;
                }
                else if (warPlayers.Count == 0)
                {
                    _history.Add("All players in the war have run out of cards. The game ends with no winner.");
                    warResolved = true;
                }
                else
                {
                    var highestCardValue = warCards.Values
                                           .SelectMany(c => c)           
                                           .Where((_, index) => index % 4 == 3) 
                                           .Max(c => c.Value);

                    var newWinners = warCards
                                    .Where(wc => wc.Value[3].Value == highestCardValue) 
                                    .Select(wc => wc.Key) 
                                    .ToList();

                    if (newWinners.Count == 1)
                    {
                        newWinners[0].CollectCard(DepositCard);
                        _history.Add($"{newWinners[0].Name} wins the war and collects all cards");
                        warResolved = true;
                    }
                    else
                    {
                        _history.Add("War continues!");
                        warPlayers = newWinners;
                    }
                }
            }
        }

        public void DisplayResult()
        {
            Console.WriteLine("\nGame history:");
            foreach (var entry in _history)
            {
                Console.WriteLine(entry);
            }

            Console.WriteLine("\nFinal rankings:");
            var sortedPlayers = players.OrderByDescending(p => p.TotalCards).ToList();
            for (int i = 0; i < sortedPlayers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {sortedPlayers[i].Name} - Cards: {sortedPlayers[i].TotalCards}");
            }
        }
    }
}
