﻿
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiFirebaseAuth.ViewModels
{
    internal class RegisterViewModel : INotifyPropertyChanged
    {
        private readonly string webApiKey = "AIzaSyB9iXKXm0VzRAhjzPQDPqF4-1Mka007A7s";

        private INavigation _navigation;
        private string email;
        private string password;

        public Command RegisterUser { get; }

        public event PropertyChangedEventHandler PropertyChanged;
        public string Email
        {
            get => email;
            set
            {
                email = value;
                RaisePropertyChanged("Email");
            }
        }
        public string Password
        {
            get => password;
            set
            {
                password = value;
                RaisePropertyChanged("Password");
            }
        }

        private void RaisePropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        public RegisterViewModel(INavigation navigation)
        {
            _navigation = navigation;
            RegisterUser = new Command(RegisterUserTappedAsync);
        }

        private async void RegisterUserTappedAsync(object obj)
        {
            try
            {
                //var testEmail = Email;
                //var testPassword = Password;
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(Email, Password);
                string token = auth.FirebaseToken;
                if(token != null)
                {
                    await App.Current.MainPage.DisplayAlert("Alert", "User Registered sucessfully", "Ok");
                    await _navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "Ok");
            }
        }
    }
}
