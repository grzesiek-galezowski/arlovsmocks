using ArloVsMocks.Domain;

namespace ArloVsMocks
{
  public class UpdateRatingCommand
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly RatingOutput _output;
    private readonly int _stars;
    private readonly Rating _rating;
    private readonly Critic _ratingAuthor;
    private readonly Critics _criticsHavingRated;
    private readonly Movies _allMovies;
    private readonly Movie _ratedMovie;

    public UpdateRatingCommand(
      int stars, 
      IUnitOfWork unitOfWork, 
      RatingOutput output, 
      Rating rating, 
      Critic ratingAuthor, 
      Critics criticsHavingRated, 
      Movies allMovies, 
      Movie ratedMovie)
    {
      _stars = stars;
      _unitOfWork = unitOfWork;
      _output = output;
      _rating = rating;
      _ratingAuthor = ratingAuthor;
      _criticsHavingRated = criticsHavingRated;
      _allMovies = allMovies;
      _ratedMovie = ratedMovie;
    }

    public void Execute()
    {
      _ratedMovie.Add(_rating);
      _ratingAuthor.Give(_rating, _stars);

      _criticsHavingRated.RecalculateRatingWeights();
      _allMovies.UpdateAverageRatings();

      _unitOfWork.Conclude();

      _ratingAuthor.ShowRatingWeightOn(_output);
      _ratedMovie.ShowAverageRatingOn(_output);
    }
  }
}