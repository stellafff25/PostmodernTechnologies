using System;
using System.Collections.Generic;

public interface ICoffee
{
    string GetDescription();
    double GetCost();
    List<string> GetIngredients();
}

// Basic coffee implementation
public class SimpleCoffee : ICoffee
{
    public string GetDescription() => "Regular coffee";
    public double GetCost() => 60.0;
    public List<string> GetIngredients() => new List<string> { "Coffee" };
}

// Abstract decorator class
public abstract class CoffeeDecorator : ICoffee
{
    protected ICoffee _coffee;

    public CoffeeDecorator(ICoffee coffee)
    {
        _coffee = coffee;
    }

    public virtual string GetDescription() => _coffee.GetDescription();
    public virtual double GetCost() => _coffee.GetCost();
    public virtual List<string> GetIngredients() => _coffee.GetIngredients();

    public static ICoffee AddAdditivesToCoffee(ICoffee coffee, List<string> additives)
    {
        foreach (var additive in additives)
        {
            switch (additive)
            {
                case "Milk":
                    coffee = new MilkDecorator(coffee);
                    break;
                case "Sugar":
                    coffee = new SugarDecorator(coffee);
                    break;
                case "Chocolate":
                    coffee = new ChocolateDecorator(coffee);
                    break;
            }
        }

        return coffee;
    }

    // Function to get additives from user input
    public static List<string> GetUserAdditives()
    {
        List<string> additives = new List<string>();

        Console.WriteLine("Select additives for your coffee:");
        Console.WriteLine("1 - Milk");
        Console.WriteLine("2 - Sugar");
        Console.WriteLine("3 - Chocolate");
        Console.WriteLine("0 - Finish selection");

        bool continueAdding = true;

        while (continueAdding)
        {
            Console.Write("Enter the number of the additive: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    additives.Add("Milk");
                    break;
                case "2":
                    additives.Add("Sugar");
                    break;
                case "3":
                    additives.Add("Chocolate");
                    break;
                case "0":
                    continueAdding = false;
                    break;
                default:
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    break;
            }
        }

        return additives;
    }
}

// Milk decorator
public class MilkDecorator : CoffeeDecorator
{
    public MilkDecorator(ICoffee coffee) : base(coffee) { }

    public override string GetDescription() => _coffee.GetDescription() + ", with milk";
    public override double GetCost() => _coffee.GetCost() + 20.0;
    public override List<string> GetIngredients()
    {
        var ingredients = new List<string>(_coffee.GetIngredients()) { "Milk" };
        return ingredients;
    }
}

// Sugar decorator
public class SugarDecorator : CoffeeDecorator
{
    public SugarDecorator(ICoffee coffee) : base(coffee) { }

    public override string GetDescription() => _coffee.GetDescription() + ", with sugar";
    public override double GetCost() => _coffee.GetCost() + 5.0;
    public override List<string> GetIngredients()
    {
        var ingredients = new List<string>(_coffee.GetIngredients()) { "Sugar" };
        return ingredients;
    }
}

// Chocolate decorator
public class ChocolateDecorator : CoffeeDecorator
{
    public ChocolateDecorator(ICoffee coffee) : base(coffee) { }

    public override string GetDescription() => _coffee.GetDescription() + ", with chocolate";
    public override double GetCost() => _coffee.GetCost() + 15.0;
    public override List<string> GetIngredients()
    {
        var ingredients = new List<string>(_coffee.GetIngredients()) { "Chocolate" };
        return ingredients;
    }
}
