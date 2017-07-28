using Microsoft.Extensions.Configuration;
using Ninject;

namespace CoreReferenceApp
{
  public static class DependencyResolver
  {
    public static IDependencyResolver Current { get; set; }

    public static void BuildDependencyRespolver(IConfiguration configuration)
    {
      var kernel = new StandardKernel();
      kernel.Bind<IConfiguration>().ToConstant(configuration);
      kernel.Bind<IMainWindowViewModel>().To<MainWindowViewModel>();

      // configurations
      kernel.SupportOptions();
      kernel.Configure<MainWindowOptions>(Configuration.Current.GetSection("App:MainWindow"));

      Current = new DefaultDependencyResolver(kernel);
    }
  }
}
