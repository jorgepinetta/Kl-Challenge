namespace DevelopmentChallenge.Data.Contracts
{
  public interface IReport<T>
  {
    T Generate(IShape[] shapes, string lang);
  }
}
