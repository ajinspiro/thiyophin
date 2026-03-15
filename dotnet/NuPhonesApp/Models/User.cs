using System;
using System.ComponentModel.DataAnnotations;

namespace NuPhonesApp.Models;

public class User
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string FirstName {get; set;}

    [Required]
    [MaxLength(50)]
    public string LastName {get; set;}

    [Required]
    [MaxLength(50)]
    public string Username {get; set;}

    [Required]
    [EmailAddress]
    public string Email {get; set;}

    [Required]
    [Phone]
    public string Phone {get; set;}

    [Required]
    public string Password {get; set;}
}
