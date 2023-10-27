using System.ComponentModel.DataAnnotations;

namespace CSTemplate.DTOs;

public class CreateUserDto
{
  [Required(ErrorMessage = "Email is required.")]
  [EmailAddress(ErrorMessage = "Invalid email format.")]
  [MaxLength(256, ErrorMessage = "Email length cannot exceed 256 characters.")]
  public required string Email { get; set; }

  [Required(ErrorMessage = "Password is required.")]
  [MaxLength(256, ErrorMessage = "Password length cannot exceed 256 characters.")]
  public required string Password { get; set; }
}

