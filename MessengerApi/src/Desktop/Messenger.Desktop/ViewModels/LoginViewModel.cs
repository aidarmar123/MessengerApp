using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Messenger.Desktop.Services;

namespace Messenger.Desktop.ViewModels;

public partial class LoginViewModel:BaseViewModel
{
    [ObservableProperty]
    private string _alice;

    public LoginViewModel()
    {
        _alice = "";
    }

    [RelayCommand]
    private void Login()
    {
        
    }
}
