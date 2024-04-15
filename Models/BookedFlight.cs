using Kotlin.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAirlines_Project.Models
{
    public class BookedFlight : BaseModel
    {
        private string bookedFlightID;
        private Payment paymentSlip;
        private ObservableCollection<Ticket> tickets;
        private Flight flightID;

        public string BookedFlightID
        {
            get => this.bookedFlightID;
            set
            {
                this.bookedFlightID = value;
                OnPropertyChanged(nameof(BookedFlight));
            }
        }

        public Payment PaymentSlip
        {
            get => this.paymentSlip;
            set
            {
                this.paymentSlip = value;
                OnPropertyChanged(nameof (PaymentSlip));
            }
        }

        public ObservableCollection<Ticket> Tickets
        {
            get => this.tickets;
            set
            {
                this.tickets = value;
                OnPropertyChanged(nameof(Tickets));
            }
        }

        public Flight FlightID
        {
            get => this.flightID;
            set
            {
                this.flightID = value;
                OnPropertyChanged(nameof(FlightID));
            }
        }

    }
}
