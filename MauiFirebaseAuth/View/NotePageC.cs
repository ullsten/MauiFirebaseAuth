using CommunityToolkit.Maui.Markup;

namespace MauiFirebaseAuth.View;

public class NotePageC : ContentPage
{
	public NotePageC()
	{
		Content = new VerticalStackLayout
		{
			VerticalOptions = LayoutOptions.Center,HorizontalOptions = LayoutOptions.Center,
			Children = {
				new ImageButton { 
					Command = new Command(
						execute: async()=>
						{
							await App.Current.MainPage.DisplayAlert("Alert", "Alert for you man", "Ok");
						})
				}
                .Source("dotnet_bot.svg")
                .CenterVertical()
                .CenterHorizontal()
                .Height(140)
            }
		};
	}
}