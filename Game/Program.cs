using System;
using System.Collections.Generic;
using System.Linq;

namespace Game
{
	class MainClass
	{
        static int numberOfChild;
        static int skipped;

		static void Main()
		{
		    while (PrintInstructionsNewGame())
		        StartNewGame();
		}

        private static void StartNewGame()
        {
            numberOfChild = 0;
            skipped = 0;

            DisplayInstructionsN();
            var childTags = FindWinner();
            DisplayResults(childTags);
        }

	    private static void DisplayInstructionsN()
	    {
            PrintInstructionsN();
            while (!int.TryParse(Console.ReadLine(), out numberOfChild)) PrintInstructionsN();

	        PrintInstructionsK();
            while (!int.TryParse(Console.ReadLine(), out skipped)) PrintInstructionsK();
	    }

	    private static IList<int> FindWinner()
	    {
            var circle = CreateChildrenCircle(numberOfChild);
            return circle.FindWinner(skipped).ToList();
	    }

        private static void DisplayResults(IList<int> childTags)
        {
            if (childTags != null && childTags.Any())
                PrintResults(childTags);
            else
                PrintInstructionsNoWinner();
        }

        private static bool PrintInstructionsNewGame()
        {
            Console.WriteLine("Please enter an 'N' to start a new game or 'Q' to exit.");
            var input = Console.ReadLine();
            return string.IsNullOrEmpty(input) || input.ToUpper() != "Q";
        }

	    private static void PrintInstructionsN()
        {
            Console.WriteLine("Please enter an integer for number of players. E.g.: 10");
        }

        private static void PrintInstructionsK()
        {
            Console.WriteLine("Please enter an integer for the first child to leave the circle. E.g.: 4");
        }

        private static void PrintInstructionsNoWinner()
        {
            Console.WriteLine("\nNo winner for this game.");
        }

        private static void PrintResults(IList<int> childTags)
        {
            Console.WriteLine("\nChild exiting circle: \n");

            for (var i = 0 ; i < childTags.Count; i++)
            {
                if ( i == childTags.Count -1)
                    Console.WriteLine("Winner : " + childTags[i]);
                else
                    Console.WriteLine("Number : " + childTags[i]);
            }
        }

        private static ChildrenLinkedList<int> CreateChildrenCircle(int numberChildren)
        {
            var circle = new ChildrenLinkedList<int>();
            for (var i = 1; i <= numberChildren; i++)
            {
                circle.Add(i);
            }
            return circle;
        }
	}
}
