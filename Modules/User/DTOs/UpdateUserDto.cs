using System.ComponentModel.DataAnnotations;

namespace CSTemplate.DTOs;

public class UpdateUserDto
{
  [EmailAddress(ErrorMessage = "Invalid email format.")]
  [MaxLength(256, ErrorMessage = "Email length cannot exceed 256 characters.")]
  public string? Email { get; set; }

  [MaxLength(256, ErrorMessage = "Password length cannot exceed 256 characters.")]
  public string? Password { get; set; }
}

