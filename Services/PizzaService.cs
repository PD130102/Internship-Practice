using Internship.Models;

namespace Internship.Services;

public static class PizzaService
{
    static List<Pizza> pizzas {get;}
    static int nextID = 3;
        static PizzaService()
    {
        pizzas = new List<Pizza>
        {
            new Pizza {Id = 1, Name = "Pepperoni", isGlutenFree = false, Description = "Pepperoni, cheese, tomato sauce"},
            new Pizza {Id = 2, Name = "Cheese", isGlutenFree = true , Description = "TwoCheese, tomato sauce"}
        };
    }

    public static List<Pizza> GetAll()
    {
        return pizzas;
    }

    public static Pizza Get(int id) 
    {
        Pizza? p = pizzas.Find(p => p.Id == id);
        return p ?? throw new Exception("Pizza not found");
        
    }

    public static void Add(Pizza pizza)
    {
        pizza.Id = nextID++;
        pizzas.Add(pizza);
    }

    public static void Delete(int id)
    {
        var pizza = Get(id);
        if (pizza != null)
        {
            pizzas.Remove(pizza);
        }
    }

    public static void Update(Pizza pizza)
    {
        var index = pizzas.FindIndex(p => p.Id == pizza.Id);
        if (index >= 0)
        {
            pizzas[index] = pizza;
        }
    }

}