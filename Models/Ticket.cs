using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAirlines_Project.Models
{
    public class Ticket : Passenger
    {
        private string ticketID = string.Empty;
        private ObservableCollection<Luggage> luggages;
        private Seat seatID;
        private string destinationLocation = string.Empty;
        private string originLocation = string.Empty;
        private DateTime dateFlight;
        private TimeSpan timeFlight;
        private int flightStatus;
        private bool isCancelled;
        private double totalLuggagePrice;
        private double chargePerTicket;

        public Ticket( int typeOfPerson, int number ) : base( typeOfPerson, number )
        {

        }

        public string TicketID
        {
            get => this.ticketID;
            set
            {
                this.ticketID = value;
                OnPropertyChanged(nameof(TicketID));
            }
        }
        public ObservableCollection<Luggage> Luggages
        {
            get => this.luggages;
            set
            {
                this.luggages = value;
                OnPropertyChanged(nameof(Luggages));
            }
        }

        public Seat SeatID
        {
            get => this.seatID;
            set
            {
                this.seatID = value;
                OnPropertyChanged(nameof(SeatID));
            }
        }

        public string DestinationLocation
        {
            get => this.destinationLocation;
            set
            {
                this.destinationLocation = value;
                OnPropertyChanged(nameof(DestinationLocation));
            }
        }
        public string OriginLocation
        {
            get => this.originLocation;
            set
            {
                this.originLocation = value;
                OnPropertyChanged(nameof(OriginLocation));
            }
        }

        public DateTime DateFlight
        {
            get => this.dateFlight;
            set
            {
                this.dateFlight = value;
                OnPropertyChanged(nameof(DateFlight ));
            }
        }

        public TimeSpan TimeFlight
        {
            get => this.timeFlight;
            set
            {
                this.timeFlight = value;
                OnPropertyChanged(nameof(TimeFlight));
            }
        }

        public int FlightStatus
        {
            get => this.flightStatus;
            set
            {
                this.flightStatus = value;
                OnPropertyChanged(nameof(FlightStatus));
            }
        }

        public bool IsCancelled
        {
            get => this.isCancelled;
            set
            {
                this.isCancelled = value;
                OnPropertyChanged(nameof(IsCancelled));
            }
        }

        public double TotalLuggagePrice
        {
            get => this.totalLuggagePrice;
            set
            {
                this.totalLuggagePrice = value;
                OnPropertyChanged(nameof(TotalLuggagePrice));
            }
        }

        public double ChargePerTicket
        {
            get => this.chargePerTicket;
            set
            {
                this.chargePerTicket = value;
                OnPropertyChanged(nameof(ChargePerTicket));
            }
        }


    }
}
