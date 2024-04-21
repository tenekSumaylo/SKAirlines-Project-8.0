using SKAirlines_Project.ViewModels;

namespace SKAirlines_Project.Views;

public partial class RegisterPage : ContentPage
{
	private RegisterViewModel viewModel;
	public RegisterPage()
	{
		InitializeComponent();
		viewModel = new RegisterViewModel("users.json");
		BindingContext = viewModel;
	}
}