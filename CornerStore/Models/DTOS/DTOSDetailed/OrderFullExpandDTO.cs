using CornerStore.Models.DTOS.Default;

namespace CornerStore.Models.DTOS.Detailed;

public class OrderFullExpandDTO : DefaultOrderDTO
{
    public List<OrderProductExpandPDTO> OrderProducts { get; set; }
    public DefaultCashierDTO Cashier { get; set; }
}