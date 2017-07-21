namespace ArloVsMocks.Domain
{
  public class CriticalRatingWeightCalculation
  {
    private double _totalDisparity;
    private int _numberOfRatingsForMoviesWithAverageRating;

    public CriticalRatingWeightCalculation(double initialTotalDisparity)
    {
      _totalDisparity = initialTotalDisparity;
    }

    public double Result()
    {
      var relativeDisparity = _totalDisparity / _numberOfRatingsForMoviesWithAverageRating;
      var criticRatingWeight = relativeDisparity > 2 ? 0.15 : relativeDisparity > 1 ? 0.33 : 1.0;
      return criticRatingWeight;
    }

    public void AddDisparity(double disparity)
    {
      _totalDisparity += disparity;
    }

    public void UpdateRatingsCountForMoviesWithAverageRating(int count)
    {
      _numberOfRatingsForMoviesWithAverageRating = count;
    }
  }
}