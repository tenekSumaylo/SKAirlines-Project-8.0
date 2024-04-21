using System.Collections.ObjectModel;
using SKAirlines_Project.Models;
using SKAirlines_Project.Services;
using SKAirlines_Project.ViewModels;
namespace SKAirlines_Project.Views;

public partial class HomePage : ContentPage
{
	HomePageViewModel vm;
	public HomePage()
	{
		InitializeComponent();
        vm = new HomePageViewModel();
		BindingContext = vm;
    }

}