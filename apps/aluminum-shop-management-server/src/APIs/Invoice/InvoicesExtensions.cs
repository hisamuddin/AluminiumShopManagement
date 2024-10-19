using AluminumShopManagement.APIs.Dtos;
using AluminumShopManagement.Infrastructure.Models;

namespace AluminumShopManagement.APIs.Extensions;

public static class InvoicesExtensions
{
    public static Invoice ToDto(this InvoiceDbModel model)
    {
        return new Invoice
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static InvoiceDbModel ToModel(
        this InvoiceUpdateInput updateDto,
        InvoiceWhereUniqueInput uniqueId
    )
    {
        var invoice = new InvoiceDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            invoice.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            invoice.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return invoice;
    }
}
