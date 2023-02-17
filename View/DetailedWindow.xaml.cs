using System.Windows;

namespace Test;

public partial class DetailedWindow : Window
{
    public DetailedWindow(Window owner)
    {
        Owner = owner;
        InitializeComponent();
    }
}