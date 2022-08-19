using learnDotnet.Models;

namespace learnDotnet.Services;

public static class PizzaService
{
    static List<Pizza> Pizzas {get;}
    static int nextId = 3;
    static PizzaService()
    {
        Pizzas = new List<Pizza>
        {
            new Pizza {Id = 1, Name = "Classic Italian", IsGlutenFree = false},
            new Pizza {Id = 2, Name = "Vegetariana", IsGlutenFree = true}
        };
    }

    public static List<Pizza> GetAll() => Pizzas;

    public static Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

    public static void Add(Pizza newPizza)
    {
        newPizza.Id = nextId++;
        Pizzas.Add(newPizza);
    }

    public static void Delete(int id)
    {
        var pizza = Get(id);
        if(pizza is null)
            return;
        
        Pizzas.Remove(pizza);
    }

    public static void Update(Pizza alterPizza)
    {
        int index = Pizzas.FindIndex(p => p.Id == alterPizza.Id);
        if(index == -1)
            return;

        Pizzas[index] = alterPizza;    
    }
}