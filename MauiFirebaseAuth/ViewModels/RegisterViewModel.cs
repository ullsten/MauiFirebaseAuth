using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiFirebaseAuth.ViewModels
{
    internal class RegisterViewModel
    {
        private readonly INavigation _navigation;
        public RegisterViewModel(INavigation navigation)
        {
            _navigation = navigation;
        }
    }
}
