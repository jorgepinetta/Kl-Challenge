using System;

namespace DevelopmentChallenge.Data.Models
{
  public class CircleShape : Shape
  {
    private readonly decimal _diameter;

    public CircleShape(decimal diameter)
    {
      _diameter = diameter;
    }

    public override decimal GetArea()
    {
      return (decimal)Math.PI * (_diameter * _diameter / 4);
    }

    public override decimal GetPerimeter()
    {
      return (decimal)Math.PI * _diameter;
    }
  }
}
