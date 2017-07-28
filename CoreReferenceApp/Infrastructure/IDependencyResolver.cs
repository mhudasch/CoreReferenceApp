namespace CoreReferenceApp
{
  public interface IDependencyResolver
  {
    TService Get<TService>();
  }
}
