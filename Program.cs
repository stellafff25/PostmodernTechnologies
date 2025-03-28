using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        ICoffee coffee = new SimpleCoffee();

        List<string> additives = CoffeeDecorator.GetUserAdditives();
        coffee = CoffeeDecorator.AddAdditivesToCoffee(coffee, additives);

        Console.WriteLine("\nFinal coffee:");
        Console.WriteLine($"{coffee.GetDescription()} - {coffee.GetCost()} UAH");
        Console.WriteLine("Ingredients:");
        foreach (var ingredient in coffee.GetIngredients())
        {
            Console.WriteLine($"- {ingredient}");
        }
    }
}
