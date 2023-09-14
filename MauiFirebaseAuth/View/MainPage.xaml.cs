using MauiFirebaseAuth.View;
using MauiFirebaseAuth.ViewModels;

namespace MauiFirebaseAuth
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //BindingContext = new LoginViewModel(Navigation);
        }
        
        private void Button_Login(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }
    }

}
