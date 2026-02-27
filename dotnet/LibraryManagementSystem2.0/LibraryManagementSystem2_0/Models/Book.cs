using System;
using System.Collections.Generic;

namespace LibraryManagementSystem2_0.Models;

public class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Isbn { get; set; } = string.Empty;

    public DateTime AddedOn { get; set; } = DateTime.UtcNow;

    public ICollection<Checkout> Checkouts { get; set; } = new List<Checkout>();
}

