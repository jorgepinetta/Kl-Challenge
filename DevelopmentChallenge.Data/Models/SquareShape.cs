using DevelopmentChallenge.Data.Contracts;
using System;

namespace DevelopmentChallenge.Data.Models
{
  public class SquareShape : IShape
  {
    private readonly decimal _side;

    public SquareShape(decimal side)
    {
      _side = side > 0  ? side : throw new ArgumentOutOfRangeException(nameof(side)) ;
    }

    public decimal Area => _side * _side;

    public decimal Perimeter => _side * 4;
  }
}
