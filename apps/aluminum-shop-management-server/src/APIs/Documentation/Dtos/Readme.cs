using System.ComponentModel.DataAnnotations;

namespace AluminumShopManagement.APIs;

public class Readme
{
    [Required()]
    public string Description { get; set; }
}
