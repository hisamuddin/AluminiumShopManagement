using AluminumShopManagement.APIs;
using AluminumShopManagement.APIs.Common;
using AluminumShopManagement.APIs.Dtos;
using AluminumShopManagement.APIs.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AluminumShopManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class ServiceSchedulesControllerBase : ControllerBase
{
    protected readonly IServiceSchedulesService _service;

    public ServiceSchedulesControllerBase(IServiceSchedulesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one ServiceSchedule
    /// </summary>
    [HttpPost()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<ServiceSchedule>> CreateServiceSchedule(
        ServiceScheduleCreateInput input
    )
    {
        var serviceSchedule = await _service.CreateServiceSchedule(input);

        return CreatedAtAction(
            nameof(ServiceSchedule),
            new { id = serviceSchedule.Id },
            serviceSchedule
        );
    }

    /// <summary>
    /// Delete one ServiceSchedule
    /// </summary>
    [HttpDelete("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> DeleteServiceSchedule(
        [FromRoute()] ServiceScheduleWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteServiceSchedule(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many ServiceSchedules
    /// </summary>
    [HttpGet()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<List<ServiceSchedule>>> ServiceSchedules(
        [FromQuery()] ServiceScheduleFindManyArgs filter
    )
    {
        return Ok(await _service.ServiceSchedules(filter));
    }

    /// <summary>
    /// Meta data about ServiceSchedule records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> ServiceSchedulesMeta(
        [FromQuery()] ServiceScheduleFindManyArgs filter
    )
    {
        return Ok(await _service.ServiceSchedulesMeta(filter));
    }

    /// <summary>
    /// Get one ServiceSchedule
    /// </summary>
    [HttpGet("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<ServiceSchedule>> ServiceSchedule(
        [FromRoute()] ServiceScheduleWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.ServiceSchedule(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one ServiceSchedule
    /// </summary>
    [HttpPatch("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> UpdateServiceSchedule(
        [FromRoute()] ServiceScheduleWhereUniqueInput uniqueId,
        [FromQuery()] ServiceScheduleUpdateInput serviceScheduleUpdateDto
    )
    {
        try
        {
            await _service.UpdateServiceSchedule(uniqueId, serviceScheduleUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
