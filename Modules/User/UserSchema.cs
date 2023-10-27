using CSTemplate.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSTemplate.Schemas;

[Table("User")]
public class UserSchema : BaseSchema
{
  [Column("id"), Key]
  public int Id { get; set; }

  [Column("email"), MaxLength(256)]
  public required string Email { get; set; }

  [Column("password"), MaxLength(256)]
  public required string Password { get; set; }
}