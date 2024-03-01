using System;
using System.Collections.Generic;
namespace Uppgift6_13
{
    class Program
    {
        static void Main(string[] args)
        {
            //Färger
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();
            //-------------------------------------------

            Console.WriteLine(CardGame("4 5 6 5"));
            Console.WriteLine(CardGame("5 7 7 5 5"));
            Console.WriteLine(CardGame("2 2 8 8 8 10 10 10 2 5 6"));
            Console.WriteLine(CardGame("ufhseufhsieufhsoiefhseoi")); //Kommer ge -1
        }

        /// <summary>
        /// Räknar ut poängen. 
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns>Om -1 returneras var argumentet ogiltigt.</returns>
        static int CardGame(string userInput)
        {

            string[] cardsString = userInput.Split(' ');
            //Gör om värdena till int
            int[] cardsInt = new int[cardsString.Length];
            try
            {
                for (int i = 0; i < cardsString.Length; i++)
                {
                    cardsInt[i] = int.Parse(cardsString[i]);
                }
            }
            catch
            {
                return -1;
            }

            //Lägger in alla kort i en dictionary. 
            Dictionary<int, int> cardsAndQuantity = new Dictionary<int, int>();
            foreach (int card in cardsInt)
            {

                if (cardsAndQuantity.ContainsKey(card)) continue;
                cardsAndQuantity[card] = 0;
            }

            //Antal kort är valuen. 
            for (int i = 0; i < cardsInt.Length; i++)
            {
                cardsAndQuantity[cardsInt[i]]++;
            }

            //Räknar ut poängen
            int totalSum = 0;
            foreach (var item in cardsAndQuantity)
            {
                int tempProduct = 1;

                for (int j = 0; j < item.Value; j++)
                {
                    tempProduct *= item.Key;
                }
                totalSum += tempProduct;
            }
            return totalSum;
        }
    }
}
/*I ett påhittat kortspel så får man poäng beroende på vilka kort man har samlat på sig.
Alla kort har ett tal från 2 - 10 på sig.
En spelares poäng beräknas genom att ta (kortets tal)^(antal kort med det talet)  för varje tal man
har samlat på sig. Om en spelare till exempel har tre kort med talet 5 och två kort
med talet 7 så har spelaren samlat ihop poängen 5 3 +7 2  = 125 + 49 = 174.

Din uppgift är att skapa ett program som har en metod som beräknar en spelares
poäng. Metoden ska ha en parameter som är en sträng med spelarens kort inskrivna
med mellanslag mellan varje kort. De kort som visades i poängexemplet ovan hade
till exempel kunnat anges med strängen &quot;5 7 7 5 5&quot;*/