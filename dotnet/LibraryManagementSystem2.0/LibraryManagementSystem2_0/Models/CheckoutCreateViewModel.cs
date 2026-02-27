using System.Collections.Generic;

namespace LibraryManagementSystem2_0.Models;

public class CheckoutCreateViewModel
{
    public string? MemberSearch { get; set; }
    public string? BookSearch { get; set; }

    public int? SelectedMemberId { get; set; }
    public int? SelectedBookId { get; set; }

    public List<Member> Members { get; set; } = new();
    public List<Book> Books { get; set; } = new();
}

