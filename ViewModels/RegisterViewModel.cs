using SKAirlines_Project.Models;
using SKAirlines_Project.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SKAirlines_Project.ViewModels
{
    public class RegisterViewModel :BaseViewModel
    {
        public UserDomain ThePerson { get; set; }
        public string confirmPassword { get; set; }
        UserService userServicer;
        public RegisterViewModel() 
        {
            ThePerson = new UserDomain();
        }

        public RegisterViewModel( string name )
        {
            userServicer = new UserService(name);
            ThePerson = new UserDomain();
            ThePerson.BirthDate = DateTime.Now;
        }

        public ICommand RegisterCommand => new Command( RegisterAccount );

        public async void RegisterAccount()
        {
            if ( ValidateUser() )
            {
                ObservableCollection<UserDomain> theUsers = await userServicer.GetUsers();
                ThePerson.AgeStage = ThePerson.BirthDate.Year >= 2008 ? 1 : ThePerson.BirthDate.Year >= DateTime.Now.Year ? 2 : 3;
                ThePerson.Title = ThePerson.AgeStage == 1 ? "Adult" : ThePerson.AgeStage == 2 ? "Child" : "Infant";
                theUsers.Add(ThePerson);
                userServicer.SaveToFile( theUsers );
            }
            else
            {
                await Shell.Current.DisplayAlert("Cannot Proceed", "Fill-out all forms", "Close");
            }
        }

        private bool ValidateUser()
        {
            if ( string.IsNullOrEmpty(ThePerson.Password) || string.IsNullOrEmpty(ThePerson.UserID) || string.IsNullOrEmpty(ThePerson.FirstName) || string.IsNullOrEmpty(ThePerson.LastName) || string.IsNullOrEmpty(ThePerson.PhoneNumber) || string.IsNullOrEmpty(ThePerson.EmailAddress)  || !EmailCheck( ThePerson.EmailAddress ))
            {
                return false;
            }
            else if ( ThePerson.Password != confirmPassword )
            {
                return false;
            }
            return true;
        } 
    }
}
