
namespace TheWarCardGame.Model
{
    public enum Suit
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }

    public enum FaceValue
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 14

    }
    public class Card
    {
        public Suit Suit { get; }
        public FaceValue FaceValue { get; }
        public int Value => (int)FaceValue;
        public Card(Suit suit,FaceValue faceValue) 
        { 
            FaceValue= faceValue;
            Suit= suit;
        }

        public override string ToString()
        {
            return $"{FaceValue} of {Suit}";
        }

    }
}
