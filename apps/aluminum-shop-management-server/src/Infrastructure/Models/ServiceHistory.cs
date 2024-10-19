using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AluminumShopManagement.Infrastructure.Models;

[Table("ServiceHistories")]
public class ServiceHistoryDbModel
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
