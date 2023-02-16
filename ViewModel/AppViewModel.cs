using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Model;

namespace ViewModel;

public class AppViewModel : INotifyPropertyChanged
{
    private Repository _repository = new Repository();
    private ObservableCollection<Asset> datas;
    public ObservableCollection<Asset> Datas
    {
        get { return datas; }
        set
        {
            datas = value;
            OnPropertyChanged("Datas");
        } }
    

    public AppViewModel()
    {
        GetData();
    }

    public async void GetData()
    {
        var assets = await _repository.GetTopAssetsAsync();
        Datas = new ObservableCollection<Asset>(assets.Data);
    }
    
    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName]string prop = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }
}