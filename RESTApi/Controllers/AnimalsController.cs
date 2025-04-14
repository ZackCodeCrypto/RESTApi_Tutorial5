using Microsoft.AspNetCore.Mvc;
using RESTApi.Contacts.Requests;
using RESTApi.Contacts.Responses;
using RESTApi.Data;
using RESTApi.Models;

namespace RESTApi.Controllers;

[ApiController]
[Route("api/animals")]
public class AnimalsController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<AnimalResponse>> GetAnimals()
    {
        var response = StaticDb.Animals.Select(a => new AnimalResponse
        {
            Id = a.Id,
            Name = a.Name,
            Category = a.Category,
            Weight = a.Weight,
            FurColor = a.FurColor
        });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public ActionResult<AnimalResponse> GetAnimal(int id)
    {
        var animal = StaticDb.Animals.FirstOrDefault(a => a.Id == id);
        if (animal == null) return NotFound();

        var response = new AnimalResponse
        {
            Id = animal.Id,
            Name = animal.Name,
            Category = animal.Category,
            Weight = animal.Weight,
            FurColor = animal.FurColor
        };

        return Ok(response);
    }

    [HttpPost]
    public ActionResult AddAnimal([FromBody] CreateAnimalRequest request)
    {
        var newId = StaticDb.Animals.Max(a => a.Id) + 1;

        var animal = new Animal
        {
            Id = newId,
            Name = request.Name,
            Category = request.Category,
            Weight = request.Weight,
            FurColor = request.FurColor
        };

        StaticDb.Animals.Add(animal);
        return CreatedAtAction(nameof(GetAnimal), new { id = animal.Id }, null);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateAnimal(int id, [FromBody] CreateAnimalRequest request)
    {
        var animal = StaticDb.Animals.FirstOrDefault(a => a.Id == id);
        if (animal == null) return NotFound();

        animal.Name = request.Name;
        animal.Category = request.Category;
        animal.Weight = request.Weight;
        animal.FurColor = request.FurColor;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteAnimal(int id)
    {
        var animal = StaticDb.Animals.FirstOrDefault(a => a.Id == id);
        if (animal == null) return NotFound();

        StaticDb.Animals.Remove(animal);
        return NoContent();
    }
}
