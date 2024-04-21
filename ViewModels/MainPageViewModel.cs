using SKAirlines_Project.Models;
using SKAirlines_Project.Services;
using SKAirlines_Project.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                        await Shell.Current.GoToAsync(nameof(HomePage));
                    }
                }
                if (detect == 0)
                {
                    await Shell.Current.DisplayAlert("Failed", "Wrong Credentials", "Confirm");
                }
            }
        }
    }
}
