using CornerStore.Models.DTOS.Default;

namespace CornerStore.Models.DTOS.Detailed;

public class ProductsExpanCategoryDTO : DefaultProductDTO
{
    public Category Category { get; set; }
}