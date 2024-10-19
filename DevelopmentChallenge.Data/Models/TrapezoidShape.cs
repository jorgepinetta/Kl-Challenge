/*
 *  Generic trapeze 
 *  Main base       (main)
 *  Minor Base      (minor)
 *  Oblique side 1  (oblique1)
 *  Oblique side 2  (oblique2)
 *  Height          (height)
 */

using DevelopmentChallenge.Data.Contracts;

namespace DevelopmentChallenge.Data.Models
{
  public class TrapezoidShape : IShape
  {
    private readonly decimal _main;
    private readonly decimal _minor;
    private readonly decimal _oblique1;
    private readonly decimal _oblique2;
    private readonly decimal _height;

    public TrapezoidShape(decimal main, decimal minor, decimal oblique1, decimal oblique2, decimal height)
    {
      _main = main;
      _minor = minor;
      _oblique1 = oblique1;
      _oblique2 = oblique2;
      _height = height;
    }

    public decimal Area => (_main + _minor) * _height / 2;

    public decimal Perimeter => _main + _minor + _oblique1 + _oblique2;
  }
}
