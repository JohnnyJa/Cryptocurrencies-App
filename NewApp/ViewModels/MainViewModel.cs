using System.Diagnostics;
using System.Windows.Controls;
using NewApp.Pages;
using NewApp.Services;

namespace NewApp.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly PageService _pageService;

    private Page? _pageSource;

    public Page? PageSource
    {
        get => _pageSource;
        set
        {
            _pageSource = value;
            OnPropertyChanged();
        }
    }

    public MainViewModel(PageService pageService)
    {
        _pageService = pageService;


        _pageService.OnPageChanged += (page) =>
        {
            PageSource = page;
            Debug.WriteLine("123");
        };
        _pageService.ChangePage(new AssetsPage());
    }
}