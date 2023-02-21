using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Model;
using NewApp.CommandExternal;
using NewApp.Pages;
using NewApp.Services;
using WpfPaging.Events;
using WpfPaging.Messages;
using WpfPaging.Services;

namespace ViewModel;

public class AssetsViewModel : ViewModelBase
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

        
        GetStartData();
        
        ChangePage = AsyncCommand.Create(async () =>
        {
            _pageService.ChangePage(new MarketPage());

            await _messageBus.SendTo<MarketsViewModel>(new AssetMessage(SelectedAsset));
        });
    }

    private string _keyword;
    public string KeyWord
    {
        get => _keyword;
        set
        {
            _keyword = value;
            OnPropertyChanged();
            GetSearchedData();
        }
    }

    private Asset _selectedAsset;

    public Asset SelectedAsset
    {
        get => _selectedAsset;
        set
        {
            _selectedAsset = value;
            OnPropertyChanged();
        }
    }

    private IAsyncCommand _getData;

    public IAsyncCommand GetData
    {
        get => _getData;
        private set
        {
            _getData = value;
            OnPropertyChanged();
        }
    }

    private void GetStartData()
    {
        GetData = AsyncCommand.Create(() =>
            EntryConverter.ToObservableAssetsAsync(_repository.GetTopAssetsAsync(10)));

        GetData.Execute(null);
    }

    private void GetSearchedData()
    {
        GetData = AsyncCommand.Create(() =>
            EntryConverter.ToObservableAssetsAsync(_repository.GetSearchedAssetsAsync(KeyWord)));
        GetData.Execute(null);
    }
    
    public ICommand ChangePage { get; private set; }
}