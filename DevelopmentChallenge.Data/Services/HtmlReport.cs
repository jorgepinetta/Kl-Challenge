using DevelopmentChallenge.Data.Contracts;
using System.Globalization;
using System.Linq;
using System.Text;

namespace DevelopmentChallenge.Data.Services
{
  public class HtmlReport : IReport<string>
  {
    private static readonly NumberFormatInfo _helpCulture = new NumberFormatInfo
    {
      NumberDecimalSeparator = ",",
      NumberGroupSeparator = "."
    };

    public string Generate(IShape[] shapes, string language)
    {
      var sb = new StringBuilder();

      if (!shapes.Any())
      {
        sb.Append($"<h1>{LanguageService.GetString("empty-list", language)}</h1>");
      }
      else
      {
        sb.Append($"<h1>{LanguageService.GetString("report-header", language)}</h1>");

        var grouped = shapes.GroupBy(
          r => r.GetType().Name,
          (groupType, groupShapes) => new
          {
            TypeName = groupType,
            Count = groupShapes.Count(),
            Area = groupShapes.Sum(s => s.Area),
            Perimeter = groupShapes.Sum(s => s.Perimeter)
          });

        foreach (var shape in grouped)
        {
          sb.Append(GetLine(shape.Count, shape.Area, shape.Perimeter, shape.TypeName, language));
        }

        sb.Append($"{LanguageService.GetString("total", language).ToUpper()}:<br/>");
        sb.Append($"{grouped.Sum(r => r.Count)} {LanguageService.GetString("shapes", language).ToLower()} ");
        sb.Append($"{LanguageService.GetString("perimeter", language)} {(grouped.Sum(r => r.Perimeter)).ToString("#.##", _helpCulture)} ");
        sb.Append($"{LanguageService.GetString("area", language)} {(grouped.Sum(r => r.Area)).ToString("#.##", _helpCulture)}");
      }

      return sb.ToString();
    }

    private static string GetLine(int quantity, decimal area, decimal perimeter, string type, string language)
    {
      return 
        $"{quantity} {GetStringShape(type, quantity > 1, language)} | " 
        + $"{LanguageService.GetString("area", language)} {area.ToString("#.##", _helpCulture)} | "
        + $"{LanguageService.GetString("perimeter", language)} {perimeter.ToString("#.##", _helpCulture)} <br/>";
    }

    private static string GetStringShape(string code, bool pluralize, string language)
    { 
      return LanguageService.GetString(code.ToLower() + (pluralize ? "-pluralize" : string.Empty), language);
    }
  }
}
