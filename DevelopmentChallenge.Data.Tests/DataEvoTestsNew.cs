using System;
using System.Collections.Generic;
using DevelopmentChallenge.Data.Contracts;
using DevelopmentChallenge.Data.Models;
using DevelopmentChallenge.Data.Services;
using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
  [TestFixture]
  public class DataEvoTestsNew
  {
    [TestCase]
    public void TestResumeEmptyList_es()
    {
      Assert.That(ShapeReportService.HtmlReport(new List<IShape>(), "es"), Is.EqualTo("<h1>Lista vacía de formas!</h1>"));
    }

    [TestCase]
    public void TestResumeEmptyList_en()
    {
      Assert.That(ShapeReportService.HtmlReport(new List<IShape>(), "en"), Is.EqualTo("<h1>Empty list of shapes!</h1>"));
    }

    [TestCase]
    public void TestResumeEmptyList_it()
    {
      Assert.That(ShapeReportService.HtmlReport(new List<IShape>(), "it"), Is.EqualTo("<h1>Elenco vuoto di forme!</h1>"));
    }

    [TestCase]
    public void TestResumeEmptyList_langnotfound()
    {
      Assert.That(ShapeReportService.HtmlReport(new List<IShape>(), "ru"), Is.EqualTo("<h1>[empty-list]</h1>"));
    }

    [TestCase]
    public void TestResumenMultiShapes_es()
    {
      var formas = new List<IShape>
      {
        new SquareShape(5),
        new CircleShape(3),
        new EquilateralTriangleShape(4),
        new RectangleShape(2, 4),
        new SquareShape(2),
        new EquilateralTriangleShape(9),
        new TrapezoidShape(4, 2, 5, 8, 5),
        new CircleShape(2.75m),
        new EquilateralTriangleShape(4.2m),
      };

      var resumen = ShapeReportService.HtmlReport(formas, "es");
      Assert.That(resumen, Is.EqualTo("<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>1 Rectángulo | Area 8 | Perimetro 12 <br/>1 Trapezoide | Area 15 | Perimetro 19 <br/>TOTAL:<br/>9 formas Perimetro 128,66 Area 114,65"));
    }

    [TestCase]
    public void TestResumenMultiShapes_en()
    {
      var formas = new List<IShape>
      {
        new SquareShape(5),
        new CircleShape(3),
        new EquilateralTriangleShape(4),
        new RectangleShape(2, 4),
        new SquareShape(2),
        new EquilateralTriangleShape(9),
        new TrapezoidShape(4, 2, 5, 8, 5),
        new CircleShape(2.75m),
        new EquilateralTriangleShape(4.2m),
      };

      var resumen = ShapeReportService.HtmlReport(formas, "en");
      Assert.That(resumen, Is.EqualTo("<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>1 Rectangle | Area 8 | Perimeter 12 <br/>1 Trapezoid | Area 15 | Perimeter 19 <br/>TOTAL:<br/>9 shapes Perimeter 128,66 Area 114,65"));
    }

    [TestCase]
    public void TestResumenMultiShapes_it()
    {
      var formas = new List<IShape>
      {
        new SquareShape(5),
        new CircleShape(3),
        new EquilateralTriangleShape(4),
        new RectangleShape(2, 4),
        new SquareShape(2),
        new EquilateralTriangleShape(9),
        new TrapezoidShape(4, 2, 5, 8, 5),
        new CircleShape(2.75m),
        new EquilateralTriangleShape(4.2m),
      };

      var resumen = ShapeReportService.HtmlReport(formas, "it");
      Assert.That(resumen, Is.EqualTo("<h1>Rapporto sulle forme</h1>2 Quadrati | Area 29 | Perimetro 28 <br/>2 Cerchi | Area 13,01 | Perimetro 18,06 <br/>3 Triangoli | Area 49,64 | Perimetro 51,6 <br/>1 Rettangolo | Area 8 | Perimetro 12 <br/>1 Trapezio | Area 15 | Perimetro 19 <br/>TOTALE:<br/>9 forme Perimetro 128,66 Area 114,65"));
    }
  }
}
