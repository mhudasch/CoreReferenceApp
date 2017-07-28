using System.ComponentModel;

namespace CoreReferenceApp
{
  public interface IMainWindowViewModel : INotifyPropertyChanged
  {
    int Height { get; }

    int Width { get; }

    int Top { get; }

    int Left { get; }
  }
}