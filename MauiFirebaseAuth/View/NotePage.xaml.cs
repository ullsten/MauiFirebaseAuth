using Firebase.Database;
using Firebase.Database.Query;
using MauiFirebaseAuth.Data;
using MauiFirebaseAuth.Models;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Xml;

namespace MauiFirebaseAuth.View;

public partial class NotePage : ContentPage
{
    static string firebaseDbUrl = SecretsManager.GetAppSettings().FirebaseDbUrl;

    FirebaseClient firebaseClient = new FirebaseClient(firebaseDbUrl);
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
                    item.Object.Id = item.Key;
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

    private async void Button_SaveNote(Object sender, EventArgs e)
    {
        string title = TitleEntry.Text;
        string description = DescriptionEntry.Text;

        if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description))
        {
            if(string.IsNullOrEmpty(title))
            {
                ValidationLabel.Text = "Title is required";
            }
            else
            {
                ValidationLabel.Text = "Description is required";
            } 
        }
        else
        {
            // Create a new NoteItem without specifying the Id property
            NoteItem newNote = new NoteItem
            {
                NoteDate = DateTime.Now,
                Title = title,
                Description = description,
            };

            // Use PostAsync to add the newNote to the Firebase database
            var response = await firebaseClient.Child("Note").PostAsync(newNote);

            // Store the generated Firebase ID in the Id property
            //newNote.Id = response.Key;

            // Clear the TitleEntry and ValidationLabel as before
            TitleEntry.Text = string.Empty;
            DescriptionEntry.Text = string.Empty;
            ValidationLabel.Text = string.Empty;
        }
    }


    private async void Button_DeleteNote(object sender, EventArgs e)
    {
       var button = (Button)sender;

        if(button.CommandParameter is string id)
        {
            var response = await DisplayAlert("Delete", "Do you want to delete? ", "Yes", "No");

            if (response)
            {
                await firebaseClient.Child("Note").Child(id).DeleteAsync();

                var noteToRemove = NoteItems.FirstOrDefault(x => x.Id == id);
                if(noteToRemove != null)
                {
                    NoteItems.Remove(noteToRemove);
                }
            }
        }
    }
}