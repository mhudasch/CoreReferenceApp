namespace CoreReferenceApp
{
  using System.Collections.Generic;
  using System.Data;
  using System.Linq;

  static class SwitchMapExtension
  {
    public static Dictionary<string, string> MapArguments(this IReadOnlyDictionary<string, string> configurationStrings)
    {
      return configurationStrings.Select(item =>
          new KeyValuePair<string, string>("-" + item.Key.Substring(item.Key.LastIndexOf(':') + 1), item.Key))
          .ToDictionary(item => item.Key, item => item.Value);
    }
  }
}