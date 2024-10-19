using AluminumShopManagement.APIs.Dtos;
using AluminumShopManagement.Infrastructure.Models;

namespace AluminumShopManagement.APIs.Extensions;

public static class SalesOrdersExtensions
{
    public static SalesOrder ToDto(this SalesOrderDbModel model)
    {
        return new SalesOrder
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static SalesOrderDbModel ToModel(
        this SalesOrderUpdateInput updateDto,
        SalesOrderWhereUniqueInput uniqueId
    )
    {
        var salesOrder = new SalesOrderDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            salesOrder.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            salesOrder.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return salesOrder;
    }
}
