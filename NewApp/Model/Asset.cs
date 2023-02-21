using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NewApp.Model;

public class Asset:INotifyPropertyChanged
{
    public string? Id { get; init; }
    public string? Rank { get; set; }
    public string? Symbol { get; set; }
    public string? Name { get; init; }
    public string? Volume { get; init; }
    public string? Price { get; init; }
    public string? ChangePercent{ get; init; }
    
    
    
    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName]string prop = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}