using SKAirlines_Project.Models;
using SKAirlines_Project.ServiceModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAirlines_Project.ViewModels
{
  //  [QueryProperty(nameof(TheDataPassed), "TheDataPassed")]
    public class BookingPageViewModel : BaseViewModel
    {
        public UserDomain UserDomain { get; set; }
        private string destination = string.Empty, origin = string.Empty;
        private DateTime OneWayDate;
        private DateTime ReturnDate;
        private ObservableCollection<Flight> flightsAvailable = new ObservableCollection<Flight>();
        private ObservableCollection<Ticket> theTickets = new ObservableCollection<Ticket>();
        private DataPasser theDataPassed;
        private int adult;
        private int children;
        private int infant;
        private bool infantChecker;

        public BookingPageViewModel() {
            Adult = 0;
            Children = 0;
            Infant = 0;
        }

        public ObservableCollection<Flight> FlightsAvailable
        {
            get => this.flightsAvailable;
            set
            {
                this.flightsAvailable = value;
                OnPropertyChanged(nameof(FlightsAvailable));
            }
        }
        public DataPasser TheDataPassed
        {
            get => theDataPassed; 
            set
            {
                this.theDataPassed = value;
                OnPropertyChanged(nameof(TheDataPassed));
            }
        }

        public int Adult
        {
            get => this.adult;
            set
            {
                if ( value == 0 )
                {
                    InfantChecker = false;
                }
                this.adult = value;
                OnPropertyChanged( nameof(Adult));
            }
        }

        public int Children
        {
            get => this.children;
            set
            {
                this.children = value;
                OnPropertyChanged(nameof(Children));
            }
        }

        public int Infant
        {
            get => this.infant;
            set
            {
                this.adult = value;
                OnPropertyChanged(nameof(Infant));
            }
        }

        public bool InfantChecker
        {
            get => this.infantChecker;
            set
            {
                this.infantChecker = value;
                OnPropertyChanged( nameof(InfantChecker));  
            }
        }
    }
}
