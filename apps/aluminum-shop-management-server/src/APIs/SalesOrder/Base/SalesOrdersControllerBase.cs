using AluminumShopManagement.APIs;
using AluminumShopManagement.APIs.Common;
using AluminumShopManagement.APIs.Dtos;
using AluminumShopManagement.APIs.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AluminumShopManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class SalesOrdersControllerBase : ControllerBase
{
    protected readonly ISalesOrdersService _service;

    public SalesOrdersControllerBase(ISalesOrdersService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one SalesOrder
    /// </summary>
    [HttpPost()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<SalesOrder>> CreateSalesOrder(SalesOrderCreateInput input)
    {
        var salesOrder = await _service.CreateSalesOrder(input);

        return CreatedAtAction(nameof(SalesOrder), new { id = salesOrder.Id }, salesOrder);
    }

    /// <summary>
    /// Delete one SalesOrder
    /// </summary>
    [HttpDelete("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> DeleteSalesOrder(
        [FromRoute()] SalesOrderWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteSalesOrder(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many SalesOrders
    /// </summary>
    [HttpGet()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<List<SalesOrder>>> SalesOrders(
        [FromQuery()] SalesOrderFindManyArgs filter
    )
    {
        return Ok(await _service.SalesOrders(filter));
    }

    /// <summary>
    /// Meta data about SalesOrder records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> SalesOrdersMeta(
        [FromQuery()] SalesOrderFindManyArgs filter
    )
    {
        return Ok(await _service.SalesOrdersMeta(filter));
    }

    /// <summary>
    /// Get one SalesOrder
    /// </summary>
    [HttpGet("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<SalesOrder>> SalesOrder(
        [FromRoute()] SalesOrderWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.SalesOrder(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one SalesOrder
    /// </summary>
    [HttpPatch("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> UpdateSalesOrder(
        [FromRoute()] SalesOrderWhereUniqueInput uniqueId,
        [FromQuery()] SalesOrderUpdateInput salesOrderUpdateDto
    )
    {
        try
        {
            await _service.UpdateSalesOrder(uniqueId, salesOrderUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
