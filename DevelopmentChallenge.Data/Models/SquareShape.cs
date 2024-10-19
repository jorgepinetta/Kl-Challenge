using System;

namespace DevelopmentChallenge.Data.Models
{
  public class SquareShape : Shape
  {
    private readonly decimal _side;

    public SquareShape(decimal side)
    {
      _side = side;
    }

    public override decimal GetArea()
    {
      return _side * _side;
    }

    public override decimal GetPerimeter()
    {
      return _side * 4;
    }
  }
}
