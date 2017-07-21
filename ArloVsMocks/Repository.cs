using System.Linq;
using ArloVsMocks.Data;
using ArloVsMocks.Domain;

namespace ArloVsMocks
{
  public class Repository : IMovieBinding, IUnitOfWork, ICriticBinding
  {
    private readonly MovieReviewEntities _db;
    private readonly CalculationsFactory _calculationsFactory;

    public Repository(MovieReviewEntities db)
    {
      _db = db;
      _calculationsFactory = new CalculationsFactory();
    }

    public Movies LoadMovies()
    {
      return new Movies(
        _db.Movies.Select(v => CreateMovie(v)).ToList());
    }

    private Movie CreateMovie(MovieDto movie)
    {
      return new Movie(movie, new Ratings(
        movie.Ratings.Select(From)), _calculationsFactory);
    }

    public Movie LoadMovieBy(int movieId)
    {
      return CreateMovie(_db.Movies.First(m => m.Id == movieId));
    }

    public Rating LoadRatingBy(int criticId, int movieId)
    {
      var dbRating = _db.Ratings.SingleOrDefault(
        r => r.MovieId == movieId && r.CriticId == criticId);
      Rating rating;
      if (dbRating != null)
      {
        rating = From(dbRating);
      }
      else
      {
        rating = new Rating(
          new RatingDto {MovieId = movieId, CriticId = criticId},
          new SaveInDbStrategy(_db), this, this);
      }
      return rating;
    }

    public Critics LoadCriticsHavingRated()
    {
      return new Critics(
        _db.Critics
        .Where(c => c.Ratings.Count > 0)
        .Select(c => new Critic(c, CreateRatingsOf(c), _calculationsFactory)));
    }

    public Critic RetrieveCriticBy(int criticId)
    {
      var critic = _db.Critics.Select(c => new CriticDto()).Single(c => c.Id == criticId);
      return new Critic(
        critic, CreateRatingsOf(critic), _calculationsFactory);
    }

    private Ratings CreateRatingsOf(CriticDto dto)
    {
      return new Ratings(dto.Ratings.Select(From));
    }

    public void Conclude()
    {
      _db.SaveChanges();
    }

    public Rating From(RatingDto r)
    {
      return new Rating(
        r, new DoNotSaveStrategy(), this, this);
    }

    public Movie RetrieveMovieBy(int movieId)
    {
      var first = _db.Movies.First(m => m.Id == movieId);
      return CreateMovie(first);
    }
  }
}