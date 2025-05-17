namespace CornerStore.Models.DTOS.Detailed;

using CornerStore.Models.DTOS.Default;

public class OrderProductExpandPDTO : DefaultOrderProductDTO
{
    public ProductExpandCDTO Product { get; set; }
}