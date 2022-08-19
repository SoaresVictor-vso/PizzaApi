using learnDotnet.Models;
using learnDotnet.Services;
using Microsoft.AspNetCore.Mvc;

namespace learnDotnet.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    public PizzaController()
    {

    }

    [HttpGet]
    public ActionResult<List<Pizza>> GetAll() =>
    PizzaService.GetAll();


    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        var pizza = PizzaService.Get(id);

        if(pizza == null)
            return NotFound();
        
        return pizza;
    }


    [HttpPost]
    public IActionResult Create(Pizza newPizza)
    {
        PizzaService.Add(newPizza);
        return CreatedAtAction(nameof(Create), new {id = newPizza.Id}, newPizza);
    }


    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza alterPizza)
    {
        if (id != alterPizza.Id)
            return BadRequest();

        var existingPizza = PizzaService.Get(id);
        if(existingPizza is null)
            return NotFound();

        PizzaService.Update(alterPizza);

        return NoContent();
    }


    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var pizza = PizzaService.Get(id);

        if(pizza is null)
            return NotFound();

        PizzaService.Delete(id);

        return NoContent();
    }
}