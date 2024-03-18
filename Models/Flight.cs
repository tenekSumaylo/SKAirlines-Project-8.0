using Android.Icu.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAirlines_Project.Models
{
    public class Flight : BaseModel
    {
        private string planeName = string.Empty;
        private DateTime flightDate;
        private DateTime flightTime;
        private int numberOfSeats;
        private bool isDeleted;
        private bool isDeparted;
        private string originPlace = string.Empty;
        private string destinationPlace = string.Empty;
        private string flightID = string.Empty;
        private double fare;

        public Flight(string planeName, DateTime flightDate, DateTime flightTime, int numberOfSeats, bool isDeleted, bool isDeparted, string originPlace, string destinationPlace, string flightID)
        {
            PlaneName = planeName;
            FlightDate = flightDate;
            FlightTime = flightTime;
            NumberOfSeats = numberOfSeats;
            IsDeleted = isDeleted;
            IsDeparted = isDeparted;
            OriginPlace = originPlace;
            DestinationPlace = destinationPlace;
            FlightID = flightID;
        }

        public double Fare
        {
            get => this.fare;
            set
            {
                this.fare = value;
                OnPropertyChanged(nameof(Fare));
            }
        }

        public string PlaneName
        {
            get => this.planeName;
            set
            {
                this.planeName = value;
                OnPropertyChanged(nameof(PlaneName));
            }
        }

        public DateTime FlightDate
        {
            get => this.flightDate;
            set
            {
                this.flightDate = value;
                OnPropertyChanged( nameof(FlightDate));
            }
        }

        public DateTime FlightTime
        {
            get => this.flightTime;
            set
            {
                this.flightTime = value;
                OnPropertyChanged( nameof(FlightTime));
            }
        }

        public int NumberOfSeats
        {
            get => this.numberOfSeats;
            set
            {
                this.numberOfSeats = value;
                OnPropertyChanged( nameof(NumberOfSeats));
            }
        }
        public bool IsDeleted
        {
            get => this.isDeleted;
            set
            {
                this.isDeleted = value;
                OnPropertyChanged( nameof(IsDeleted));
            }
        }

        public bool IsDeparted
        {
            get => this.isDeparted;
            set
            {
                this.isDeparted = value;
                OnPropertyChanged(nameof(IsDeparted));
            }
        }

        public string OriginPlace
        {
            get => this.originPlace;
            set
            {
                this.originPlace = value;
                OnPropertyChanged(nameof(OriginPlace));
            }
        }

        public string DestinationPlace
        {
            get => this.destinationPlace;
            set
            {
                this.destinationPlace = value;
                OnPropertyChanged(nameof(DestinationPlace));    
            }
        }

        public string FlightID
        {
            get => this.flightID;
            set
            {
                this.flightID = value;
                OnPropertyChanged( nameof(FlightID));
            }
        }

        public void ClearForm()
        {
            PlaneName = string.Empty;
            FlightDate = DateTime.Now;
            FlightTime = DateTime.Now;
            NumberOfSeats = -1;
            IsDeleted = false;
            IsDeparted = false;
            OriginPlace = string.Empty;
            DestinationPlace = string.Empty;
            FlightID = string.Empty;
        }

    }
}
