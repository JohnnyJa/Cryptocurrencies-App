using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Model;

namespace ViewModel;

public class MainViewModel : ViewModel
{
    public Asset SelectedAsset { get; set; }

    public string Keyword
    {
        set => GetSearchedData(value);
    }

    private NotifyTaskCompletion<ObservableCollection<Asset>> _assets;

    public NotifyTaskCompletion<ObservableCollection<Asset>> Assets
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

    private void GetData()
    {
        Assets = new NotifyTaskCompletion<ObservableCollection<Asset>>(RepositoryInstance.GetTopAssetsAsync(10));
    }

    public void GetSearchedData(string keyword)
    {
        Assets = new NotifyTaskCompletion<ObservableCollection<Asset>>(RepositoryInstance.GetSearchedAssetsAsync(keyword));
    }

    public DetailedViewModel GetDetailedWindowInfo()
    {
        return new DetailedViewModel(SelectedAsset);
    }
}