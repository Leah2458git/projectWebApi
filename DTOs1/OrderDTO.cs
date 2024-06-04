using Entities;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DTOs;

public partial class OrderDTO
{
    public int OrderId { get; set; }

    public int UserId { get; set; }

    public DateOnly Date { get; set; }

    public int Sum { get; set; }

    public virtual ICollection<OrderItem>? OrderItems { get; set; } = new List<OrderItem>();
}
