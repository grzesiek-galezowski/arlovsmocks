using System.Collections.Generic;
using System.Linq;

namespace ArloVsMocks.Domain
{
  public class Ratings
  {
    private readonly IEnumerable<Rating> _ratingsCollection;

    public Ratings(IEnumerable<Rating> domainRatingsCollection)
    {
      _ratingsCollection = domainRatingsCollection;
    }

    public void CalculateRatingWeight(CriticalRatingWeightCalculation criticalRatingWeightCalculation)
    {
      var ratingsForMoviesWithAverageRating = RatingsForMoviesWithAverageRating();
      criticalRatingWeightCalculation.UpdateRatingsCountForMoviesWithAverageRating(
        ratingsForMoviesWithAverageRating.Count);
      foreach (var rating in ratingsForMoviesWithAverageRating)
      {
        rating.AddDisparityTo(criticalRatingWeightCalculation);
      }
    }


    public void CalculateAverageRating(AverageRatingCalculation averageRatingCalculation)
    {
      foreach (var rating in _ratingsCollection)
      {
        rating.AddTo(averageRatingCalculation);
      }
    }

    private List<Rating> RatingsForMoviesWithAverageRating()
    {
      return _ratingsCollection.Where(r => 
        r.IsForMovieWithAverageRating()).ToList();
    }
  }
}