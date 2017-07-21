namespace ArloVsMocks.Domain
{
  public class CalculationsFactory
  {
    public CriticalRatingWeightCalculation ForCriticalRatingWeight()
    {
      return new CriticalRatingWeightCalculation(0);
    }

    public AverageRatingCalculation ForAverageRating()
    {
      return new AverageRatingCalculation(0, 0);
    }
  }
}