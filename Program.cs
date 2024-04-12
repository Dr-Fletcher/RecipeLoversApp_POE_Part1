using System;

namespace RecipeLovers
{
    class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
    }

    class Step
    {
        public string Description { get; set; }
    }

    class Recipe
    {
        private Ingredient[] ingredients;
        private Step[] steps;

        public Recipe(int numIngredients, int numSteps)
        {
            ingredients = new Ingredient[numIngredients];
            steps = new Step[numSteps];
        }

        public void AddIngredient(int index, string name, double quantity, string unit)
        {
            ingredients[index] = new Ingredient { Name = name, Quantity = quantity, Unit = unit };
        }

        public void AddStep(int index, string description)
        {
            steps[index] = new Step { Description = description };
        }

        public void DisplayRecipe()
        {
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
            }

            Console.WriteLine("\nSteps:");
            for (int i = 0; i < steps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i].Description}");
            }
        }

        public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        public void ResetQuantities()
        {
            // this assumes original quantities are stored elsewhere and can be retrieved
            foreach (var ingredient in ingredients)
            {
                ingredient.Quantity = 1;
            }
        }

        public void ClearRecipe()
        {
            ingredients = new Ingredient[ingredients.Length];
            steps = new Step[steps.Length];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Recipe Lovers!");

            // this code will prompt user to enter recipe details
            Console.Write("Please enter the number of ingredients: ");
            int numIngredients = int.Parse(Console.ReadLine());

            Console.Write("Please enter the number of steps: ");
            int numSteps = int.Parse(Console.ReadLine());

            Recipe recipe = new Recipe(numIngredients, numSteps);

            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"\nPlease enter details for ingredient {i + 1}:");
                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Quantity: ");
                double quantity = double.Parse(Console.ReadLine());

                Console.Write("Unit: ");
                string unit = Console.ReadLine();

                recipe.AddIngredient(i, name, quantity, unit);
            }

            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"\nEnter step {i + 1}:");
                string description = Console.ReadLine();
                recipe.AddStep(i, description);
            }

            // this code will display the recipe
            Console.WriteLine("\nYour Recipe:");
            recipe.DisplayRecipe();

            // this code allows the user to scale the recipe
            Console.WriteLine("\nDo you want to scale the recipe? (0.5, 2, 3 or none)");
            double factor = double.Parse(Console.ReadLine());
            recipe.ScaleRecipe(factor);

            // this code display the scaled recipe
            Console.WriteLine("\nScaled Recipe:");
            recipe.DisplayRecipe();

            // this code will reset the quantities
            Console.WriteLine("\nResetting quantities...");
            recipe.ResetQuantities();
            recipe.DisplayRecipe();

            // Clear recipe
            Console.WriteLine("\nClearing recipe...");
            recipe.ClearRecipe();
            Console.WriteLine("Recipe cleared.");
        }
    }
}
