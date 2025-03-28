using Xunit;
using System.Collections.Generic;
using System.IO;
using System;

public class CoffeeTests
{
    [Fact]
    public void TestAddAdditivesToCoffee_WithMilk()
    {
        ICoffee coffee = new SimpleCoffee();
        List<string> additives = new List<string> { "Milk" };

        coffee = CoffeeDecorator.AddAdditivesToCoffee(coffee, additives);

        Assert.Equal("Regular coffee, with milk", coffee.GetDescription());
        Assert.Equal(80.0, coffee.GetCost());
        Assert.Equal(new List<string> { "Coffee", "Milk" }, coffee.GetIngredients());
    }

    [Fact]
    public void TestAddAdditivesToCoffee_WithSugar()
    {
        ICoffee coffee = new SimpleCoffee();
        List<string> additives = new List<string> { "Sugar" };

        coffee = CoffeeDecorator.AddAdditivesToCoffee(coffee, additives);

        Assert.Equal("Regular coffee, with sugar", coffee.GetDescription());
        Assert.Equal(65.0, coffee.GetCost());
        Assert.Equal(new List<string> { "Coffee", "Sugar" }, coffee.GetIngredients());
    }

    [Fact]
    public void TestAddAdditivesToCoffee_WithChocolate()
    {
        ICoffee coffee = new SimpleCoffee();
        List<string> additives = new List<string> { "Chocolate" };

        coffee = CoffeeDecorator.AddAdditivesToCoffee(coffee, additives);

        Assert.Equal("Regular coffee, with chocolate", coffee.GetDescription());
        Assert.Equal(75.0, coffee.GetCost());
        Assert.Equal(new List<string> { "Coffee", "Chocolate" }, coffee.GetIngredients());
    }

    [Fact]
    public void TestAddAdditivesToCoffee_WithAllAdditives()
    {
        ICoffee coffee = new SimpleCoffee();
        List<string> additives = new List<string> { "Milk", "Sugar", "Chocolate" };

        coffee = CoffeeDecorator.AddAdditivesToCoffee(coffee, additives);

        Assert.Equal("Regular coffee, with milk, with sugar, with chocolate", coffee.GetDescription());
        Assert.Equal(100.0, coffee.GetCost());
        Assert.Equal(new List<string> { "Coffee", "Milk", "Sugar", "Chocolate" }, coffee.GetIngredients());
    }

    [Fact]
    public void TestAddAdditivesToCoffee_EmptyAdditives()
    {
        ICoffee coffee = new SimpleCoffee();
        List<string> additives = new List<string>();

        coffee = CoffeeDecorator.AddAdditivesToCoffee(coffee, additives);

        Assert.Equal("Regular coffee", coffee.GetDescription());
        Assert.Equal(60.0, coffee.GetCost());
        Assert.Equal(new List<string> { "Coffee" }, coffee.GetIngredients());
    }

    [Fact]
    public void TestUserInputWithMilk()
    {
        var input = new StringReader("1\n0\n");
        Console.SetIn(input);

        ICoffee coffee = new SimpleCoffee();
        List<string> additives = CoffeeDecorator.GetUserAdditives();
        coffee = CoffeeDecorator.AddAdditivesToCoffee(coffee, additives);

        Assert.Equal("Regular coffee, with milk", coffee.GetDescription());
        Assert.Equal(80.0, coffee.GetCost());
        Assert.Equal(new List<string> { "Coffee", "Milk" }, coffee.GetIngredients());
    }

    [Fact]
    public void TestUserInputWithSugar()
    {
        var input = new StringReader("2\n0\n");
        Console.SetIn(input);

        ICoffee coffee = new SimpleCoffee();
        List<string> additives = CoffeeDecorator.GetUserAdditives();
        coffee = CoffeeDecorator.AddAdditivesToCoffee(coffee, additives);

        Assert.Equal("Regular coffee, with sugar", coffee.GetDescription());
        Assert.Equal(65.0, coffee.GetCost());
        Assert.Equal(new List<string> { "Coffee", "Sugar" }, coffee.GetIngredients());
    }

    [Fact]
    public void TestUserInputWithChocolate()
    {
        var input = new StringReader("3\n0\n");
        Console.SetIn(input);

        ICoffee coffee = new SimpleCoffee();
        List<string> additives = CoffeeDecorator.GetUserAdditives();
        coffee = CoffeeDecorator.AddAdditivesToCoffee(coffee, additives);

        Assert.Equal("Regular coffee, with chocolate", coffee.GetDescription());
        Assert.Equal(75.0, coffee.GetCost());
        Assert.Equal(new List<string> { "Coffee", "Chocolate" }, coffee.GetIngredients());
    }

    [Fact]
    public void TestUserInputWithAllAdditives()
    {
        var input = new StringReader("1\n2\n3\n0\n");
        Console.SetIn(input);

        ICoffee coffee = new SimpleCoffee();
        List<string> additives = CoffeeDecorator.GetUserAdditives();
        coffee = CoffeeDecorator.AddAdditivesToCoffee(coffee, additives);

        Assert.Equal("Regular coffee, with milk, with sugar, with chocolate", coffee.GetDescription());
        Assert.Equal(100.0, coffee.GetCost());
        Assert.Equal(new List<string> { "Coffee", "Milk", "Sugar", "Chocolate" }, coffee.GetIngredients());
    }

    [Fact]
    public void TestUserInputWithNoAdditives()
    {
        var input = new StringReader("0\n");
        Console.SetIn(input);

        ICoffee coffee = new SimpleCoffee();
        List<string> additives = CoffeeDecorator.GetUserAdditives();
        coffee = CoffeeDecorator.AddAdditivesToCoffee(coffee, additives);

        Assert.Equal("Regular coffee", coffee.GetDescription());
        Assert.Equal(60.0, coffee.GetCost());
        Assert.Equal(new List<string> { "Coffee" }, coffee.GetIngredients());
    }
}
