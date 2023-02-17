using System;
using System.Windows;
using Model;
using ViewModel;

namespace Test;

public partial class DetailedWindow : Window
{
    public DetailedWindow(Asset selectedAsset)
    {
        InitializeComponent();
        DataContext = new DetailedViewModel(selectedAsset);
        Console.WriteLine("12");
    }
}