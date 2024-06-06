using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace zara
{
    internal class captureUserData
    {
        public static List<string> nameOfRecipe = new List<string>();
        private static List<string> TheIngredients = new List<string>();
        private static List<string> TheQuantity = new List<string>();
        private static List<string> TheMeasurements = new List<string>();
        private static List<string> Thecalories = new List<string>();
        private static List<string> ThefoodGroups = new List<string>();
        private static List<string> Thesteps = new List<string>();
        private static List<string> storeOrginalQuantity = new List<string>();

        public static string ChoosenGroup = "";

        private int addTheCalories = 0;

        public void capture_method()
        {
            getandset fetchProperty = new getandset();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Enter the recipe name: ");
            Console.ForegroundColor = ConsoleColor.White;
            string recipeName = Console.ReadLine();
            nameOfRecipe.Add(recipeName);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.Write("Enter the number of ingredients: ");
            Console.ForegroundColor = ConsoleColor.White;
            string ingredientNumber = Console.ReadLine();

            while (!ingredientNumber.All(char.IsNumber))
            {
                Console.WriteLine("Please enter a number");
                ingredientNumber = Console.ReadLine();
            }

            addTheCalories = 0;
            int captureCalories = Convert.ToInt32(ingredientNumber);

            Console.ResetColor();

            for (int i = 0; i < captureCalories; i++)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Enter the name of the ingredient " + (i + 1) + " : ");
                Console.ForegroundColor = ConsoleColor.White;
                string name = Console.ReadLine();

                bool nANDp = false;
                while (!nANDp)
                {
                    if (name.Any(char.IsNumber) || name.Any(char.IsPunctuation))
                    {
                        Console.WriteLine("!please do not include number or any punctuation in your ingredient name ");
                        name = Console.ReadLine();
                    }
                    else
                    {
                        nANDp = true;
                    }
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Enter the quantity for " + name.ToUpper() + " : ");
                Console.ForegroundColor = ConsoleColor.White;
                string quantity = Console.ReadLine();

                bool checkQuantity = false;
                while (!checkQuantity)
                {
                    if (!quantity.All(char.IsNumber))
                    {
                        Console.WriteLine("Please enter a number");
                        quantity = Console.ReadLine();
                    }
                    else
                    {
                        checkQuantity = true;
                    }
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Enter the measurements for " + name.ToUpper() + " : ");
                Console.ForegroundColor = ConsoleColor.White;
                string measurement = Console.ReadLine().ToUpper();

                bool checkMeasurement = false;
                while (!checkMeasurement)
                {
                    if (measurement.Any(char.IsNumber) || measurement.Any(char.IsPunctuation))
                    {
                        Console.WriteLine("!please do not include number or any punctuation in your unit of measurement ");
                        measurement = Console.ReadLine();
                    }
                    else
                    {
                        checkMeasurement = true;
                    }
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Enter number of calories for " + name.ToUpper() + ": ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.White;
                string calories = Console.ReadLine();

                bool checkCalories = false;
                while (!checkCalories)
                {
                    if (!calories.All(char.IsNumber))
                    {
                        Console.WriteLine("Please enter a number");
                        calories = Console.ReadLine();
                    }
                    else
                    {
                        checkCalories = true;
                    }
                }

                addTheCalories += int.Parse(calories);

                if (addTheCalories > 300)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Warning: The total calories exceed 300. This is not good for your health!");
                    Console.ResetColor();
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Choose the food group for " + name.ToUpper());
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(
                    "1. Starchy foods \n" +
                    "2. Vegetables and fruits \n" +
                    "3. Dry beans, peas, lentils and soya \n" +
                    "4. Chicken, fish, meat and eggs \n" +
                    "5. Milk and dairy products \n" +
                    "6. Fats and oil \n" +
                    "7. Water, hot milk \n" +
                    "8. Enter the food group \n" +
                    "Any other key for NOT SURE");
                Console.ResetColor();

                string groupNumber = Console.ReadLine();
                ChoosenGroup = groupNumber switch
                {
                    "1" => "Starchy foods",
                    "2" => "Vegetables and fruits",
                    "3" => "Dry beans, peas, lentils and soya",
                    "4" => "Chicken, fish, meat and eggs",
                    "5" => "Milk and dairy products",
                    "6" => "Fats and oil",
                    "7" => "Water, hot milk",
                    "8" => Console.ReadLine(),
                    _ => "Not sure",
                };

                Console.WriteLine("Chose/entered " + ChoosenGroup + " group for " + name.ToUpper());
                Console.ResetColor();

                TheIngredients.Add(name + recipeName);
                TheMeasurements.Add(measurement + recipeName);
                TheQuantity.Add(quantity + recipeName);
                Thecalories.Add(calories + recipeName);
                ThefoodGroups.Add(ChoosenGroup + recipeName);
                storeOrginalQuantity.Add(quantity + recipeName);
            }

            
            Console.Write("How many steps are required: ");
            int steps = Convert.ToInt32(Console.ReadLine());

            for (int s = 0; s < steps; s++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t STEP  " + (s + 1));
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Description: ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.White;
                string step = Console.ReadLine();
                Console.ResetColor();
                Thesteps.Add(step + recipeName);
            }
        }

        public static void display_the_recipe()
        {
            nameOfRecipe.Sort();
            for (int n = 0; n < nameOfRecipe.Count; n++)
            {
                if (n == 0) continue;
                Console.WriteLine((n) + ":  " + nameOfRecipe[n]);
            }

            string res;
            do
            {
                Console.WriteLine("Search a recipe by number");
                res = Console.ReadLine();
            } while (!res.All(char.IsNumber));

            string recipeName = nameOfRecipe[Convert.ToInt32(res)];
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t \t Ingredient \t Quantity \t Measurement \t Calories \t Food Group");

            for (int i = 0; i < TheIngredients.Count; i++)
            {
                if (TheIngredients[i].Contains(recipeName))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\t\t " + TheIngredients[i].Replace(recipeName, "") + "\t\t");
                    Console.Write(TheQuantity[i].Replace(recipeName, "") + "\t\t");
                    Console.Write(TheMeasurements[i].Replace(recipeName, "") + "\t\t");
                    Console.Write(Thecalories[i].Replace(recipeName, "") + "\t\t");
                    Console.WriteLine(ThefoodGroups[i].Replace(recipeName, ""));
                    Console.ResetColor();
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t \t\t\t Steps for preparation");

            for (int s = 0; s < Thesteps.Count; s++)
            {
                if (Thesteps[s].Contains(recipeName))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine((s + 1) + "\t" + Thesteps[s].Replace(recipeName, ""));
                    Console.ResetColor();
                }
            }
        }

        public static void display_the_scaled_recipe()
        {
            nameOfRecipe.Sort();
            for (int n = 0; n < nameOfRecipe.Count; n++)
            {
                if (n == 0) continue;
                Console.WriteLine((n) + ":  " + nameOfRecipe[n]);
            }

            string res;
            do
            {
                Console.WriteLine("Search a recipe by number");
                res = Console.ReadLine();
            } while (!res.All(char.IsNumber));

            string recipeName = nameOfRecipe[int.Parse(res)];
            Console.WriteLine("Enter a scaling factor (0.5, 2, or 3):");
            double scale;
            while (!double.TryParse(Console.ReadLine(), out scale))
            {
                Console.WriteLine("Please enter a valid number");
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t \t Ingredient \t Quantity \t Measurement \t Calories \t Food Group");

            for (int i = 0; i < TheIngredients.Count; i++)
            {
                if (TheIngredients[i].Contains(recipeName))
                {
                    double originalQuantity = Convert.ToDouble(TheQuantity[i].Replace(recipeName, ""));
                    double scaledQuantity = originalQuantity * scale;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\t\t " + TheIngredients[i].Replace(recipeName, "") + "\t\t");
                    Console.Write(scaledQuantity + "\t\t");
                    Console.Write(TheMeasurements[i].Replace(recipeName, "") + "\t\t");
                    Console.Write(Thecalories[i].Replace(recipeName, "") + "\t\t");
                    Console.WriteLine(ThefoodGroups[i].Replace(recipeName, ""));
                    Console.ResetColor();
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t \t\t\t Steps for preparation");

            for (int s = 0; s < Thesteps.Count; s++)
            {
                if (Thesteps[s].Contains(recipeName))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine((s + 1) + "\t" + Thesteps[s].Replace(recipeName, ""));
                    Console.ResetColor();
                }
            }
        }

        public static void reset()
        {
            Console.WriteLine("Choose the recipe number to reset quantities:");
            nameOfRecipe.Sort();
            for (int n = 0; n < nameOfRecipe.Count; n++)
            {
                if (n == 0) continue;
                Console.WriteLine((n) + ":  " + nameOfRecipe[n]);
            }

            string res;
            do
            {
                Console.WriteLine("Search a recipe by number");
                res = Console.ReadLine();
            } while (!res.All(char.IsNumber));

            string recipeName = nameOfRecipe[int.Parse(res)];

            for (int i = 0; i < TheIngredients.Count; i++)
            {
                if (TheIngredients[i].Contains(recipeName))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\t\t " + TheIngredients[i].Replace(recipeName, "") + "\t\t");
                    Console.Write(storeOrginalQuantity[i].Replace(recipeName, "") + "\t\t");
                    Console.Write(TheMeasurements[i].Replace(recipeName, "") + "\t\t");
                    Console.Write(Thecalories[i].Replace(recipeName, "") + "\t\t");
                    Console.WriteLine(ThefoodGroups[i].Replace(recipeName, ""));
                    Console.ResetColor();
                }
            }
        }

        public static void clear_Data()
        {
            Console.WriteLine("Choose the recipe number to clear data:");
            nameOfRecipe.Sort();
            for (int n = 0; n < nameOfRecipe.Count; n++)
            {
                if (n == 0) continue;
                Console.WriteLine((n) + ":  " + nameOfRecipe[n]);
            }

            string res;
            do
            {
                Console.WriteLine("Search a recipe by number");
                res = Console.ReadLine();
            } while (!res.All(char.IsNumber));

            string recipeName = nameOfRecipe[Convert.ToInt32(res)];

            TheIngredients.RemoveAll(i => i.Contains(recipeName));
            TheMeasurements.RemoveAll(i => i.Contains(recipeName));
            TheQuantity.RemoveAll(i => i.Contains(recipeName));
            Thecalories.RemoveAll(i => i.Contains(recipeName));
            ThefoodGroups.RemoveAll(i => i.Contains(recipeName));
            storeOrginalQuantity.RemoveAll(i => i.Contains(recipeName));
            Thesteps.RemoveAll(i => i.Contains(recipeName));
            nameOfRecipe.Remove(recipeName);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Recipe data cleared successfully.");
            Console.ResetColor();
        }
    }
}
