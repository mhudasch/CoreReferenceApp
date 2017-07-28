using Ninject;

namespace CoreReferenceApp
{
  public class DefaultDependencyResolver : IDependencyResolver
  {
    private IKernel kernel;

    public DefaultDependencyResolver(IKernel configuredKernel)
    {
      this.kernel = configuredKernel;
    }

    public TService Get<TService>() => this.kernel.Get<TService>();
  }
}
