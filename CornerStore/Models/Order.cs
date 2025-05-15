
namespace CornerStore.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

public class Order
{
    public int Id { get; set; }

    [Required]
    public int CashierId { get; set; }

    public Cashier? Cashier { get; set; }

    public decimal Total
    {
        get
        {
            return OrderProducts?.Sum(op => op.Product.Price * op.Quantity) ?? 0;
        }
    }

    public DateTime? PaidOnDate { get; set; }

    public List<OrderProduct>? OrderProducts { get; set; }
}