using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArloVsMocks.Data
{
  [Table("Critic")]
  public class CriticDto 
  {
    [Key]
    public int Id { get; set; }
    [Required]
    public double RatingWeight { get; set; }

    public virtual ICollection<RatingDto> Ratings { get; set; }
  }
}