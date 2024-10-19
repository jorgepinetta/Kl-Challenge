using DevelopmentChallenge.Data.Contracts;
using System;

namespace DevelopmentChallenge.Data.Models
{
  public class EquilateralTriangleShape : IShape
  {
    private readonly decimal _side;

    public EquilateralTriangleShape(decimal side)
    {
      _side = side;
    }

    public decimal Area => ((decimal)Math.Sqrt(3) / 4) * _side * _side;

    public decimal Perimeter => _side * 3;
  }
}
