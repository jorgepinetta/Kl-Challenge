using System;
using System.Collections.Generic;
using DevelopmentChallenge.Data.Contracts;
using DevelopmentChallenge.Data.Models;
using DevelopmentChallenge.Data.Services;
using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
  [TestFixture]
  public class DataEvoTestsExceptions
  {
    [TestCase]
    public void TestShape_ArgumentOutOfRangeException()
    {
      Assert.Throws<ArgumentOutOfRangeException>(() => new CircleShape(-5));
      Assert.Throws<ArgumentOutOfRangeException>(() => new EquilateralTriangleShape(0));
      Assert.Throws<ArgumentOutOfRangeException>(() => new RectangleShape(-5.8m, 6));
      Assert.Throws<ArgumentOutOfRangeException>(() => new SquareShape(-0.23m));
      Assert.Throws<ArgumentOutOfRangeException>(() => new TrapezoidShape(4, -5, 5, 6, 7));
    }
  }
}
