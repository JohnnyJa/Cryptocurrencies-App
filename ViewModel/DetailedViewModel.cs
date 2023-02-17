using System.Collections.ObjectModel;
using Model;

namespace ViewModel;

public class DetailedViewModel : ViewModel
{
    public Asset SelectedAsset { get; set; }

    private ObservableCollection<Market> _markets;
    public ObservableCollection<Market> Markets { get => _markets;
        set
        {
            _markets = value;
            OnPropertyChanged();
        } }

    public DetailedViewModel(Asset selectedAsset)
    {
        SelectedAsset = selectedAsset;
        GetMarkets(SelectedAsset.Id);
    }

    private async void GetMarkets(string Id)
    {
        var markets = await RepositoryInstance.GetMarketsByIdAsync(Id);
        Markets = new ObservableCollection<Market>(markets);
    }
}