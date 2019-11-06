// Fig. 8.10: DeckOfCards.cs
// DeckOfCards class represents a deck of playing cards.
using System;
using System.Globalization;
using System.IO.Ports;

public class DeckOfCards
{
    private Card[] deck; // array of Card objects
    private int currentCard; // index of next Card to be dealt (0-51)
    private const int NUMBER_OF_CARDS = 52; // constant number of Cards
    private Random randomNumbers; // random number generator

    private enum states  {
        DOUBLE_FACES = 2
    };

    private Card[] hand;
    private int[] suitCounters;
    private int[] faceCounters;
    // constructor fills deck of Cards
    public DeckOfCards()
    {
        hand = new Card[5];
        suitCounters = new int[4];
        faceCounters = new int[13];


        deck = new Card[NUMBER_OF_CARDS]; // create array of Card objects
        currentCard = 0; // set currentCard so deck[ 0 ] is dealt first  
        randomNumbers = new Random(); // create random number generator

        // populate deck with Card objects
        for (int count = 0; count < deck.Length; ++count)
            deck[count] =
               new Card(count % 13, count / 13);
    } // end DeckOfCards constructor

    // shuffle deck of Cards with one-pass algorithm
    public void Shuffle()
    {
        // after shuffling, dealing should start at deck[ 0 ] again
        currentCard = 0; // reinitialize currentCard

        // for each Card, pick another random Card and swap them
        for (int first = 0; first < deck.Length; ++first)
        {
            // select a random number between 0 and 51 
            int second = randomNumbers.Next(NUMBER_OF_CARDS);

            // swap current Card with randomly selected Card
            Card temp = deck[first];
            deck[first] = deck[second];
            deck[second] = temp;
        } // end for
    } // end method Shuffle

    // deal one Card
    public Card DealCard()
    {
        // determine whether Cards remain to be dealt
        if (currentCard < deck.Length)
            return deck[currentCard++]; // return current Card in array
        else
            return null; // indicate that all Cards were dealt
    } // end method DealCard

    private void DealHand()
    {

        for (int i = 0; i < hand.Length; i++)
        {
            Card card = DealCard();

            hand[i] = card;

        }

    }

    public void MakeStatisticsPerHand()
    {
        InitCounters();
        for (int i = 0; i < hand.Length; i++)
        {
            if (hand[i] != null)
            {

                ++suitCounters[hand[i].Suit];
                ++faceCounters[hand[i].Face];
            }

        }
    }


    public bool HasTwoFaces()
    {
        for (int i = 0; i < faceCounters.Length; i++)
        {
            if (faceCounters[i] == 2)
            {
                return true;
            }
        }

        return false;
    }

    public bool HasTwoPlusTwoFaces()
    {
        bool hasOne = false;
        for (int i = 0; i < faceCounters.Length; i++)
        {
            if ((faceCounters[i] == (int)states.DOUBLE_FACES) && hasOne)
            {
                return true;
            }

            if (faceCounters[i] == (int)states.DOUBLE_FACES)
            {
                hasOne = true;
            }
        }

        return false;
    }

    private void InitCounters()
    {
        for (int i = 0; i < suitCounters.Length; i++)
        {
            suitCounters[i] = 0;
        }

        for (int i = 0; i < faceCounters.Length; i++)
        {
            faceCounters[i] = 0;
        }
    }

    private string ShowHand()
    {
        string output = "";
        for (int i = 0; i < hand.Length; i++)
        {

            if (hand[i] != null)
            {
                output += hand[i].ToString() + "\n"; 
            }
        }

        return output;
    }

    public void ShowStatistics()
    {
        for (int i = 0; i < deck.Length/5+1; i++)
        {
                DealHand();

                Console.WriteLine(ShowHand());
                MakeStatisticsPerHand();
                Console.WriteLine(HasTwoFaces() ? "Hand has 2 faces\n":"Hand has no 2 faces \n");
                Console.WriteLine(HasTwoPlusTwoFaces() ? "Hand has 2+2 faces\n" : "Hand has no 2+2 faces \n");

        }
    }
} // end class DeckOfCards


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
