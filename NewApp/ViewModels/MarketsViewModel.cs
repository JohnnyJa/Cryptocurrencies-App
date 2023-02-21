using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Model;
using NewApp.CommandExternal;
using NewApp.Services;
using WpfPaging.Events;
using WpfPaging.Messages;
using WpfPaging.Services;

namespace ViewModel;

public class MarketsViewModel : ViewModelBase
{
    private readonly PageService _pageService;
    private readonly EventBus _eventBus;
    private readonly MessageBus _messageBus;
    private readonly RepositoryService _repository;

    private Asset _chosenAsset;

    public Asset ChosenAsset
    {
        get => _chosenAsset;
        set
        {
            _chosenAsset = value;
            OnPropertyChanged();
        }
    }

    private IAsyncCommand _getData;
    public IAsyncCommand GetData { get=>_getData; private set
    {
        _getData = value;
        OnPropertyChanged();
    } }

    public MarketsViewModel(PageService pageService, EventBus eventBus, MessageBus messageBus, RepositoryService repository)
    {
        _pageService = pageService;
        _eventBus = eventBus;
        _messageBus = messageBus;
        _repository = repository;

        
        _messageBus.Receive<AssetMessage>(this, async message =>
        {
            ChosenAsset = message.Asset;
            GetData = AsyncCommand.Create(() =>
                EntryConverter.ToObservableMarketsAsync(_repository.GetMarketsByIdAsync(ChosenAsset.Id)));
        
            GetData.Execute(null);
        });
        
        
    }
}