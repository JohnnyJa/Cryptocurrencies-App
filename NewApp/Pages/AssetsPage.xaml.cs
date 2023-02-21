using System;
using System.Windows;
using System.Windows.Controls;

namespace NewApp.Pages;

public partial class AssetsPage : Page
{
    public AssetsPage()
    {
        InitializeComponent();
    }

    private void LightThemeMenuItem_OnClick(object sender, RoutedEventArgs e)
    {
        var uri = new Uri("Resources/Themes/LightTheme.xaml", UriKind.Relative);
        ResourceDictionary? resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
        Application.Current.Resources.Clear();
        Application.Current.Resources.MergedDictionaries.Add(resourceDict);
    }

    private void DarkThemeMenuItem_OnClick(object sender, RoutedEventArgs e)
    {
        var uri = new Uri("Resources/Themes/DarkTheme.xaml", UriKind.Relative);
        ResourceDictionary? resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
        Application.Current.Resources.Clear();
        Application.Current.Resources.MergedDictionaries.Add(resourceDict);
    }
}