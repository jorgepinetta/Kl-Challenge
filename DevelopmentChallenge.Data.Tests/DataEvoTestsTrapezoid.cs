using System;
using DevelopmentChallenge.Data.Models;
using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
  [TestFixture]
  public class DataEvoTestsTrpaezoid
  {
    [TestCase]
    public void TestTrapezoid_ArgumentOutOfRangeException()
    {
      Assert.Throws<ArgumentOutOfRangeException>(() => new TrapezoidShape(4, -5, 5, 6, 7));
    }

    [TestCase]
    public void TestTrapezoid_MinorMayor()
    {
      Assert.Throws<ArgumentException>(() => new TrapezoidShape(4, 5, 5, 6, 7), "[Major] is greater than [Minor].");
    }

    [TestCase]
    public void TestTrapezoid_ClosingCondition()
    {
      Assert.Throws<ArgumentException>(() => new TrapezoidShape(52, 40, 5, 6, 7), "The closing condition is met.");
    }
  }
}
