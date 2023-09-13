namespace MauiFirebaseAuth.View;

public partial class NotePage : ContentPage
{
	public NotePage()
	{
		InitializeComponent();
	}

	private void Button_Dashboard(object sender, EventArgs e)
	{
		Navigation.PushAsync(new Dashboard());
	}
	private async void Button_Save(object sender, EventArgs e)
	{
		await App.Current.MainPage.DisplayAlert("Alert", "Note saved successfully", "Ok");
	}
}