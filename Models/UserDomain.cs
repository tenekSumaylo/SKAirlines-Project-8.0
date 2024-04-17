using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAirlines_Project.Models
{
    public class UserDomain : Passenger
    {
        string userID = string.Empty;
        string password = string.Empty;
        int userType;
        private ObservableCollection<BookedFlight> bookedFlights;
        private ObservableCollection<BoardingPass> boardingPasses;
        public UserDomain() {
            BookedFlights = new ObservableCollection<BookedFlight>();
            BoardingPasses = new ObservableCollection<BoardingPass>();
        }

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

        public ObservableCollection<BookedFlight> BookedFlights
        {
            get => this.bookedFlights;
            set
            {
                this.bookedFlights = value;
                OnPropertyChanged(nameof(BookedFlights));
            }
        }

        public ObservableCollection<BoardingPass> BoardingPasses
        {
            get => this.boardingPasses;
            set
            {
                this.boardingPasses = value;
                OnPropertyChanged(nameof(BoardingPasses));
            }
        }

        public void UserClear()
        {
            BoardingPasses.Clear();
            BookedFlights.Clear();
            userID = String.Empty;
            Password = String.Empty;
            UserType = -1;
            ClearForm();
        }



    }
}
