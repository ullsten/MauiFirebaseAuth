using MauiFirebaseAuth.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using Xamarin.Forms;
//using Xamarin.Forms.Xaml;

namespace MauiFirebaseAuth
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage
    {
        public Dashboard()
        {
            InitializeComponent();
            GetProfileInfo();
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
    }
}