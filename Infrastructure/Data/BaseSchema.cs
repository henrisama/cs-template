using System.ComponentModel.DataAnnotations.Schema;

namespace CSTemplate.Data;

public abstract class BaseSchema
{
  [Column(TypeName = "timestamp with time zone")]
  public DateTime CreatedAt { get; set; }

  [Column(TypeName = "timestamp with time zone")]
  public DateTime UpdatedAt { get; set; }

  [Column(TypeName = "timestamp with time zone")]
  public DateTime? DeletedAt { get; set; }

  public BaseSchema()
  {
    CreatedAt = DateTime.UtcNow;
    UpdatedAt = DateTime.UtcNow;
  }
}