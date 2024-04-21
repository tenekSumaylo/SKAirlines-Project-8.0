using SKAirlines_Project.Views;
using SKAirlines_Project.ViewModels;
using SKAirlines_Project.Services;
using System.Collections.ObjectModel;
using SKAirlines_Project.Models;

namespace SKAirlines_Project
{
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel viewModel;
        public string Username {  get; set; }
        public string Password { get; set; }    

        public MainPage()
        {
            InitializeComponent();
            viewModel = new MainPageViewModel();
            BindingContext = viewModel;
        }
    }
}
