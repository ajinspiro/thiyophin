using System;

namespace LibraryManagementSystem2_0.Models;

public class BookListItemViewModel
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Isbn { get; set; } = string.Empty;
    public DateTime AddedOn { get; set; }
    public bool IsOut { get; set; }
}

