﻿using System;
using System.Collections.Generic;

namespace Gezmo_PC_Store.DataBaseModels;

public partial class Order
{
    public long OrderId { get; set; }

    public int UserId { get; set; }

    public int TotalPrice { get; set; }

    public DateOnly OrderDate { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual User User { get; set; } = null!;
}
