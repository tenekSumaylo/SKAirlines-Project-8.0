using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SKAirlines_Project.ViewModels
{
    public class ProfilePageViewModel
    {
        public ICommand LogoutCommand => new Command(LogoutPersonnel);

        public async void LogoutPersonnel()
        {
            await Shell.Current.GoToAsync("//MainPage");
        }
    }
}
