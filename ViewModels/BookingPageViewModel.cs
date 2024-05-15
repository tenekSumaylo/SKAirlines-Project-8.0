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
        private ObservableCollection<Flight> flightsAvailable;
        private ObservableCollection<Flight> flightsAvailableReturn;
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
        private ObservableCollection<Seat> selectedSeatsReturn;
        private Seat seatSelect;
        private ObservableCollection<Seat> theSeats = new ObservableCollection<Seat>();
        private List<Seat> testSeats = new List<Seat>();
        private int totalPerson;
        private int countSelection;
        private List<string> option;
        private int selectIndexForSeats;
        private bool roundTripCheck;
        private Ticket selectedLuggagePerson;
        private int luggageCountOne;
        private int luggageCountTwo;
        private ObservableCollection<Luggage> theLuggage;
        private Ticket selectedLuggagePersonReturn;
        private string selectedDateTimeOneWay;
        private string selectedDateTimeTwoWay;
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
        public ICommand ReturnFromSeatSelection => new Command(ReturnFromSeatSelectionButton);
        public ICommand SaveSeatCommand => new Command(SaveSeat);
        public ICommand LuggageRedirect => new Command(LuggagePageRedirect);
        public ICommand AddBaggage => new Command(AddBaggageFunction);
        public ICommand DeleteLuggageCommand => new Command(DeleteLuggage);
        public ICommand DepartureCommand => new Command(DepartureOneWay);
        public ICommand RoundTripCommand => new Command(DepartureTwoWay);
        private bool oneWayLuggage;
        private bool twoWayLuggage;
        public ICommand BackFromBaggageCommand => new Command(BackBaggage);
        public ICommand BackButtonToInputCommand => new Command(BackButtonToInput);
        public ICommand ProceedToPaymentCommand => new Command(PaymentProceed);

        public string SelectedDateTimeOneWay
        {
            get => this.selectedDateTimeOneWay;
            set
            {
                this.selectedDateTimeOneWay = value;
                OnPropertyChanged(nameof(SelectedDateTimeOneWay));
            }
            
        }

        public string SelectedDateTimeTwoWay
        {
            get => this.selectedDateTimeTwoWay;
            set
            {
                this.selectedDateTimeTwoWay = value;
                OnPropertyChanged(nameof(SelectedDateTimeTwoWay));
            }
        }



        public void PaymentProceed()
        {
            ShowTicketPage = true ;
            SelectedDateTimeOneWay = $"{SelectedFlight.FlightDate.Date}";
            if ( SelectedFlightReturn != null )
            {
                SelectedDateTimeTwoWay = $"{SelectedFlight.FlightDate.Date}";
            }
        }
        public BookingPageViewModel()
        {
            PassengerAddPage = true;
            genService = new GenericServices("Flights.json");
            InserterOfData = new ObservableCollection<Ticket>();
            SelectedPerson = new ObservableCollection<Ticket>();
            countSelection = 0;
            Option = new List<string>()
            {
                "For one-way", "For roundtrip"
            };
            luggageCountOne = 0;
            luggageCountTwo = 0;
        }

        public void BackBaggage()
        {
            AddOnsPage = true;
        }

        public void BackButtonToInput()
        {
            DetailsPage = true;
        }


        public void DepartureOneWay()
        {
            TwoWayLuggage = false;
            OneWayLuggage = true;
        }

        public void DepartureTwoWay()
        {
            OneWayLuggage = false;
            TwoWayLuggage = true;
        }

        public bool OneWayLuggage
        {
            get => this.oneWayLuggage;
            set
            {
                this.oneWayLuggage = value;
                OnPropertyChanged(nameof(OneWayLuggage));
            }
        }

        public Ticket SelectedLuggagePersonReturn
        {
            get => this.selectedLuggagePersonReturn;
            set
            {
                this.selectedLuggagePersonReturn = value;
                OnPropertyChanged(nameof(SelectedLuggagePersonReturn));
            }
        }

        public bool TwoWayLuggage
        {
            get => this.twoWayLuggage;
            set
            {
                this.twoWayLuggage = value;
                OnPropertyChanged(nameof(TwoWayLuggage));
            }
        }
        public void DeleteLuggage()
        {
            if ( TheLuggage.Count != 0 )
            {
                TheLuggage.RemoveAt(TheLuggage.Count - 1);
            }
        }

        public ObservableCollection<Luggage> TheLuggage
        {
            get => this.theLuggage;
            set
            {
                this.theLuggage = value;
                OnPropertyChanged(nameof(TheLuggage));
            }
        }
        public void AddBaggageFunction()
        {
            Luggage b = new Luggage();
            b.SequenceNumber = TheLuggage.Count;
            b.LuggageID = SelectedFlight.FlightID + "-luggage-" + b.SequenceNumber;
            b.ChargePerLuggage = 100;
            b.FlightID = SelectedFlight.FlightID;
            TheLuggage.Add( b );
        }



        public Ticket SelectedLuggagePerson
        {
            get => this.selectedLuggagePerson;
            set
            {
                this.selectedLuggagePerson = value;
                OnPropertyChanged(nameof(SelectedLuggagePerson));
                TheLuggage = SelectedLuggagePerson.Luggages;
            }
        }

        public void LuggagePageRedirect()
        {
            LuggagePage = true;
            SelectedLuggagePerson = TheTickets.FirstOrDefault();

        }

        public void ReturnFromSeatSelectionButton()
        {
            AddOnsPage = true;
        }

        public void SaveSeat()
        {
            AddOnsPage = true;
        }

        public void SaveSeatPay()
        {
            Seat[] oneWay = new Seat[SelectedSeats.Count];
            ObservableCollection<Ticket> Dummy = new ObservableCollection<Ticket>();
            ObservableCollection<Ticket> DummyB = new ObservableCollection<Ticket>();
            ObservableCollection<Ticket> NewPlace1 = new ObservableCollection<Ticket>();
            ObservableCollection<Ticket> NewPlace2 = new ObservableCollection<Ticket>();
            ObservableCollection<Seat> seats;
            Seat[] AllSeats = new Seat[SelectedFlight.TheSeats.Count];
            int i = 0;
            if ( RoundTripCheck == true )
            {
                Seat[] AllSeatsReturn = new Seat[SelectedFlightReturn.TheSeats.Count];
                Seat[] twoWay = new Seat[SelectedSeatsReturn.Count];
                SelectedSeatsReturn.CopyTo(twoWay, 0);
                foreach ( var j in TheTicketsReturn )
                {
                    j.SeatID = i < twoWay.Length ? twoWay[i] : new Seat();
                    Dummy.Add(j);
                    ++i;
                }

                TheTicketsReturn = Dummy;
                int loopVar = 0;
                // Seat[] AllSeatsReturn = new Seat[SelectedFlightReturn.TheSeats.Count];
                SelectedFlightReturn.TheSeats.CopyTo(AllSeatsReturn, 0);
                if ( SelectedSeatsReturn.Count != totalPerson )
                {

                    foreach ( var edit in TheTicketsReturn )
                    {
                        if ( edit.SeatID.IsSelector != true )
                        { 
                            while ( loopVar < AllSeatsReturn.Length )
                            {
                                if (AllSeatsReturn[ loopVar ].SeatStatus == 0 )
                                {
                                    edit.SeatID = AllSeatsReturn[loopVar];
                                    AllSeatsReturn[loopVar].SeatStatus = 2;
                                    break;
                                }
                                ++loopVar;
                            }
                        }
                        NewPlace1.Add(edit);
                    }
                    TheTicketsReturn = NewPlace1;
                }
             //   foreach (var change in TheTicketsReturn)
               // {
            //        AllSeatsReturn[change.SeatID.SeatNumber - 1].SeatStatus = 2;
            //    }
                seats = new ObservableCollection<Seat>(AllSeatsReturn);
                SelectedFlightReturn.TheSeats = seats;
            }

            i = 0;
            SelectedSeats.CopyTo(oneWay, 0);
            foreach ( var k in TheTickets )
            {
                k.SeatID = i < oneWay.Length ? oneWay[i] : new Seat();
                DummyB.Add(k);
                ++i;
            }
            TheTickets = DummyB;

            int loopVarB = 0;
            //Seat[] AllSeats = new Seat[SelectedFlight.TheSeats.Count];
            SelectedFlight.TheSeats.CopyTo(AllSeats, 0);
            if (SelectedSeats.Count != totalPerson)
            {

                foreach (var edit in TheTickets)
                {
                    if (edit.SeatID.IsSelector != true)
                    {
                        while (loopVarB < AllSeats.Length)
                        {
                            if (AllSeats[loopVarB].SeatStatus == 0)
                            {
                                edit.SeatID = AllSeats[loopVarB];
                                AllSeats[loopVarB].SeatStatus = 2;
                                break;
                            }
                            ++loopVarB;
                        }
                    }
                    NewPlace2.Add(edit);
                }
                TheTickets = NewPlace2;

            }
         //   foreach (var change in TheTickets)
           // {
           //     AllSeats[change.SeatID.SeatNumber - 1].SeatStatus = 2;
          //  }
            seats = new ObservableCollection<Seat>(AllSeats);
            SelectedFlight.TheSeats = seats;
        }

        public ObservableCollection<Seat> SelectedSeatsReturn
        {
            get => this.selectedSeatsReturn;
            set
            {
                this.selectedSeatsReturn = value;
                OnPropertyChanged(nameof(SelectedSeatsReturn));
            }
        }

        public bool RoundTripCheck
        {
            get => this.roundTripCheck;
            set
            {
                this.roundTripCheck = value;
                OnPropertyChanged(nameof(RoundTripCheck));
            }
        }

        public int SelectIndexForSeats
        {
            get => this.selectIndexForSeats;
            set
            {
                this.selectIndexForSeats = value;
                OnPropertyChanged(nameof(SelectIndexForSeats));
                if ( FlightsAvailable == null )
                {
                    return;
                }

                if ( FlightsAvailableReturn == null && RoundTripCheck == true )
                {
                    return;
                }
               
                if ( value == 0 )
                {
                    TheSeats = SelectedFlight.TheSeats;
                }
                else
                {
                    TheSeats = SelectedFlightReturn.TheSeats;
                }
            }
        }

        public List<string> Option
        {
            get => this.option;
            set
            {
                this.option = value;
                OnPropertyChanged( nameof(Option) );    
            }
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
            SelectedSeats = new ObservableCollection<Seat>();
            SelectedSeatsReturn = new ObservableCollection<Seat>();
            SelectIndexForSeats = 0;
        }

        public async void GuestNext()
        {
            foreach ( var j in theTickets )
            {
                if ( string.IsNullOrEmpty( j.FirstName) || string.IsNullOrEmpty( j.LastName ) || string.IsNullOrEmpty(j.PhoneNumber ))
                {
                    await Shell.Current.DisplayAlert("Complete the form", "Fill-in the incomplete form", "Close");
                    TheTicketsReturn = TheTickets;
                    SetPerson(2);
                    return;
                }
            }
            AddOnsPage = true;
        }

        public async void selectSeatsOne()
        {
            if (SelectIndexForSeats == 0)
            {
                if (SeatSelect.SeatStatus == 1)
                {
                    SelectedSeats.Remove(SeatSelect);
                    SeatSelect.IsSelector = false;
                    SeatSelect.SeatStatus = 0;
                    --countSelection;
                    return;
                }

                if (SelectedSeats.Count == totalPerson)
                {
                    await Shell.Current.DisplayAlert("Cannot add seats", "You have exceeded the limit", "Confirm");
                    return;
                }

                if (SeatSelect.SeatStatus >= 2)
                {
                    await Shell.Current.DisplayAlert("Seat Occupied", "Choose another seat", "Confirm");
                    return;
                }
                SeatSelect.IsSelector = true;
                SeatSelect.SeatStatus = 1;
                SelectedSeats.Add(SeatSelect);
            }
            else
            {
                if (SeatSelect.SeatStatus == 1)
                {
                    SelectedSeatsReturn.Remove(SeatSelect);
                    SeatSelect.IsSelector = false;
                    SeatSelect.SeatStatus = 0;
                    --countSelection;
                    return;
                }

                if (SelectedSeatsReturn.Count == totalPerson)
                {
                    await Shell.Current.DisplayAlert("Cannot add seats", "You have exceeded the limit", "Confirm");
                    return;
                }

                if (SeatSelect.SeatStatus >= 2)
                {
                    await Shell.Current.DisplayAlert("Seat Occupied", "Choose another seat", "Confirm");
                    return;
                }
                SeatSelect.IsSelector = true;
                SeatSelect.SeatStatus = 1;
                SelectedSeatsReturn.Add(SeatSelect);
            }
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
                TheTicketsReturn.Insert(i, thePerson);
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
                totalPerson = Adult + Children + Infant;
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
                RoundTripCheck = TheDataPassed.IsRoundTrip;
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
