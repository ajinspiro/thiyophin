using System;
using System.Collections.Generic;

namespace LibraryManagementSystem2_0.Models;

public class Member
{
    public int Id { get; set; }

    public string FullName { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public DateTime JoinedOn { get; set; } = DateTime.UtcNow;

    public ICollection<Checkout> Checkouts { get; set; } = new List<Checkout>();
}

