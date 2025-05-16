using CornerStore.Models.DTOS.Default;

namespace CornerStore.Models.DTOS.Detailed;

public class OrderExpandOPsDTO : DefaultOrderDTO
{
    public List<DefaultOrderProductDTO> OrderProducts { get; set; }
}