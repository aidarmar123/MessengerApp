using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using Messenger.Desktop.Views;

namespace Messenger.Desktop.ViewModels;

public partial class MainViewModel:BaseViewModel
{
    [ObservableProperty]
    private UserControl _content;

    public MainViewModel()
    {
        _content = new LoginView()
        {
            DataContext = new LoginViewModel()
        };
    }
    
}
