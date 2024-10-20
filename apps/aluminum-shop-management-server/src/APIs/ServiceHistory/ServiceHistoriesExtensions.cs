using AluminumShopManagement.APIs.Dtos;
using AluminumShopManagement.Infrastructure.Models;

namespace AluminumShopManagement.APIs.Extensions;

public static class ServiceHistoriesExtensions
{
    public static ServiceHistory ToDto(this ServiceHistoryDbModel model)
    {
        return new ServiceHistory
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static ServiceHistoryDbModel ToModel(
        this ServiceHistoryUpdateInput updateDto,
        ServiceHistoryWhereUniqueInput uniqueId
    )
    {
        var serviceHistory = new ServiceHistoryDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            serviceHistory.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            serviceHistory.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return serviceHistory;
    }
}
