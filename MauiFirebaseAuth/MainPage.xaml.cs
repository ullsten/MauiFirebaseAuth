using MauiFirebaseAuth.ViewModels;

namespace MauiFirebaseAuth
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel(Navigation);
        }
    }

}
