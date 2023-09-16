using Firebase.Auth;
using MauiFirebaseAuth.View;
using MauiFirebaseAuth.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiFirebaseAuth
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage
    {
        private readonly INavigation _navigation;
        public Dashboard()
        {
            InitializeComponent();
            GetProfileInfo();
            BindingContext = new LoginViewModel(Navigation);
        }

        private void GetProfileInfo()
        {
            var userInfo = JsonConvert.DeserializeObject<Firebase.Auth.FirebaseAuth>(Preferences.Get("FreshFirebaseToken", ""));
            UserEmail.Text = userInfo.User.Email;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PhotoPage()); 
        }
        private void Button_Note(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NotePage());
        }

        private async void Button_Logout(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Login");
            
        }
    }
}