using System;

namespace zara
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Recipe Menu method
            Menu();
        }

        
        private static void Menu()
        {
            captureUserData.nameOfRecipe.Add("0");
            // All repetition of the menu
            while (true)
            {
                Console.WriteLine("*******************************************************************************************");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("                   Recipe Menu");
                Console.ResetColor();
                Console.WriteLine("*******************************************************************************************");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("1. Enter Recipe Details \n" +
                    "2. Display Recipe List \n" +
                    "3. Scale Recipe \n" +
                    "4. Reset Quantities \n" +
                    "5. Clear all the data \n" +
                    "6. Exit\n" +
                    " ");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("*******************************************************************************************");

                Console.ResetColor();

                int option = Convert.ToInt32(Console.ReadLine());

                Console.ForegroundColor = ConsoleColor.Green;
                Console.ResetColor();
                captureUserData k = new captureUserData();
                if (option == 1)
                {
                    //calling for capturing user inputs method
                    k.capture_method();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.ResetColor();
                }
                else if (option == 2)
                {
                    // printing out the recipe 
                    captureUserData.display_the_recipe();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.ResetColor();
                }
                else if (option == 3)
                {
                    //calling for printing out a scaled recipe
                    captureUserData.display_the_scaled_recipe();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.ResetColor();
                }
                else if (option == 4)
                {
                    // Method resetting the data to Quantities
                    captureUserData.reset();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.ResetColor();
                }
                else if (option == 5)
                {
                    // Method calling for clearing the data
                    captureUserData.clear_Data();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.ResetColor();
                }
                else if (option == 6)
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Invalid option! Please select a valid option.");
                }
            }
        }
    }
}
