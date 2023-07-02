using System.ComponentModel.DataAnnotations;

namespace TravelPlanner.ViewModels
{
  public class RegisterViewModel
  {
    [Required]
    [EmailAddress]
    [Display(Name = "Email Address")]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "The password and confirm password do not match.")]
    public string ConfirmPassword { get; set; }
  }
}