using System.Threading.Tasks;
using System.Windows.Input;
using NewApp.CommandExternal;
using NewApp.Converters;
using NewApp.Messages;
using NewApp.Model;
using NewApp.Pages;
using NewApp.Services;

namespace NewApp.ViewModels;

public class MarketsViewModel : ViewModelBase
{
    private readonly PageService _pageService;
    private readonly EventBus _eventBus;
    private readonly MessageBus _messageBus;
    private readonly RepositoryService _repository;

    private Asset? _chosenAsset;

    public Asset? ChosenAsset
    {
        get => _chosenAsset;
        set
        {
            _chosenAsset = value;
            OnPropertyChanged();
        }
    }
    
    public ICommand ChangePage { get; private set; }

    private IAsyncCommand? _getData;
    public IAsyncCommand? GetData { get=>_getData; private set
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

        
        _messageBus.Receive<AssetMessage>(this, message =>
        {
            ChosenAsset = message.Asset;
            GetData = AsyncCommand.Create(() =>
                EntryConverter.ToObservableMarketsAsync(_repository.GetMarketsByIdAsync(ChosenAsset!.Id)));
        
            GetData.Execute(null);
            return Task.CompletedTask;
        });
        
        ChangePage = AsyncCommand.Create(() =>
        {
            _pageService.ChangePage(new AssetsPage());
            return Task.CompletedTask;
        });
    }
}