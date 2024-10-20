using DevelopmentChallenge.Data.Contracts;
using System;

namespace DevelopmentChallenge.Data.Models
{
  public class CircleShape : IShape
  {
    private readonly decimal _diameter;

    public CircleShape(decimal diameter)
    {
      _diameter = diameter > 0 ? diameter : throw new ArgumentOutOfRangeException(nameof(diameter));
    }

    public decimal Area => (decimal)Math.PI * (_diameter * _diameter / 4);

    public decimal Perimeter => (decimal)Math.PI * _diameter;
  }
}
