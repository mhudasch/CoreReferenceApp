using System;

namespace CoreReferenceApp
{
  public class Program
  {
    [STAThread]
    public static void Main(string[] args)
    {
      Configuration.BuildConfiguration(args);
      DependencyResolver.BuildDependencyRespolver(Configuration.Current);
      var app = DependencyResolver.Current.Get<App>();
      var mainWindow = DependencyResolver.Current.Get<MainWindow>();
      mainWindow.DataContext = DependencyResolver.Current.Get<IMainWindowViewModel>();
      app.Run(mainWindow);
    }
  }
}
