using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiFirebaseAuth.ViewModels
{
   
    internal class LoginViewModel
    {
        private readonly INavigation _navigation;
        public Command RegisterBtn { get; }
        public Command LoginBtn { get; }

        public LoginViewModel(INavigation navigation)
        {
            _navigation = navigation;
            RegisterBtn = new Command(RegisterBtnTappedAsync);
            LoginBtn = new Command(LoginBtnTappedAsync);
        }

        private async void LoginBtnTappedAsync(object obj)
        {
            await _navigation.PushAsync(new Dashboard());
        }

        private async void RegisterBtnTappedAsync(object obj)
        {
            await _navigation.PushAsync(new RegisterPage());
        }
    }
}
