using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models;

public class Book
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public DateTime AddedOn { get; set; }
    public bool IsCheckedOut { get; set; }

}
