using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Model;

namespace ViewModel;

public class MainViewModel : ViewModel
{
    public Asset SelectedAsset { get; set; }

    private ObservableCollection<Asset> _assets;
    public ObservableCollection<Asset> Assets
    {
        get => _assets;
        set
        {
            _assets = value;
            OnPropertyChanged();
        } 
    }
    public MainViewModel()
    {
        GetData();
    }

    private async void GetData()
    {
        var assets = await RepositoryInstance.GetTopAssetsAsync(10);
        Assets = new ObservableCollection<Asset>(assets);
    }

    public async void GetSearchedData(string keyword)
    {
        var assets = await RepositoryInstance.GetSearchedAssetsAsync(keyword);
        Assets = new ObservableCollection<Asset>(assets);
    }
    
    
}