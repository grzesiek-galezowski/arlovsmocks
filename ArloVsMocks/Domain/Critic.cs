using ArloVsMocks.Data;

namespace ArloVsMocks.Domain
{
  public class Critic
  {
    private readonly CriticDto _dto;
    private readonly Ratings _ratings;
    private readonly CalculationsFactory _calculationsFactory;

    public Critic(CriticDto dto, Ratings ratings, CalculationsFactory calculationsFactory)
    {
      _dto = dto;
      _ratings = ratings;
      _calculationsFactory = calculationsFactory;
    }

    public void ShowRatingWeightOn(RatingOutput ratingOutput)
    {
      ratingOutput.WriteRatingWeight(_dto.RatingWeight);
    }

    public void Give(Rating rating, int valueStars)
    {
      rating.UpdateStars(valueStars);
    }

    public void RecalculateRatingWeight()
    {
      var criticalRatingWeightCalculation = _calculationsFactory.ForCriticalRatingWeight();
      _ratings.CalculateRatingWeight(
        criticalRatingWeightCalculation);
      _dto.RatingWeight = criticalRatingWeightCalculation.Result();
    }

    public double RatingWeight() //todo tell don't ask
    {
      return _dto.RatingWeight;
    }
  }
}