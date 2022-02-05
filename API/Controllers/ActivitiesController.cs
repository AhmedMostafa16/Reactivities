using Application.Activities;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ActivitiesController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivities()
    {
        return await Mediator.Send(new List.Query()).ConfigureAwait(false);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity?>> GetActivity(Guid id)
    {
        return await Mediator.Send(new Details.Query {Id = id}).ConfigureAwait(false);
    }

    [HttpPost]
    public async Task<IActionResult> CreateActivity([FromBody] Activity activity)
    {
        await Mediator.Send(new Create.Command {Activity = activity}).ConfigureAwait(false);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditActivity(Guid id, [FromBody] Activity activity)
    {
        activity.Id = id;
        await Mediator.Send(new Edit.Command {Activity = activity}).ConfigureAwait(false);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteActivity(Guid id)
    {
        await Mediator.Send(new Delete.Command {Id = id}).ConfigureAwait(false);
        return Ok();
    }
}