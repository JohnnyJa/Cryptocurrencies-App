using System.Collections.ObjectModel;
using Model;

namespace ViewModel;

public class DetailedViewModel : ViewModel
{
    public Asset SelectedAsset { get; set; }
    
    private NotifyTaskCompletion<ObservableCollection<Market>> _markets;

    public NotifyTaskCompletion<ObservableCollection<Market>> Markets
    {
        get => _markets;
        set
        {
            _markets = value;
            OnPropertyChanged();
        }
    }

    public DetailedViewModel(Asset selectedAsset)
    {
        SelectedAsset = selectedAsset;
        GetMarkets();
    }

    private void GetMarkets()
    {
        Markets = new NotifyTaskCompletion<ObservableCollection<Market>>(RepositoryInstance.GetMarketsByIdAsync(SelectedAsset.Id));
    }
}