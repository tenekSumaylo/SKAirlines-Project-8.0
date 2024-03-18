using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAirlines_Project.Models
{
    public class UserDomain : Person
    {
        string userID;
        string password;
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
            get => userID;
            set
            {
                userID = value;
                OnPropertyChanged(nameof(UserID));
            }
        }

        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public int UserType
        {
            get => userType;
            set
            {
                userType = value;
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
