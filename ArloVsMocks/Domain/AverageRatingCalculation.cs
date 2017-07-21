namespace ArloVsMocks.Domain
{
  public class AverageRatingCalculation
  {
    private double _weightTotal;
    private double _ratingTotal;

    public AverageRatingCalculation(double weightTotal, double ratingTotal)
    {
      _weightTotal = weightTotal;
      _ratingTotal = ratingTotal;
    }

    public double Result()
    {
      return _ratingTotal / _weightTotal;
    }

    public void AddValueWithWeight(double ratingValue, double authorRatingWeight)
    {
      _weightTotal = _weightTotal + authorRatingWeight;
      _ratingTotal = _ratingTotal + ratingValue;
    }
  }
}