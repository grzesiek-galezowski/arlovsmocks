using System.Collections.Generic;

namespace ArloVsMocks.Domain
{
  public class Critics
  {
    private readonly IEnumerable<Critic> _critics;

    public Critics(IEnumerable<Critic> critics)
    {
      _critics = critics;
    }

    public void RecalculateRatingWeights()
    {
      foreach (var domainCritic in _critics)
      {
        domainCritic.RecalculateRatingWeight();
      }
    }
  }
}