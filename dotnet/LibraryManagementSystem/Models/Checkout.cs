using System;

namespace LibraryManagementSystem.Models;

public class Checkout
{
    public int Id { get; set; }
    public DateTime CheckoutDate { get; set; }
    public int MemberId { get; set; }
    public int BookId { get; set; }
    public DateTime? ReturnDate { get; set; }
    public Member? Member { get; set; }
    public Book? Book { get; set; }
}
