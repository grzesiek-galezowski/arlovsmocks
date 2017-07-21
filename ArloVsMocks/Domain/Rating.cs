using ArloVsMocks.Data;

namespace ArloVsMocks.Domain
{
  public class Rating
  {
    private readonly IPersistenceStrategy _persistenceStrategy;
    private readonly IMovieBinding _movieBinding;
    private readonly ICriticBinding _criticBinding;
    private readonly RatingDto _dto;

    public Rating(
      RatingDto dto, 
      IPersistenceStrategy persistenceStrategy, 
      IMovieBinding movieBinding, 
      ICriticBinding criticBinding)
    {
      _dto = dto;
      _persistenceStrategy = persistenceStrategy;
      _movieBinding = movieBinding;
      _criticBinding = criticBinding;
    }

    private double AuthorRatingWeight => _criticBinding
      .RetrieveCriticBy(_dto.CriticId).RatingWeight();

    public void JoinBusinessTransaction()
    {
      _persistenceStrategy.ApplyTo(_dto);
    }

    public int UpdateStars(int valueStars)
    {
      return _dto.Stars = valueStars;
    }

    public bool IsForMovieWithAverageRating()
    {
      return _movieBinding.RetrieveMovieBy(_dto.MovieId).HasAverageRating();
    }


    public double RatingValue()
    {
      return _dto.Stars * AuthorRatingWeight;
    }

    public void AddDisparityTo(
      CriticalRatingWeightCalculation criticalRatingWeightCalculation)
    {
      //todo tell don't ask
      var disparity = _movieBinding.RetrieveMovieBy(_dto.MovieId)
        .DisparityBasedOn(_dto.Stars);
      criticalRatingWeightCalculation.AddDisparity(disparity);
    }

    public void AddTo(AverageRatingCalculation averageRatingCalculation)
    {
      averageRatingCalculation.AddValueWithWeight(
        RatingValue(), 
        AuthorRatingWeight);
    }
  }
}