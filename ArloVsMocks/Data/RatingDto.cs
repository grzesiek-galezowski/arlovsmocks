using System.ComponentModel.DataAnnotations;

namespace ArloVsMocks.Data
{
  [Table("Rating")]
  public class RatingDto
  {
    [Key, Column(Order = 0)]
    [ForeignKey("Movie")]
    public int MovieId { get; set; }
    [Key, Column(Order = 1)]
    [ForeignKey("Critic")]
    public int CriticId { get; set; }
    public int Stars { get; set; }

    public virtual MovieDto Movie { get; set; }
    public virtual CriticDto Critic { get; set; }
  }
}