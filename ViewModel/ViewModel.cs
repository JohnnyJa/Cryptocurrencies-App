using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Model;

namespace ViewModel;

public class ViewModel : INotifyPropertyChanged
{
    protected Repository RepositoryInstance { get; } = Repository.GetInstance();
    
    protected ViewModel()
    {
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName]string prop = "")
    {
        if (PropertyChanged != null) 
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }

}