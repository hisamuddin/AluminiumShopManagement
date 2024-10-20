using AluminumShopManagement.APIs;
using AluminumShopManagement.APIs.Common;
using AluminumShopManagement.APIs.Dtos;
using AluminumShopManagement.APIs.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AluminumShopManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class ServiceHistoriesControllerBase : ControllerBase
{
    protected readonly IServiceHistoriesService _service;

    public ServiceHistoriesControllerBase(IServiceHistoriesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one ServiceHistory
    /// </summary>
    [HttpPost()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<ServiceHistory>> CreateServiceHistory(
        ServiceHistoryCreateInput input
    )
    {
        var serviceHistory = await _service.CreateServiceHistory(input);

        return CreatedAtAction(
            nameof(ServiceHistory),
            new { id = serviceHistory.Id },
            serviceHistory
        );
    }

    /// <summary>
    /// Delete one ServiceHistory
    /// </summary>
    [HttpDelete("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> DeleteServiceHistory(
        [FromRoute()] ServiceHistoryWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteServiceHistory(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many ServiceHistories
    /// </summary>
    [HttpGet()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<List<ServiceHistory>>> ServiceHistories(
        [FromQuery()] ServiceHistoryFindManyArgs filter
    )
    {
        return Ok(await _service.ServiceHistories(filter));
    }

    /// <summary>
    /// Meta data about ServiceHistory records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> ServiceHistoriesMeta(
        [FromQuery()] ServiceHistoryFindManyArgs filter
    )
    {
        return Ok(await _service.ServiceHistoriesMeta(filter));
    }

    /// <summary>
    /// Get one ServiceHistory
    /// </summary>
    [HttpGet("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<ServiceHistory>> ServiceHistory(
        [FromRoute()] ServiceHistoryWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.ServiceHistory(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one ServiceHistory
    /// </summary>
    [HttpPatch("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> UpdateServiceHistory(
        [FromRoute()] ServiceHistoryWhereUniqueInput uniqueId,
        [FromQuery()] ServiceHistoryUpdateInput serviceHistoryUpdateDto
    )
    {
        try
        {
            await _service.UpdateServiceHistory(uniqueId, serviceHistoryUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
