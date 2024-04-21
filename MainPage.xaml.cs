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
            BindingContext = this;
        }

        private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            await Navigation.PushAsync( new RegisterPage( new RegisterViewModel("users.json")));
        }


        private async void Button_Clicked(object sender, EventArgs e)
        {
            UserService userServicer = new UserService("users.json");
            int detect = 0;

            ObservableCollection<UserDomain> theUsers = await userServicer.GetUsers();

            if (Username == "admin" && Password == "123")
            {
                await Navigation.PushAsync(new AdminPage());
            }
            else
            {
                foreach (var userData in theUsers)
                {
                    if (userData.UserID == Username && userData.Password == Password)
                    {
                        detect = 1;
                        await Navigation.PushAsync(new HomePage(new HomePageViewModel()));
                    }
                }
                if (detect == 0)
                {
                    await DisplayAlert("Failed", "Wrong Credentials", "Confirm");
                }
            }
        }

    }
}
