using SKAirlines_Project.Models;
using SKAirlines_Project.Services;
using SKAirlines_Project.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SKAirlines_Project.ViewModels
{
    public class MainPageViewModel
    {
        private UserService userServicer;
        public string Username { get; set; }
        public string Password { get; set; }    
        public MainPageViewModel() { }

        public MainPageViewModel(string name) 
        {
            this.userServicer = new UserService(name);
  
        }

        public ICommand LoginCommand => new Command(AccountVerification);
        public ICommand TapCommand => new Command(NavigateToRegisterPage);
        private async void AccountVerification()
        {
            UserService userServicer = new UserService("users.json");
            int detect = 0;

            ObservableCollection<UserDomain> theUsers = await userServicer.GetUsers();

            if (Username == "admin" && Password == "123")
            {
                await Shell.Current.GoToAsync(nameof(AdminPage));
            }
            else
            {
                foreach (var userData in theUsers)
                {
                    if (userData.UserID == Username && userData.Password == Password)
                    {
                        detect = 1;
                        var theDictionary = new Dictionary<string, object>
                        {
                            { "TheUser", userData },
                        };
                        await Shell.Current.GoToAsync($"{nameof(HomePage)}", theDictionary);
                    }
                }
                if (detect == 0)
                {
                    await Shell.Current.DisplayAlert("Failed", "Wrong Credentials", "Confirm");
                }
            }
        }

        private async void NavigateToRegisterPage()
        {
            await Shell.Current.GoToAsync(nameof(RegisterPage));
        }
    }
}
