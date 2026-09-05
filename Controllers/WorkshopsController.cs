using Microsoft.AspNetCore.Mvc;
using WorkshopApi.Interfaces;
using WorkshopApi.Models;

namespace WorkshopApi.Controllers;

[ApiController]
[Route("api/workshops")]
public class WorkshopsController(IWorkshopRepository repository) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Workshop>>> GetAll() => Ok(await repository.GetWorkshops());

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Workshop>> GetById(int id)
    {
        var workshop = await repository.GetWorkshop(id);
        return workshop is null ? NotFound() : Ok(workshop);
    }

    [HttpGet("available")]
    public async Task<ActionResult<List<Workshop>>> GetAvailable() =>
        Ok(await repository.GetAvailableWorkshops());

    [HttpPost]
    public async Task<ActionResult<Workshop>> Create(Workshop workshop)
    {
        var created = await repository.AddWorkshop(workshop);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }
}
