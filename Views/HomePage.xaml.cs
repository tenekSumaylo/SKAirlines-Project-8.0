using System.Collections.ObjectModel;
using SKAirlines_Project.ViewModels;
namespace SKAirlines_Project.Views;

public partial class HomePage : ContentPage
{
	public HomePage( HomePageViewModel vm )
	{
		InitializeComponent();
		BindingContext = vm;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync( new BookingPage() );
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new BookingPage());
    }

    private async void ImageButton_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new BookingPage());
    }

    private async void ImageButton_Clicked_2(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new BookingPage());
    }
}