﻿using SKAirlines_Project.Models;
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
        private SelectionMode selectionSelectFirst;
        private ObservableCollection<Ticket> selectedPerson = new ObservableCollection<Ticket>();
        private Ticket menuSelectPerson;
        private Ticket testPerson;

        public ObservableCollection<Ticket> InserterOfData { get; set; }

        // commands

        public ICommand ButtonOne => new Command(ButtonOneClicked);
        public ICommand ButtonOneBack => new Command(ButtonOneBackClicked);
        public ICommand ButtonTwoBack => new Command(ButtonTwoBackClicked);
        public ICommand ButtonThreeBack => new Command(ButtonThreeBackClicked);
        public ICommand SelectedPersonCommand => new Command(SelectedPersonChange);

        public Ticket TestPerson
        {
            get => this.testPerson;
            set
            {
                this.testPerson = value;
                OnPropertyChanged(nameof(TestPerson));
            }
        }

        public Ticket MenuSelectPerson
        {
            get => this.menuSelectPerson;
            set
            {
                if ( SelectedPerson != null )
                {
                    foreach ( var j in SelectedPerson )
                    {
                        InserterOfData.Add(j);
                    }
                }
                this.menuSelectPerson = value;
                OnPropertyChanged(nameof(MenuSelectPerson));
                if ( MenuSelectPerson != null )
                {
                    SelectedPerson.Clear();
                    SelectedPerson.Add(MenuSelectPerson);
                }

            }
        }

        public void SelectedPersonChange()
        {
            
        }

        public BookingPageViewModel() {
            PassengerAddPage = true;
            genService = new GenericServices("Flights.json");
            SelectionSelectFirst = SelectionMode.Single;
            InserterOfData = new ObservableCollection<Ticket>();
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

        public SelectionMode SelectionSelectFirst
        {
            get => this.selectionSelectFirst; 
            set
            {
                this.selectionSelectFirst = value;
                OnPropertyChanged(nameof(SelectionSelectFirst));
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
            SelectionSelectFirst = SelectionMode.None;
            SelectionSelectFirst = SelectionMode.Single;
        }

        public async void ButtonOneClicked() {
            if (!(Adult == 0 && Children == 0 && Infant == 0))
            {
                ChooseFlightPage = true;
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
                DetailsPage = true;
                this.selectedFlight = value;
                OnPropertyChanged(nameof(SelectedFlight));
                SetPerson();

            }
        }

        public void SetPerson()
        {
            int i = 0;
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
            foreach (var setPerson in InserterOfData)
            {
                TheTickets.Add(setPerson);
            }
            InserterOfData.Clear();
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

            }
            // add persons 
            MenuSelectPerson = TheTickets.First();
        } 
    }
}
