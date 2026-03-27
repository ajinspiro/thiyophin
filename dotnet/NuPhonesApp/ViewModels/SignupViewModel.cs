using System;
using System.ComponentModel.DataAnnotations;

namespace NuPhonesApp.ViewModels;

public class SignupViewModel
{
    [Required]
    [StringLength(50)]
    public string FirstName {get; set;}

    [Required]
    [StringLength(50)]
    public string LastName {get; set;}

    [Required]
    [StringLength(50)]
    public string UserName {get; set;}

    [Required]
    [EmailAddress]
    public string Email {get; set;}

    [Required]
    [Phone]
    public string Phone {get; set;}

    [Required]
    [MinLength(8)]
    public string Password {get; set;}

    [Required]
    [Compare("Password", ErrorMessage = "Password do not match")]
    public string ConfirmPassword {get; set;}

}
