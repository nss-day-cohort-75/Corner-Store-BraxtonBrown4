namespace CornerStore.Models.DTOS.Default;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class DefaultProductDTO
{
    public int Id { get; set; }
    [Required]
    public string ProductName { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public string Brand { get; set; }
    [Required]
    public int CategoryId { get; set; }
}