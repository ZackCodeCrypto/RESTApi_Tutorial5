using Microsoft.AspNetCore.Mvc;
using RESTApi.Contacts.Requests;
using RESTApi.Contacts.Responses;
using RESTApi.Data;
using RESTApi.Models;

namespace RESTApi.Controllers;

[ApiController]
[Route("api/animals/{animalId}/visits")]
public class VisitsController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<VisitResponse>> GetVisits(int animalId)
    {
        var visits = StaticDb.Visits
            .Where(v => v.AnimalId == animalId)
            .Select(v => new VisitResponse
            {
                Date = v.Date,
                Description = v.Description,
                Price = v.Price
            })
            .ToList();

        return Ok(visits);
    }

    [HttpPost]
    public ActionResult AddVisit(int animalId, [FromBody] CreateVisitRequest request)
    {
        var animal = StaticDb.Animals.FirstOrDefault(a => a.Id == animalId);
        if (animal == null) return NotFound();

        var visit = new Visit
        {
            AnimalId = animalId,
            Date = request.Date,
            Description = request.Description,
            Price = request.Price
        };

        StaticDb.Visits.Add(visit);
        return Created("", null);
    }
}