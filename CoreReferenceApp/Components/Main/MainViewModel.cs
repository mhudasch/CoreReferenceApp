using System.ComponentModel;
using Microsoft.Extensions.Options;
using System.Runtime.CompilerServices;

namespace CoreReferenceApp
{
  public class MainWindowViewModel : IMainWindowViewModel
  {
    private readonly MainWindowOptions options;

    public MainWindowViewModel(IOptions<MainWindowOptions> options)
    {
      this.options = options.Value;
    }

    public int Height
    {
      get { return this.options.Height; }
      set
      {
        if(value != this.options.Height)
        {
          this.options.Height = value;
          this.NotifyPropertyChanged();
        }
      }
    }

    public int Width
    {
      get { return this.options.Width; }
      set
      {
        if (value != this.options.Width)
        {
          this.options.Width = value;
          this.NotifyPropertyChanged();
        }
      }
    }

    public int Top
    {
      get { return this.options.Top; }
      set
      {
        if (value != this.options.Top)
        {
          this.options.Top = value;
          this.NotifyPropertyChanged();
        }
      }
    }

    public int Left
    {
      get { return this.options.Left; }
      set
      {
        if (value != this.options.Left)
        {
          this.options.Left = value;
          this.NotifyPropertyChanged();
        }
      }
    }

    public string Title
    {
      get { return this.options.Title; }
      set
      {
        if (value != this.options.Title)
        {
          this.options.Title = value;
          this.NotifyPropertyChanged();
        }
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void NotifyPropertyChanged([CallerMemberName]string property = null)
    {
      this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }
  }
}
