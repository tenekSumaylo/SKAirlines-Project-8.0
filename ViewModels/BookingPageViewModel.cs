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

        private bool guestSet;  // page for setting the number of passengers
        private bool chooseFlight; // page for choosing the flight
        private bool detailsForm; // page for inputting the details
        private bool addOnsSection; // page for selection of add ons
        private bool seatSelection;  // page for seat selection

        public BookingPageViewModel() {
            PassengerAddPage = true;
        }

        public bool GuestSet
        {
            get => this.guestSet;
            set
            {
                this.guestSet = value;
                OnPropertyChanged(nameof(GuestSet));
            }
        }

        public bool ChooseFlight
        {
            get => this.chooseFlight;
            set
            {
                this.chooseFlight = value;
                OnPropertyChanged(nameof(ChooseFlight));
            }
        } 
        public bool DetailsForm
        {
            get => this.detailsForm;
            set
            {
                this.detailsForm = value;
                OnPropertyChanged(nameof(DetailsForm)); 
            }
        }
        public bool AddOnsSection
        {
            get => this.addOnsSection;
            set
            {
                this.addOnsSection = value;
                OnPropertyChanged(nameof(AddOnsSection));
            }
        } // page for selection of add ons
        public bool SeatSelection
        {
            get => this.seatSelection;
            set
            {
                this.seatSelection = value;
                OnPropertyChanged(nameof(SeatSelection));
            }
        }  // page for seat selection



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
                else
                {
                    InfantChecker = true;
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
