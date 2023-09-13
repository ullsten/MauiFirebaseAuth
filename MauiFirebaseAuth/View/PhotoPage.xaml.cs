using MauiFirebaseAuth.View;

namespace MauiFirebaseAuth;

public partial class PhotoPage : ContentPage
{
	public PhotoPage()
	{
		InitializeComponent();
	}
	private void Button_Clicked(object sender, EventArgs e)
	{
		Navigation.PushAsync(new Dashboard());
	}
	private void Button_Clicked_1(object sender, EventArgs e)
	{
		Navigation.PushAsync(new UploadPhoto());
	}
}