/******************************************************************************************************************/
/******* ¿Qué pasa si debemos soportar un nuevo idioma para los reportes, o agregar más formas geométricas? *******/
/******************************************************************************************************************/

/*
 * TODO: 
 * Refactorizar la clase para respetar principios de la programación orientada a objetos.
 * Implementar la forma Trapecio/Rectangulo. 
 * Agregar el idioma Italiano (o el deseado) al reporte.
 * Se agradece la inclusión de nuevos tests unitarios para validar el comportamiento de la nueva funcionalidad agregada (los tests deben pasar correctamente al entregar la solución, incluso los actuales.)
 * Una vez finalizado, hay que subir el código a un repo GIT y ofrecernos la URL para que podamos utilizar la nueva versión :).
 */

using DevelopmentChallenge.Data.Contracts;
using DevelopmentChallenge.Data.Models;
using DevelopmentChallenge.Data.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace DevelopmentChallenge.Data.Classes
{
  [Obsolete("DEPRECATED: Use Shape service", false)]
  public class FormaGeometrica
  {
    public const int Cuadrado = 1;
    public const int TrianguloEquilatero = 2;
    public const int Circulo = 3;

    public const int Castellano = 1;
    public const int Ingles = 2;

    private readonly decimal _lado;

    private static readonly IEnumerable<string> _validTypes = new List<string>() { nameof(SquareShape), nameof(CircleShape), nameof(EquilateralTriangleShape) };

    public IShape Shape { get; private set; }

    private static readonly NumberFormatInfo _helpCulture = new NumberFormatInfo
    {
      NumberDecimalSeparator = ",",
      NumberGroupSeparator = "."
    };

    public int Tipo { get; set; }

    public FormaGeometrica(int tipo, decimal ancho)
    {
      Tipo = tipo;
      _lado = ancho;
      switch (Tipo)
      {
        case Cuadrado:
          Shape = new SquareShape(ancho);
          break;
        case Circulo:
          Shape = new CircleShape(ancho);
          break;
        case TrianguloEquilatero:
          Shape = new EquilateralTriangleShape(ancho);
          break;
        default:
          throw new ArgumentOutOfRangeException(@"Unknown form");
      }
    }

    public static string Imprimir(List<FormaGeometrica> formas, int idioma)
    {
      string lang = idioma == Castellano ? "es" : "en";
      List<IShape> shapes = new List<IShape>();
      foreach (string shapeTypeName in _validTypes)
      {
        shapes.AddRange(formas.Where(r => r.Shape.GetType().Name == shapeTypeName).Select(r => r.Shape));
      }

      return ShapeReportService.HtmlReport(shapes, lang);
    }

    public decimal CalcularArea()
    {
      return Shape.Area;
    }

    public decimal CalcularPerimetro()
    {
      return Shape.Perimeter;
    }
  }
}