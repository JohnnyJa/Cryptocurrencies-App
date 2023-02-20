using System.Diagnostics.Eventing.Reader;
using System.Threading.Tasks;
using Model;
using NewApp.CommandExternal;
using NewApp.Services;
using WpfPaging.Messages;
using WpfPaging.Services;

namespace ViewModel;

public class MarketsViewModel
{
    private readonly PageService _pageService;
    private readonly EventBus _eventBus;
    private readonly MessageBus _messageBus;
    private readonly RepositoryService _repository;

    public Asset ChosenAsset { get; set; } = new();
    
    public IAsyncCommand GetData { get; private set; }

    public MarketsViewModel(PageService pageService, EventBus eventBus, MessageBus messageBus, RepositoryService repository)
    {
        _pageService = pageService;
        _eventBus = eventBus;
        _messageBus = messageBus;
        _repository = repository;

        _messageBus.Receive<AssetMessage>(new object(), message => Task.FromResult(ChosenAsset = message.Asset));
        
        GetData = AsyncCommand.Create(() =>
            EntryConverter.ToObservableMarketsAsync(_repository.GetMarketsByIdAsync(ChosenAsset.Id)));
        
        GetData.Execute(null);
    }
    
    
}