using System.ComponentModel.DataAnnotations;

namespace CornerStore.Models.DTOS.Default;

public class DefaultCategoryDTO
{
    public int Id { get; set; }

    [Required]
    public string CategoryName { get; set; }
}