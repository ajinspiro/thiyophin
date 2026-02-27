using System;

namespace LibraryManagementSystem2_0.Models;

public class CheckoutListItemViewModel
{
    public int Id { get; set; }
    public string BookTitle { get; set; } = string.Empty;
    public string BookIsbn { get; set; } = string.Empty;
    public string MemberName { get; set; } = string.Empty;
    public DateTime CheckedOutAt { get; set; }
}

