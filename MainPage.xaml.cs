using SKAirlines_Project.Views;
using SKAirlines_Project.ViewModels;

namespace SKAirlines_Project
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            await Navigation.PushAsync( new RegisterPage());
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomePage( new HomePageViewModel()));
        }
    }
}
