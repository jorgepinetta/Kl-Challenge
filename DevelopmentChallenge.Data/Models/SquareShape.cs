using DevelopmentChallenge.Data.Contracts;

namespace DevelopmentChallenge.Data.Models
{
  public class SquareShape : IShape
  {
    private readonly decimal _side;

    public SquareShape(decimal side)
    {
      _side = side;
    }

    public decimal Area => _side * _side;

    public decimal Perimeter => _side * 4;
  }
}
