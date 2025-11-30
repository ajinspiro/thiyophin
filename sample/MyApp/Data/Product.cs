using System;
using System.Collections.Generic;

namespace MyApp.Data;

public partial class Product
{
    public int Id { get; set; }

    public string? ProductName { get; set; }

    public int? ManufacturerId { get; set; }

    public bool? IsAvailable { get; set; }

    public decimal? Price { get; set; }

    public DateOnly? ReleaseDate { get; set; }

    public DateTime? LastRestocked { get; set; }

    public virtual Manufacturer? Manufacturer { get; set; }
}
