using MauiFirebaseAuth.View;
using MauiFirebaseAuth.ViewModels;

namespace MauiFirebaseAuth
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        
        private void Button_Login(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }

        private async void Button_Note(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NotePage()); 
        }
    }

}
