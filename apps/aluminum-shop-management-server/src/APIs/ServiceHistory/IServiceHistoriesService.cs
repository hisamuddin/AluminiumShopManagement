using AluminumShopManagement.APIs.Common;
using AluminumShopManagement.APIs.Dtos;

namespace AluminumShopManagement.APIs;

public interface IServiceHistoriesService
{
    /// <summary>
    /// Create one ServiceHistory
    /// </summary>
    public Task<ServiceHistory> CreateServiceHistory(ServiceHistoryCreateInput servicehistory);

    /// <summary>
    /// Delete one ServiceHistory
    /// </summary>
    public Task DeleteServiceHistory(ServiceHistoryWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many ServiceHistories
    /// </summary>
    public Task<List<ServiceHistory>> ServiceHistories(ServiceHistoryFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about ServiceHistory records
    /// </summary>
    public Task<MetadataDto> ServiceHistoriesMeta(ServiceHistoryFindManyArgs findManyArgs);

    /// <summary>
    /// Get one ServiceHistory
    /// </summary>
    public Task<ServiceHistory> ServiceHistory(ServiceHistoryWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one ServiceHistory
    /// </summary>
    public Task UpdateServiceHistory(
        ServiceHistoryWhereUniqueInput uniqueId,
        ServiceHistoryUpdateInput updateDto
    );
}
