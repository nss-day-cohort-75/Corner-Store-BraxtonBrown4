namespace CornerStore.Models.DTOS.Detailed;

using CornerStore.Models.DTOS.Default;

public class CashierExpandOrdersDTO : DefaultCashierDTO
{
    public List<OrderExpandOPsDTO> Orders { get; set; }
}