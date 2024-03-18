using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAirlines_Project.Models
{
    public class UserDomain : Person
    {
        string userID = string.Empty;
        string password = string.Empty;
        int userType;
        public UserDomain() { }

        public UserDomain(string user, string pass, int userData)
        {
            UserID = user;
            Password = pass;
            UserType = userData;
        }

        public string UserID
        {
            get => this.userID;
            set
            {
                this.userID = value;
                OnPropertyChanged(nameof(UserID));
            }
        }

        public string Password
        {
            get => this.password;
            set
            {
                this.password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public int UserType
        {
            get => this.userType;
            set
            {
                this.userType = value;
                OnPropertyChanged(nameof(UserType));
            }
        }

        private void UserClear()
        {
            userID = String.Empty;
            Password = String.Empty;
            UserType = -1;
            ClearForm();
        }

    }
}
