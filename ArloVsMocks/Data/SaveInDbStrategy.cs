using ArloVsMocks.Domain;

namespace ArloVsMocks.Data
{
  public class SaveInDbStrategy : IPersistenceStrategy
  {
    private readonly MovieReviewEntities _movieReviewEntities;

    public SaveInDbStrategy(MovieReviewEntities movieReviewEntities)
    {
      _movieReviewEntities = movieReviewEntities;
    }

    public void ApplyTo(RatingDto existingRating)
    {
      _movieReviewEntities.Ratings.Add(existingRating);
    }
  }
}