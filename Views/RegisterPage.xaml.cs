using SKAirlines_Project.ViewModels;

namespace SKAirlines_Project.Views;

public partial class RegisterPage : ContentPage
{
	private RegisterViewModel viewModel;
	public RegisterPage( RegisterViewModel vm )
	{
		InitializeComponent();
		viewModel = vm;
		BindingContext = viewModel;
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		viewModel.RegisterAccount();
		Navigation.PopAsync();
    }
}