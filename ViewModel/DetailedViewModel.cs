using System.Collections.ObjectModel;
using Model;

namespace ViewModel;

public class DetailedViewModel : ViewModel
{
    public Asset SelectedAsset { get; set; }

    private ObservableCollection<Market> _marketsOfAsset;
    public ObservableCollection<Market> Markets { get => _marketsOfAsset;
        set
        {
            _marketsOfAsset = value;
            OnPropertyChanged();
        } }

    public DetailedViewModel(Asset selectedAsset)
    {
        SelectedAsset = selectedAsset;
    }
}