using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using App;
using Microsoft.Xaml.Behaviors.Core;
using Model;
using NewApp.CommandExternal;
using NewApp.Pages;
using NewApp.Services;
using WpfPaging.Events;
using WpfPaging.Messages;
using WpfPaging.Services;

namespace ViewModel;

public class AssetsViewModel : INotifyPropertyChanged
{
    private readonly PageService _pageService;
    private readonly EventBus _eventBus;
    private readonly MessageBus _messageBus;
    private readonly RepositoryService _repository;

    public AssetsViewModel(PageService pageService, EventBus eventBus, MessageBus messageBus,
        RepositoryService repository)
    {
        _pageService = pageService;
        _eventBus = eventBus;
        _messageBus = messageBus;
        _repository = repository;

        GetData = AsyncCommand.Create(() =>
             EntryConverter.ToObservableAssetsAsync(_repository.GetTopAssetsAsync(10)));

        GetData.Execute(null);
        
        ChangePage = AsyncCommand.Create(async () =>
        {
            _pageService.ChangePage(new MarketPage());

            await  _messageBus.SendTo<MarketsViewModel>(new AssetMessage(SelectedAsset));
        });
        
        // Assets = new NotifyTaskCompletion<ObservableCollection<Asset>>(
        //     EntryConverter.ToObservableAssetsAsync(repository.GetTopAssetsAsync(10)));
    }

    public Asset SelectedAsset
    {
        get;
        set;
    }

    public IAsyncCommand GetData { get; private set; }

    public ICommand ChangePage { get; private set; }
    

    public event PropertyChangedEventHandler PropertyChanged;
}