using MauiFirebaseAuth.ViewModels;

namespace MauiFirebaseAuth.View;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
        BindingContext = new LoginViewModel(Navigation);
    }
}