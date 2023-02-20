using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using App;
using Model;
using NewApp.Pages;
using NewApp.Services;

namespace ViewModel;

public class MainViewModel
{
    private readonly PageService _pageService;
    
    public Page PageSource { get; set; }
    
    public MainViewModel(PageService pageService)
    {
        _pageService = pageService;


        _pageService.OnPageChanged += (page) => PageSource = page;
        _pageService.ChangePage(new AssetsPage());
    }
}