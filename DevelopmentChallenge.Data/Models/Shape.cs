using DevelopmentChallenge.Data.Contracts;

namespace DevelopmentChallenge.Data.Models
{
  public abstract class Shape : IShape
  {
    public abstract decimal GetArea();

    public abstract decimal GetPerimeter();
  }
}
