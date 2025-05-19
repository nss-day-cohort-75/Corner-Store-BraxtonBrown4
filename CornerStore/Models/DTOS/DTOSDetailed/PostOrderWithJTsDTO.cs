namespace CornerStore.Models.DTOS.Detailed;

using CornerStore.Models.DTOS.Default;

public class PostOrderWithJTsDTO : DefaultOrderDTO
{
    public List<OrderProduct> OrderProducts { get; set; } = new();
}