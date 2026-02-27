using System;

namespace LibraryManagementSystem2_0.Models;

public class Checkout
{
    public int Id { get; set; }

    public int MemberId { get; set; }

    public int BookId { get; set; }

    public DateTime CheckedOutAt { get; set; } = DateTime.UtcNow;

    public DateTime? DueAt { get; set; }

    public DateTime? ReturnedAt { get; set; }

    public Member? Member { get; set; }

    public Book? Book { get; set; }
}

