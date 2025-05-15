
namespace CornerStore.Models.DTOS.Default;
using System;

public class DefaultOrderDTO
{
    public int Id { get; set; }
    public int CashierId { get; set; }
    public decimal Total { get; set; }
    public DateTime PaidOnDate { get; set; }
}