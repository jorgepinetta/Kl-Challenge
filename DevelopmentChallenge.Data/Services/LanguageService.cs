using System.Collections.Generic;

namespace DevelopmentChallenge.Data.Services
{
  public static class LanguageService
  {
    private static readonly Dictionary<string, Dictionary<string, string>> Translations = new Dictionary<string, Dictionary<string, string>>
    {
      { "en", new Dictionary<string, string>
        {
          { "circleshape", "Circle" },
          { "circleshape-pluralize", "Circles" },
          { "equilateraltriangleshape", "Triangle" },
          { "equilateraltriangleshape-pluralize", "Triangles" },
          { "rectangleshape", "Rectangle" },
          { "rectangleshape-pluralize", "Rectangles" },
          { "squareshape", "Square" },
          { "squareshape-pluralize", "Squares" },
          { "trapezoidshape", "Trapezoid" },
          { "trapezoidshape-pluralize", "Trapezoids" },
          { "empty-list", "Empty list of shapes!"},
          { "report-header", "Shapes report"},
          { "total", "Total"},
          { "shapes", "Shapes"},
          { "perimeter", "Perimeter"},
          { "area", "Area"},
        }
      },
      { "es", new Dictionary<string, string>
        {
          { "circleshape", "Círculo" },
          { "circleshape-pluralize", "Círculos" },
          { "equilateraltriangleshape", "Triángulo" },
          { "equilateraltriangleshape-pluralize", "Triángulos" },
          { "rectangleshape", "Rectángulo" },
          { "rectangleshape-pluralize", "Rectángulos" },
          { "squareshape", "Cuadrado" },
          { "squareshape-pluralize", "Cuadrados" },
          { "trapezoidshape", "Trapezoide" },
          { "trapezoidshape-pluralize", "Trapezoides" },
          { "empty-list", "Lista vacía de formas!"},
          { "report-header", "Reporte de Formas"},
          { "total", "Total"},
          { "shapes", "Formas"},
          { "perimeter", "Perimetro"},
          { "area", "Area"},
        }
      },
      { "it", new Dictionary<string, string>
        {
          { "circleshape", "Cerchio" },
          { "circleshape-pluralize", "Cerchi" },
          { "equilateraltriangleshape", "Triangolo" },
          { "equilateraltriangleshape-pluralize", "Triangoli" },
          { "rectangleshape", "Rettangolo" },
          { "rectangleshape-pluralize", "Rettangoli" },
          { "squareshape", "Quadrato" },
          { "squareshape-pluralize", "Quadrati" },
          { "trapezoidshape", "Trapezio" },
          { "trapezoidshape-pluralize", "Trapezi" },
          { "empty-list", "Elenco vuoto di forme!"},
          { "report-header", "Rapporto sulle forme"},
          { "total", "Totale"},
          { "shapes", "Forme"},
          { "perimeter", "Perimetro"},
          { "area", "Area"},
        }
      }
    };

    public static string GetString(string code, string language)
    {
      if (Translations.ContainsKey(language) &&
          Translations[language].ContainsKey(code))
      {
        return Translations[language][code];
      }

      return $"[{code}]";
    }
  }
}
