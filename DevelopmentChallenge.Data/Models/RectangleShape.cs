using DevelopmentChallenge.Data.Contracts;

namespace DevelopmentChallenge.Data.Models
{
  public class RectangleShape : IShape
  {
    private readonly decimal _side1;

    private readonly decimal _side2;

    public RectangleShape(decimal side1, decimal side2)
    {
      _side1 = side1;
      _side2 = side2;
    }

    public decimal Area => _side1 * _side2;

    public decimal Perimeter => (_side1 * 2) + (_side2 * 2);
  }
}
