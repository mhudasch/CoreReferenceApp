using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Ninject;
using System;

namespace CoreReferenceApp
{
  public static class KernelExtensions
  {
    public static IKernel SupportOptions(this IKernel kernel)
    {
      kernel.Bind(typeof(IOptions<>)).To(typeof(OptionsManager<>)).InSingletonScope();
      kernel.Bind(typeof(IOptionsMonitor<>)).To(typeof(OptionsMonitor<>)).InSingletonScope();
      kernel.Bind(typeof(IOptionsSnapshot<>)).To(typeof(OptionsSnapshot<>)).InSingletonScope(); // scoped
      kernel.Bind(typeof(IOptionsCache<>)).To(typeof(OptionsCache<>)).InSingletonScope();
      kernel.Bind(typeof(IOptionsFactory<>)).To(typeof(OptionsFactory<>)).InTransientScope();
      return kernel;
    }

    public static IKernel Configure<TOptions>(this IKernel kernel, string name, Action<TOptions> configureOptions) where TOptions : class
    {
      kernel.Bind<IConfigureOptions<TOptions>>().ToConstant(new ConfigureNamedOptions<TOptions>(name, configureOptions)).InSingletonScope();
      return kernel;
    }

   
    public static IKernel Configure<TOptions>(this IKernel kernel, Action<TOptions> configureOptions) where TOptions : class
    {
      return kernel.Configure(Options.DefaultName, configureOptions);
    }

    public static IKernel Configure<TOptions>(this IKernel kernel, IConfigurationSection section) where TOptions : class
    {
      return kernel.Configure<TOptions>(option => section.Bind(option));
    }
  }
}
