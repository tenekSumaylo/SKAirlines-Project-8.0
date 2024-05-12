using SKAirlines_Project.ViewModels;

namespace SKAirlines_Project.Views;

public partial class ProfilePage : ContentPage
{
	ProfilePageViewModel vm;
	public ProfilePage()
	{
		InitializeComponent();
		vm = new ProfilePageViewModel();
		BindingContext = vm;
	}
}