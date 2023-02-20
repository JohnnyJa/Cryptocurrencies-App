using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Model;

public class Asset:INotifyPropertyChanged
{
    public string Id { get; set; }
    public string Rank { get; set; }
    public string Symbol { get; set; }
    public string Name { get; set; }
    public string Volume { get; set; }
    public string Price { get; set; }
    public string ChangePercent{ get; set; }
    
    
    
    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName]string prop = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }
}