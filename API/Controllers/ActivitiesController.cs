using Application.Activities;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ActivitiesController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetActivities()
    {
        return HandleResult(await Mediator.Send(new List.Query()).ConfigureAwait(false));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetActivity(Guid id)
    {
        return HandleResult(await Mediator.Send(new Details.Query { Id = id }).ConfigureAwait(false));
    }

    [HttpPost]
    public async Task<IActionResult> CreateActivity([FromBody] Activity activity)
    {
        return HandleResult(await Mediator.Send(new Create.Command { Activity = activity }).ConfigureAwait(false));
    }

    [Authorize(Policy = "IsActivityHost")]
    [HttpPut("{id}")]
    public async Task<IActionResult> EditActivity(Guid id, [FromBody] Activity activity)
    {
        activity.Id = id;
        return HandleResult(await Mediator.Send(new Edit.Command { Activity = activity }).ConfigureAwait(false));
    }

    [Authorize(Policy = "IsActivityHost")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteActivity(Guid id)
    {
        await Mediator.Send(new Delete.Command { Id = id }).ConfigureAwait(false);
        return Ok();
    }

    [HttpPost("{id}/attend")]
    public async Task<IActionResult> Attend(Guid id)
    {
        return HandleResult(await Mediator.Send(new UpdateAttendance.Command { Id = id }).ConfigureAwait(false));
    }
}