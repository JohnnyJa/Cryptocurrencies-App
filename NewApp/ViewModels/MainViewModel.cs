using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using App;
using Model;
using NewApp.Pages;
using NewApp.Services;

namespace ViewModel;

public class MainViewModel : ViewModelBase
{
    private readonly PageService _pageService;

    private Page _pageSource;

    public Page PageSource
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