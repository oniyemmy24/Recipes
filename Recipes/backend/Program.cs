using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        string recipesFilePath = "recipes.json";

        if (args.Length == 0)
        {
            Console.WriteLine("Usage: backend.exe [add|list] [title] [ingredients] [instructions]");
            return;
        }

        string command = args[0].ToLower();

        switch (command)
        {
            case "add":
                if (args.Length < 4)
                {
                    Console.WriteLine("Usage: backend.exe add [title] [ingredients] [instructions]");
                    return;
                }
                AddRecipe(recipesFilePath, args[1], args[2], args[3]);
                break;
            case "list":
                ListRecipes(recipesFilePath);
                break;
            default:
                Console.WriteLine("Invalid command. Use 'add' or 'list'.");
                break;
        }
    }

    static void AddRecipe(string filePath, string title, string ingredients, string instructions)
    {
        List<Recipe> recipes = LoadRecipes(filePath);
        recipes.Add(new Recipe { Title = title, Ingredients = ingredients, Instructions = instructions });
        SaveRecipes(filePath, recipes);
        Console.WriteLine($"Recipe '{title}' added.");
    }

    static void ListRecipes(string filePath)
    {
        List<Recipe> recipes = LoadRecipes(filePath);
        if (recipes.Count == 0)
        {
            Console.WriteLine("No recipes found.");
            return;
        }

        foreach (var recipe in recipes)
        {
            Console.WriteLine($"Title: {recipe.Title}");
            Console.WriteLine($"Ingredients: {recipe.Ingredients}");
            Console.WriteLine($"Instructions: {recipe.Instructions}");
            Console.WriteLine();
        }
    }

    static List<Recipe> LoadRecipes(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<Recipe>();
        }

        string json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<Recipe>>(json) ?? new List<Recipe>();
    }

    static void SaveRecipes(string filePath, List<Recipe> recipes)
    {
        string json = JsonSerializer.Serialize(recipes);
        File.WriteAllText(filePath, json);
    }
}

class Recipe
{
    public required string Title { get; set; }
    public required string Ingredients { get; set; }
    public required string Instructions { get; set; }
}