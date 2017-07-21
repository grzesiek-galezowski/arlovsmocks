using System.Collections.Generic;

namespace ArloVsMocks.Domain
{
  public class Movies
  {
    private readonly IEnumerable<Movie> _movies;

    public Movies(IEnumerable<Movie> movies)
    {
      _movies = movies;
    }

    public void UpdateAverageRatings()
    {
      foreach (var movie in _movies)
      {
        movie.UpdateAverageRating();
      }
    }
  }
}