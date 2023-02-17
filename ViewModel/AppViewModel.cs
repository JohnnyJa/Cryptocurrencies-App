using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Model;

namespace ViewModel;

public class AppViewModel : INotifyPropertyChanged
{
    private readonly Repository _repository;

    
    private ObservableCollection<object> _entitiesToVisualize;

    public ObservableCollection<object> EntitiesToVisualize
    {
        get => _entitiesToVisualize;
        set
        {
            _entitiesToVisualize = value;
            OnPropertyChanged();
        } 
    }
    

    public AppViewModel()
    {
        _repository = Repository.GetInstance();
        GetData();
    }

    private async void GetData()
    {
        var assets = await _repository.GetTopAssetsAsync(10);
        EntitiesToVisualize = new ObservableCollection<object>(assets);
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName]string prop = "")
    {
        if (PropertyChanged != null) 
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }
}