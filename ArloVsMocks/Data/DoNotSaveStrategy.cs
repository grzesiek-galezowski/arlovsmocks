using ArloVsMocks.Domain;

namespace ArloVsMocks.Data
{
  internal class DoNotSaveStrategy : IPersistenceStrategy
  {
    public void ApplyTo(RatingDto existingRating)
    {
      
    }
  }
}