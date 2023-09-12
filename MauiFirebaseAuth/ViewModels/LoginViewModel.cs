using Firebase.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.Configuration;
using MauiFirebaseAuth.Data;

namespace MauiFirebaseAuth.ViewModels
{
   
    internal class LoginViewModel : INotifyPropertyChanged
    {
        private readonly INavigation _navigation;
        private string userName;
        private string userPassword;

        public event PropertyChangedEventHandler PropertyChanged;

        public Command RegisterBtn { get; }
        public Command LoginBtn { get; }

        public string UserName 
        { 
           get => userName;
            set
            {
                userName = value;
                RaisePropertyChanged(UserName);
            }
        }
        public string UserPassword 
        { 
           get => userPassword;
            set
            {
                userPassword = value;
                RaisePropertyChanged(UserPassword);
            }
        }
        public LoginViewModel(INavigation navigation )
        {
            _navigation = navigation;
            RegisterBtn = new Command(RegisterBtnTappedAsync);
            LoginBtn = new Command(LoginBtnTappedAsync);
        }


        private async void LoginBtnTappedAsync(object obj)
        {
            string webApiKey = SecretsManager.GetWebApiKey();

            var authProvder = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
            try
            {
                var auth = await authProvder.SignInWithEmailAndPasswordAsync(UserName, UserPassword);
                var content = await auth.GetFreshAuthAsync();
                var serializedContent = JsonConvert.SerializeObject(content);
                Preferences.Set("FreshFirebaseToken", serializedContent);
                await _navigation.PushAsync(new Dashboard());
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "Ok");
            }
            //await _navigation.PushAsync(new Dashboard());
        }

        private async void RegisterBtnTappedAsync(object obj)
        {
            await _navigation.PushAsync(new RegisterPage());
        }
        private void RaisePropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }
    }
}
