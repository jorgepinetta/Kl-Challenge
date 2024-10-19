using System;

namespace DevelopmentChallenge.Data.Models
{
  public class EquilateralTriangleShape : Shape
  {
    private readonly decimal _side;

    public EquilateralTriangleShape(decimal side)
    {
      _side = side;
    }

    public override decimal GetArea()
    {
      return ((decimal)Math.Sqrt(3) / 4) * _side * _side;
    }

    public override decimal GetPerimeter()
    {
      return _side * 3;
    }
  }
}
