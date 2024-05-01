using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAirlines_Project.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        protected static bool EmailCheck(string word) => new EmailAddressAttribute().IsValid(word);
        private bool passengerAddPage;
        private bool chooseFlightPage;
        private bool detailsPage;
        private bool addOnsPage;
        private bool seatSelectionPage;

        public void PageConverter()
        {
            PassengerAddPage = false;
            ChooseFlightPage = false;
            DetailsPage = false;
            AddOnsPage = false;
            SeatSelectionPage = false;
        }

        public bool PassengerAddPage
        {
            get => this.passengerAddPage;
            set
            {
                if ( value == true )
                {
                    PageConverter();
                }
                passengerAddPage = value;
                OnPropertyChanged(nameof(PassengerAddPage));
            }
        }

        public bool ChooseFlightPage
        {
            get => this.chooseFlightPage;
            set
            {
                if (value == true)
                {
                    PageConverter();
                }
                this.chooseFlightPage = value;
                OnPropertyChanged(nameof(ChooseFlightPage));
            }
        }

        public bool DetailsPage
        {
            get => this.detailsPage;
            set
            {
                if (value == true)
                {
                    PageConverter();
                }
                this.detailsPage = value;
                OnPropertyChanged(nameof(DetailsPage));
            }
        }

        public bool AddOnsPage
        {
            get => this.addOnsPage;
            set
            {
                if (value == true)
                {
                    PageConverter();
                }
                this.addOnsPage = value;
                OnPropertyChanged(nameof(AddOnsPage));
            }
        }

        public bool SeatSelectionPage
        {
            get => this.seatSelectionPage;
            set
            {
                if (value == true)
                {
                    PageConverter();
                }
                this.seatSelectionPage = value;
                OnPropertyChanged(nameof(SeatSelectionPage));
            }
        }
    }
}
