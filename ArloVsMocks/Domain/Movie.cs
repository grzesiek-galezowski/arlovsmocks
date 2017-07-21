using System;
using ArloVsMocks.Data;

namespace ArloVsMocks.Domain
{
  public class Movie
  {
    private readonly Ratings _ratings;
    private readonly MovieDto _dto;
    private readonly CalculationsFactory _calculationsFactory;

    public Movie(MovieDto dto, Ratings ratings, CalculationsFactory calculationsFactory)
    {
      _dto = dto;
      _ratings = ratings;
      _calculationsFactory = calculationsFactory;
    }

    public void UpdateAverageRating()
    {
      var averageRatingCalculation = _calculationsFactory.ForAverageRating();
      _ratings.CalculateAverageRating(averageRatingCalculation);
      _dto.AverageRating = averageRatingCalculation.Result();
    }

    public bool Has(int movieId)
    {
      return _dto.Id == movieId;
    }

    public bool HasAverageRating()
    {
      return _dto.AverageRating.HasValue;
    }

    public double DisparityBasedOn(int stars)
    {
      return Math.Abs(stars - _dto.AverageRating.Value);
    }

    public void ShowAverageRatingOn(RatingOutput ratingOutput)
    {
      var newMovieRating = _dto.AverageRating.Value;
      ratingOutput.WriteNewMovieRating(newMovieRating);
    }

    public void Add(Rating movieRating)
    {
      movieRating.JoinBusinessTransaction();
    }
  }
}