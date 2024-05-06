using SKAirlines_Project.Models;
using SKAirlines_Project.ServiceModel;
using SKAirlines_Project.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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
        private ObservableCollection<Flight> flightsAvailableReturn = new ObservableCollection<Flight>();
        private ObservableCollection<Ticket> theTickets = new ObservableCollection<Ticket>();
        private DataPasser theDataPassed;
        private int adult;
        private int children;
        private int infant;
        private bool infantChecker;
        private GenericServices genService; 

        // commands

        public ICommand ButtonOne => new Command(ButtonOneClicked);
        public ICommand ButtonOneBack => new Command(ButtonOneBackClicked);

        public BookingPageViewModel() {
            PassengerAddPage = true;
            genService = new GenericServices("Flight.json");
            SearchFlight();
        }

        public async void SearchFlight()
        {
            if ( TheDataPassed.IsRoundTrip )
            {
                FlightsAvailable = await genService.SearchFlights(TheDataPassed.Destination, TheDataPassed.Origin, TheDataPassed.OneWay);
                FlightsAvailableReturn = await genService.SearchFlights(TheDataPassed.Origin, TheDataPassed.Destination, TheDataPassed.TwoWay);
                return;
            }
            FlightsAvailable = await genService.SearchFlights(TheDataPassed.Destination, TheDataPassed.Origin, TheDataPassed.OneWay);
        }

        public async void ButtonOneClicked() {
            if (!(Adult == 0 && Children == 0 && Infant == 0))
            {
                ChooseFlightPage = true;
                return;
            }
            await Shell.Current.DisplayAlert("No passenger", "Input atleast one passenger", "Confirm");
        }

        public async void ButtonOneBackClicked()
        {
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

        public ObservableCollection<Flight> FlightsAvailableReturn
        {
            get => this.flightsAvailableReturn;
            set
            {
                this.flightsAvailableReturn = value;
                OnPropertyChanged(nameof(FlightsAvailableReturn));
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
                this.infant = value;
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
