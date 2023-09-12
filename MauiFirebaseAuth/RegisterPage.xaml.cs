﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using Xamarin.Forms;
//using Xamarin.Forms.Xaml;

namespace MauiFirebaseAuth
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public Command RegisterUser { get; }
        public RegisterPage()
        {
            InitializeComponent();
            BindingContext = new RegisterViewModel(Navigation);
            RegisterUser = new Command(RegisterUserTappedAsync);
        }

        private void RegisterUserTappedAsync(object obj)
        {
            throw new NotImplementedException();
        }
    }
}