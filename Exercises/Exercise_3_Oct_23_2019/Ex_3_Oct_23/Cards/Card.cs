// Fig. 8.9: Card.cs
// Card class represents a playing card.
public class Card
{
    private static string[] faces = { "Ace", "Deuce", "Three", "Four", "Five", "Six",
        "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };
    private static string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
    private int face;
    private int suit;

    public int Face
    {
        get { return face; }
        set
        {
            if (value >= 0 && value < faces.Length)
            {
                face = value;
            }

        }
    }
    public int Suit
    {
        get { return suit; }
        set
        {
            if (value >= 0 && value < suits.Length)
            {
                suit = value;
            }
        }
    }
    // two-parameter constructor initializes card's face and suit
    public Card(int cardFace, int cardSuit)
    {
        Face = cardFace; // initialize face of card
        Suit = cardSuit; // initialize suit of card
    } // end two-parameter Card constructor

    // return string representation of Card
    public override string ToString()
    {
        return faces[face] + " of " + suits[suit];
    } // end method ToString
} // end class Card


/**************************************************************************
 * (C) Copyright 1992-2014 by Deitel & Associates, Inc. and               *
 * Pearson Education, Inc. All Rights Reserved.                           *
 *                                                                        *
 * DISCLAIMER: The authors and publisher of this book have used their     *
 * best efforts in preparing the book. These efforts include the          *
 * development, research, and testing of the theories and programs        *
 * to determine their effectiveness. The authors and publisher make       *
 * no warranty of any kind, expressed or implied, with regard to these    *
 * programs or to the documentation contained in these books. The authors *
 * and publisher shall not be liable in any event for incidental or       *
 * consequential damages in connection with, or arising out of, the       *
 * furnishing, performance, or use of these programs.                     *
 *************************************************************************/
