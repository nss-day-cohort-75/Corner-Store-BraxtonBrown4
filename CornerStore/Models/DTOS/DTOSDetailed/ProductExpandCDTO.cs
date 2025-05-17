namespace CornerStore.Models.DTOS.Detailed;

using CornerStore.Models.DTOS.Default;

public class ProductExpandCDTO : DefaultProductDTO
{
   public DefaultCategoryDTO Category { get; set; }
}