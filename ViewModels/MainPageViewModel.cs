using SKAirlines_Project.Services;
using System;
using System.Collections.Generic;
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
    }
}
