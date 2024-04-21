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
    [QueryProperty(nameof(TheDataPassed), nameof(TheDataPassed))]
    public class BookingPageViewModel : BaseViewModel
    {
        private UserDomain UserDomain { get; set; }
        private string destination = string.Empty, origin = string.Empty;
        private DateTime OneWayDate;
        private DateTime ReturnDate;
        private ObservableCollection<Flight> flightsAvailable = new ObservableCollection<Flight>();
        private ObservableCollection<Ticket> theTickets = new ObservableCollection<Ticket>();
        private DataPasser theDataPassed;

        public DataPasser TheDataPassed
        {
            get { return theDataPassed; }
            set
            {
                this.theDataPassed = value;
                OnPropertyChanged(nameof(TheDataPassed));
            }
        }
    }
}
