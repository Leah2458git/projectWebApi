
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DTOs;

public partial class OrderDTO
{
    public int OrderId { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public int Sum { get; set; }

    [Required, DataType("dd-mm-yyyy")]
    public DateTime Date { get; set; }

    public virtual ICollection<OrderItemDTO>? OrderItems { get; set; } = new List<OrderItemDTO>();

}
