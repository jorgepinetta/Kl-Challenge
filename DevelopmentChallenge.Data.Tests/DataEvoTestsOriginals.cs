using System.Collections.Generic;
using DevelopmentChallenge.Data.Contracts;
using DevelopmentChallenge.Data.Models;
using DevelopmentChallenge.Data.Services;
using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
  [TestFixture]
  public class DataEvoTestsOriginals
  {
    [TestCase]
    public void TestResumenListaVacia()
    {
      Assert.That(ShapeReportService.HtmlReport(new List<IShape>(), "es"), Is.EqualTo("<h1>Lista vacía de formas!</h1>"));
    }

    [TestCase]
    public void TestResumenListaVaciaFormasEnIngles()
    {
      Assert.That(ShapeReportService.HtmlReport(new List<IShape>(), "en"), Is.EqualTo("<h1>Empty list of shapes!</h1>"));
    }

    [TestCase]
    public void TestResumenListaConUnCuadrado()
    {
      var cuadrados = new List<IShape> { new SquareShape(5) };

      var resumen = ShapeReportService.HtmlReport(cuadrados, "es");

      Assert.That(resumen, Is.EqualTo("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25"));
    }

    [TestCase]
    public void TestResumenListaConMasCuadrados()
    {
      var cuadrados = new List<IShape>
      {
        new SquareShape(5),
        new SquareShape(1),
        new SquareShape(3),
      };

      var resumen = ShapeReportService.HtmlReport(cuadrados, "en");

      Assert.That(resumen, Is.EqualTo("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35"));
    }

    [TestCase]
    public void TestResumenListaConMasTipos()
    {
      var formas = new List<IShape>
      {
        new SquareShape(5),
        new CircleShape(3),
        new EquilateralTriangleShape(4),
        new SquareShape(2),
        new EquilateralTriangleShape(9),
        new CircleShape(2.75m),
        new EquilateralTriangleShape(4.2m),
      };

      var resumen = ShapeReportService.HtmlReport(formas, "en");

      Assert.That(resumen, Is.EqualTo("<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65"));
    }

    [TestCase]
    public void TestResumenListaConMasTiposEnCastellano()
    {
      var formas = new List<IShape>
      {
        new SquareShape(5),
        new CircleShape(3),
        new EquilateralTriangleShape(4),
        new SquareShape(2),
        new EquilateralTriangleShape(9),
        new CircleShape(2.75m),
        new EquilateralTriangleShape(4.2m),
      };

      var resumen = ShapeReportService.HtmlReport(formas, "es");

      Assert.That(resumen, Is.EqualTo("<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65"));
    }
  }
}
