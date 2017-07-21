using ArloVsMocks.Data;

namespace ArloVsMocks.Domain
{
  public interface IPersistenceStrategy
  {
    void ApplyTo(RatingDto value);
  }
}