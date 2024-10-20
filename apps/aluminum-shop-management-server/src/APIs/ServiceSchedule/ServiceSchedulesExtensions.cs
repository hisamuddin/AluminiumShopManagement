using AluminumShopManagement.APIs.Dtos;
using AluminumShopManagement.Infrastructure.Models;

namespace AluminumShopManagement.APIs.Extensions;

public static class ServiceSchedulesExtensions
{
    public static ServiceSchedule ToDto(this ServiceScheduleDbModel model)
    {
        return new ServiceSchedule
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static ServiceScheduleDbModel ToModel(
        this ServiceScheduleUpdateInput updateDto,
        ServiceScheduleWhereUniqueInput uniqueId
    )
    {
        var serviceSchedule = new ServiceScheduleDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            serviceSchedule.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            serviceSchedule.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return serviceSchedule;
    }
}
