/*
 *  Generic trapeze 
 *  Main base       (main)
 *  Minor Base      (minor)
 *  Oblique side 1  (oblique1)
 *  Oblique side 2  (oblique2)
 *  Height          (height)
 */

using DevelopmentChallenge.Data.Contracts;
using System;

namespace DevelopmentChallenge.Data.Models
{
  public class TrapezoidShape : IShape
  {
    private readonly decimal _mayor;
    private readonly decimal _minor;
    private readonly decimal _oblique1;
    private readonly decimal _oblique2;
    private readonly decimal _height;

    public TrapezoidShape(decimal mayor, decimal minor, decimal oblique1, decimal oblique2, decimal height)
    {
      _mayor = mayor > 0 ? mayor : throw new ArgumentOutOfRangeException(nameof(mayor));
      _minor = minor > 0 ? minor : throw new ArgumentOutOfRangeException(nameof(minor));
      _oblique1 = oblique1 > 0 ? oblique1 : throw new ArgumentOutOfRangeException(nameof(oblique1));
      _oblique2 = oblique2 > 0 ? oblique2 : throw new ArgumentOutOfRangeException(nameof(oblique2));
      _height = height > 0 ? height : throw new ArgumentOutOfRangeException(nameof(height));


      if (_mayor < _minor)
      {
        throw new ArgumentException("[Major] is less than [Minor].");
      }

      decimal diffBases = _mayor - _minor;
      if (oblique1 + oblique2 <= diffBases)
      {
        throw new ArgumentException("Closing condition.");
      }
    }

    public decimal Area => (_mayor + _minor) * _height / 2;

    public decimal Perimeter => _mayor + _minor + _oblique1 + _oblique2;
  }
}
