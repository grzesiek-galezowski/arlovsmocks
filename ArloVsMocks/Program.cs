using System;
using ArloVsMocks.Data;

namespace ArloVsMocks
{
  class Program
    {
        static void Main(string[] args)
        {
            //parse input
            int movieId;
            int criticId;
            int stars;
            try
            {
                movieId = Int32.Parse(args[0]);
                criticId = Int32.Parse(args[1]);
                stars = Int32.Parse(args[2]);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            //process rating
            MovieReviewEntities db = null;
            try
            {
              db = new MovieReviewEntities();
              var repository = new Repository(db);
              var movieRating = repository.LoadRatingBy(criticId, movieId);
              new UpdateRatingCommand(stars, 
                repository, 
                new RatingOutput(), 
                movieRating, 
                repository.RetrieveCriticBy(criticId), 
                repository.LoadCriticsHavingRated(), 
                repository.LoadMovies(),
                repository.LoadMovieBy(movieId)).Execute();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (db != null) db.Dispose();
            }

            Console.ReadKey();
        }
    }
}
