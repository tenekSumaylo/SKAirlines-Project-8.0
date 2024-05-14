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
    [QueryProperty(nameof(TheDataPassed), "TheDataPassed")]
    public class BookingPageViewModel : BaseViewModel
    {
        public UserDomain UserDomain { get; set; }
        private string destination = string.Empty, origin = string.Empty;
        private DateTime OneWayDate;
        private DateTime ReturnDate;
        private ObservableCollection<Flight> flightsAvailable = new ObservableCollection<Flight>();
        private ObservableCollection<Flight> flightsAvailableReturn = new ObservableCollection<Flight>();
        private ObservableCollection<Ticket> theTickets = new ObservableCollection<Ticket>();
        private ObservableCollection<Ticket> theTicketsReturn = new ObservableCollection<Ticket>();
        private DataPasser theDataPassed;
        private int adult;
        private int children;
        private int infant;
        private bool infantChecker;
        private GenericServices genService;
        private AdminService adService;
        private Flight selectedFlight;
        private ObservableCollection<Ticket> selectedPerson;
        private Ticket menuSelectPerson;
        private Ticket testPerson;
        private Flight selectedFlightReturn;
        public ObservableCollection<Ticket> InserterOfData { get; set; }
        private ObservableCollection<Seat> selectedSeats;
        private Seat seatSelect;
        private ObservableCollection<Seat> theSeats = new ObservableCollection<Seat>();
        private List<Seat> testSeats = new List<Seat>();
        private int totalPerson;
        private int countSelection; 

        // commands

        public ICommand ButtonOne => new Command(ButtonOneClicked);
        public ICommand ButtonOneBack => new Command(ButtonOneBackClicked);
        public ICommand ButtonTwoBack => new Command(ButtonTwoBackClicked);
        public ICommand ButtonThreeBack => new Command(ButtonThreeBackClicked);
        public ICommand SelectedPersonCommand => new Command(SelectedPersonChange);
        public ICommand GuestNextCommand => new Command(GuestNext);
        public ICommand SeatSelectionCommand => new Command(SeatSelectionRedirect);

        public ICommand ButtonTwoBackReturn => new Command(ButtonTwoBackReturnClicked);


        public ICommand SelectedSeatsOneCommand => new Command(selectSeatsOne);

        public BookingPageViewModel()
        {
            PassengerAddPage = true;
            genService = new GenericServices("Flights.json");
            InserterOfData = new ObservableCollection<Ticket>();
            SelectedPerson = new ObservableCollection<Ticket>();
            countSelection = 0;
        }

        public Seat SeatSelect
        {
            get => this.seatSelect;
            set
            {
                this.seatSelect = value;
                OnPropertyChanged(nameof(SeatSelect));
            }
        }

        public List<Seat> TestSeats
        {
            get => this.testSeats;
            set
            {
                this.testSeats = value;
                OnPropertyChanged(nameof(TestSeats));
            }
        }

        public Ticket TestPerson
        {
            get => this.testPerson;
            set
            {
                this.testPerson = value;
                OnPropertyChanged(nameof(TestPerson));
            }
        }

        public void ButtonTwoBackReturnClicked()
        {
            ChooseFlightPage = true;
        }

        public ObservableCollection<Seat> TheSeats
        {
            get => this.theSeats;
            set
            {
                this.theSeats = value;
                OnPropertyChanged(nameof(TheSeats));
            }
        }

        public void SeatSelectionRedirect()
        {
            SeatSelectionPage = true;
            TheSeats = SelectedFlight.TheSeats;
            SeatSelect = new Seat();
            SelectedSeats = new ObservableCollection<Seat>();
        }

        public async void GuestNext()
        {
            foreach ( var j in theTickets )
            {
                if ( string.IsNullOrEmpty( j.FirstName) || string.IsNullOrEmpty( j.LastName ) || string.IsNullOrEmpty(j.PhoneNumber ))
                {
                    await Shell.Current.DisplayAlert("Complete the form", "Fill-in the incomplete form", "Close");
                    return;
                }
            }
            AddOnsPage = true;
        }

        public void selectSeatsOne()
        {
            SeatSelect.IsOccupied = true;
            //seatSelected.IsOccupied = true;
            //TheSeats.RemoveAt(seatSelected.SeatNumber - 1);
            //TheSeats.Insert( seatSelected.SeatNumber - 1, seatSelected );
        }
        public ObservableCollection<Seat> SelectedSeats
        {
            get => this.selectedSeats;
            set
            {
                this.selectedSeats = value;
                OnPropertyChanged(nameof(SelectedSeats));          
            }
        }
        public Ticket MenuSelectPerson
        {
            get => this.menuSelectPerson;
            set
            {
                this.menuSelectPerson = value;
                OnPropertyChanged(nameof(MenuSelectPerson));
                SelectedPerson.Clear();
                SelectedPerson.Add(MenuSelectPerson);
            }
        }

        public Flight SelectedFlightReturn
        {
            get => this.selectedFlightReturn;
            set
            {
                this.selectedFlightReturn = value;
                OnPropertyChanged(nameof(SelectedFlightReturn));
                DetailsPage = true;
                SetPerson(2);
            }
        }

        public void SelectedPersonChange()
        {
            int i = Convert.ToInt32( SelectedPerson.First().Title[ SelectedPerson.First().Title.Length - 1 ]);
            var roundTripVar = TheTicketsReturn.First();
            var thePerson = SelectedPerson.First();
            TheTickets.RemoveAt(i);
            TheTickets.Insert(i, thePerson);
            if ( TheDataPassed.IsRoundTrip )
            {
                thePerson.OriginLocation = TheDataPassed.ReturnOrigin;
                thePerson.DestinationLocation = TheDataPassed.ReturnDestination;
                thePerson.DateFlight = roundTripVar.DateFlight;
                thePerson.TimeFlight = roundTripVar.TimeFlight;
                thePerson.ChargePerTicket = roundTripVar.ChargePerTicket;
                TheTicketsReturn.RemoveAt(i);
                TheTickets.Insert(i, thePerson);
            }
        }



        public ObservableCollection<Ticket> TheTickets
        {
            get => this.theTickets;
            set
            {
                this.theTickets = value;
                OnPropertyChanged(nameof(TheTickets));
            }
        }

        public ObservableCollection<Ticket> SelectedPerson
        {
            get => this.selectedPerson;
            set
            {
                this.selectedPerson = value;
                OnPropertyChanged(nameof(SelectedPerson));
            }

        }

        public ObservableCollection<Ticket> TheTicketsReturn
        {
            get => this.theTicketsReturn;
            set
            {
                this.theTicketsReturn = value;
                OnPropertyChanged(nameof(TheTicketsReturn));
            }
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

        public void ButtonTwoBackClicked()
        {
            PassengerAddPage = true;
        }

        public void ButtonThreeBackClicked()  // hopeless case fuckers
        {
            ChooseFlightPage = true;
        }

        public async void ButtonOneClicked() {
            if (!(Adult == 0 && Children == 0 && Infant == 0))
            {
                ChooseFlightPage = true;
                countSelection = 0;
                TheTickets.Clear();
                CreateGuests();
                return;
            }
            await Shell.Current.DisplayAlert("No passenger", "Input atleast one passenger", "Confirm");
        }

        public async void ButtonOneBackClicked()
        {
            await Shell.Current.GoToAsync("..");
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

        public Flight SelectedFlight
        {
            get => this.selectedFlight;
            set
            {
                if ( TheDataPassed.IsRoundTrip == false)
                {
                    DetailsPage = true;
                }
                else
                {
                    ChooseFlightPageRoundTrip = true;
                }

                this.selectedFlight = value;
                OnPropertyChanged(nameof(SelectedFlight));
                SetPerson( 1 );

            }
        }

        public void SetPerson( int i )
        {
            InserterOfData.Clear();
            if (i == 1)
            {
                foreach (var setPerson in TheTickets)
                {
                    setPerson.DestinationLocation = SelectedFlight.DestinationPlace;
                    setPerson.OriginLocation = SelectedFlight.OriginPlace;
                    setPerson.DateFlight = SelectedFlight.FlightDate;
                    setPerson.TimeFlight = SelectedFlight.FlightTime;
                    setPerson.ChargePerTicket = SelectedFlight.Fare;
                    InserterOfData.Add(setPerson);
                }
                TheTickets.Clear();
            }
            else
            {
                foreach (var setPerson in TheTicketsReturn)
                {
                    setPerson.DestinationLocation = SelectedFlight.DestinationPlace;
                    setPerson.OriginLocation = SelectedFlight.OriginPlace;
                    setPerson.DateFlight = SelectedFlight.FlightDate;
                    setPerson.TimeFlight = SelectedFlight.FlightTime;
                    setPerson.ChargePerTicket = SelectedFlight.Fare;
                    InserterOfData.Add(setPerson);
                }
                TheTicketsReturn.Clear();
            }

            foreach (var setPerson in InserterOfData)
            {
                if ( i == 1 )
                {
                    TheTickets.Add(setPerson);
                }
                else
                {
                    TheTicketsReturn.Add(setPerson);
                }

            }
        }

        public DataPasser TheDataPassed
        {
            get => theDataPassed; 
            set
            {
                this.theDataPassed = value;
                OnPropertyChanged(nameof(TheDataPassed));
                SearchFlight();
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

        public void CreateGuests()
        {
            Ticket ChainPerson;
            for (int i = 1; i <= Adult + Children + Infant; ++i)
            {
                if (i <= Adult)
                {

                    ChainPerson = new Ticket( 1, i );
                    TheTickets.Add(ChainPerson);
                }
                else if (i <= Adult + Children)
                {
                    ChainPerson = new Ticket(2, i);
                    TheTickets.Add(ChainPerson);
                }
                else if ( i <= Adult + Children + Infant )
                {
                    ChainPerson = new Ticket(3, i);
                    TheTickets.Add( ChainPerson );
                }

                if ( TheDataPassed.IsRoundTrip )
                {
                    if (i <= Adult)
                    {

                        ChainPerson = new Ticket(1, i);
                        TheTicketsReturn.Add(ChainPerson);
                    }
                    else if (i <= Adult + Children)
                    {
                        ChainPerson = new Ticket(2, i);
                        TheTicketsReturn.Add(ChainPerson);
                    }
                    else if (i <= Adult + Children + Infant)
                    {
                        ChainPerson = new Ticket(3, i);
                        TheTicketsReturn.Add(ChainPerson);
                    }
                }

            }
            // add persons 
            //MenuSelectPerson = TheTickets.First();
            MenuSelectPerson = TheTickets.First();
        } 
    }
}
