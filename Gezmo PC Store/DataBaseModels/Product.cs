using System;
using System.Collections.Generic;

namespace Gezmo_PC_Store.DataBaseModels;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public int CategoryId { get; set; }

    public string? ImageUrl { get; set; }

    public int? Sold { get; set; } = 0;
    public DateTime? InsertionDate { get; set; }
    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public override string ToString()
    {
        return $"Product: {Name} ProductId: {ProductId} Name: {Name} Description: {Description}";
    }
}
