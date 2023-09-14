using Firebase.Database;
using Firebase.Database.Query;
using MauiFirebaseAuth.Models;
using System.Collections.ObjectModel;
using System.Reactive.Linq;

namespace MauiFirebaseAuth.View;

public partial class NotePage : ContentPage
{
    FirebaseClient firebaseClient = new FirebaseClient("https://mauitestproject-b5590-default-rtdb.europe-west1.firebasedatabase.app/");
    public ObservableCollection<NoteItem> NoteItems { get; set; } = new ObservableCollection<NoteItem>();

    public NotePage()
	{
		InitializeComponent();

        BindingContext = this;

        var collection = firebaseClient
            .Child("Note")
            .AsObservable<NoteItem>()
            .Subscribe((item) =>
            {
                if (item.Object != null)
                {
                    NoteItems.Add(item.Object);
                }
                
            });
    }

	private void Button_Dashboard(object sender, EventArgs e)
	{
		Navigation.PushAsync(new Dashboard());
	}
    //private async void Button_Save(object sender, EventArgs e)
    //{
    //    bool result = await App.Current.MainPage.DisplayAlert("Confirmation", "Do you want to save this note?", "Yes", "No");

    //    if (result)
    //    {
    //        // User clicked "Yes," perform the save action
    //        // You can add your save logic here
    //        await App.Current.MainPage.DisplayAlert("Success", "Note saved successfully", "Ok");
    //    }
    //    else
    //    {
    //        // User clicked "No," do nothing or handle accordingly
    //    }
    //}
    
    private void Button_SaveNote(object sender, EventArgs e)
    {
        firebaseClient.Child("Note").PostAsync(new NoteItem
        {
            Title = TitleEntry.Text,
        });

        TitleEntry.Text = string.Empty;
    }
}