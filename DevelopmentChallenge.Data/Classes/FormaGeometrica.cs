﻿/******************************************************************************************************************/
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
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace DevelopmentChallenge.Data.Classes
{
  [Obsolete("DEPRECATED: Use Shape service", false)]
  public class FormaGeometrica
  {
    #region Formas

    public const int Cuadrado = 1;
    public const int TrianguloEquilatero = 2;
    public const int Circulo = 3;
    public const int Trapecio = 4;

    #endregion

    #region Idiomas

    public const int Castellano = 1;
    public const int Ingles = 2;

    #endregion

    private readonly decimal _lado;

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
      var sb = new StringBuilder();

      if (!formas.Any())
      {
        if (idioma == Castellano)
          sb.Append("<h1>Lista vacía de formas!</h1>");
        else
          sb.Append("<h1>Empty list of shapes!</h1>");
      }
      else
      {
        // Hay por lo menos una forma
        // HEADER
        if (idioma == Castellano)
          sb.Append("<h1>Reporte de Formas</h1>");
        else
          // default es inglés
          sb.Append("<h1>Shapes report</h1>");

        var numeroCuadrados = 0;
        var numeroCirculos = 0;
        var numeroTriangulos = 0;

        var areaCuadrados = 0m;
        var areaCirculos = 0m;
        var areaTriangulos = 0m;

        var perimetroCuadrados = 0m;
        var perimetroCirculos = 0m;
        var perimetroTriangulos = 0m;

        for (var i = 0; i < formas.Count; i++)
        {
          if (formas[i].Tipo == Cuadrado)
          {
            numeroCuadrados++;
            areaCuadrados += formas[i].CalcularArea();
            perimetroCuadrados += formas[i].CalcularPerimetro();
          }
          if (formas[i].Tipo == Circulo)
          {
            numeroCirculos++;
            areaCirculos += formas[i].CalcularArea();
            perimetroCirculos += formas[i].CalcularPerimetro();
          }
          if (formas[i].Tipo == TrianguloEquilatero)
          {
            numeroTriangulos++;
            areaTriangulos += formas[i].CalcularArea();
            perimetroTriangulos += formas[i].CalcularPerimetro();
          }
        }

        sb.Append(ObtenerLinea(numeroCuadrados, areaCuadrados, perimetroCuadrados, Cuadrado, idioma));
        sb.Append(ObtenerLinea(numeroCirculos, areaCirculos, perimetroCirculos, Circulo, idioma));
        sb.Append(ObtenerLinea(numeroTriangulos, areaTriangulos, perimetroTriangulos, TrianguloEquilatero, idioma));

        // FOOTER
        sb.Append("TOTAL:<br/>");
        sb.Append(numeroCuadrados + numeroCirculos + numeroTriangulos + " " + (idioma == Castellano ? "formas" : "shapes") + " ");
        sb.Append((idioma == Castellano ? "Perimetro " : "Perimeter ") + (perimetroCuadrados + perimetroTriangulos + perimetroCirculos).ToString("#.##", _helpCulture) + " ");


        sb.Append("Area " + (areaCuadrados + areaCirculos + areaTriangulos).ToString("#.##", _helpCulture));
      }

      return sb.ToString();
    }

    private static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, int tipo, int idioma)
    {
      if (cantidad > 0)
      {
        if (idioma == Castellano)
          return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Area {area.ToString("#.##", _helpCulture)} | Perimetro {perimetro.ToString("#.##", _helpCulture)} <br/>";

        return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Area {area.ToString("#.##", _helpCulture)} | Perimeter {perimetro.ToString("#.##", _helpCulture)} <br/>";
      }

      return string.Empty;
    }

    private static string TraducirForma(int tipo, int cantidad, int idioma)
    {
      switch (tipo)
      {
        case Cuadrado:
          if (idioma == Castellano) return cantidad == 1 ? "Cuadrado" : "Cuadrados";
          else return cantidad == 1 ? "Square" : "Squares";
        case Circulo:
          if (idioma == Castellano) return cantidad == 1 ? "Círculo" : "Círculos";
          else return cantidad == 1 ? "Circle" : "Circles";
        case TrianguloEquilatero:
          if (idioma == Castellano) return cantidad == 1 ? "Triángulo" : "Triángulos";
          else return cantidad == 1 ? "Triangle" : "Triangles";
      }

      return string.Empty;
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