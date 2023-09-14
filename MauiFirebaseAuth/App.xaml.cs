using MauiFirebaseAuth.View;

namespace MauiFirebaseAuth
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage (new MainPage());
        }

    }
}
