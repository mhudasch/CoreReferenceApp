using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace CoreReferenceApp
{
  public static class Configuration
  {
    public static IConfiguration Current { get; set; }

    internal static void BuildConfiguration(string[] args)
    {
      var manualConfugration = new Dictionary<string, string>
            {
                {"Profile:MachineName", "Rick"},
                {"App:MainWindow:Width", "800"},
                {"App:MainWindow:Height", "600"},
                {"App:MainWindow:Top", "11"},
                {"App:MainWindow:Left", "11"}
            };

      var builder = new ConfigurationBuilder()
        .AddInMemoryCollection(manualConfugration)
        .AddCommandLine(args, manualConfugration.MapArguments())
        .AddEnvironmentVariables()
        .SetBasePath(Environment.CurrentDirectory)
        .AddJsonFile("extraSettings.json", optional: false, reloadOnChange: true);

      Current = builder.Build();
    }
  }
}
