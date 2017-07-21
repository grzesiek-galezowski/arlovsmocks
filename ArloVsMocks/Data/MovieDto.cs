using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArloVsMocks.Data
{
  [Table("Movie")]
  public class MovieDto
  {
    [Key]
    public int Id { get; set; }
    public double? AverageRating { get; set; }

    public virtual ICollection<RatingDto> Ratings { get; set; }
  }
}