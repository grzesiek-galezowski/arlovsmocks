using System;

namespace ArloVsMocks
{
  public class RatingOutput
  {
    public void WriteNewMovieRating(double newMovieRating)
    {
      Console.WriteLine("New movie rating: {0:N1}", newMovieRating);
    }

    public void WriteRatingWeight(double newCriticRatingWeight)
    {
      Console.WriteLine("New critic rating weight: {0:N1}", newCriticRatingWeight);
    }
  }
}