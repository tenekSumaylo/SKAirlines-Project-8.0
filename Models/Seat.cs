using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAirlines_Project.Models
{
    public class Seat : BaseModel
    {
        private string seatID = string.Empty;
        private int seatNumber;
        private bool isSelector;
        private int seatStatus; 

        public Seat() { }
        public Seat( string id, int number, bool selector, int status)
        {
            SeatID = id + "-" + number;
            SeatNumber = number;
            IsSelector = selector;
            seatStatus = status;
        }

        public int SeatStatus
        {
            get => this.seatStatus;
            set
            {
                this.seatStatus = value;
                OnPropertyChanged(nameof(SeatStatus));
            }
        }

        public string SeatID
        {
            get => this.seatID;
            set {
                this.seatID = value;
                OnPropertyChanged(nameof(SeatID));
            }

        }

        public int SeatNumber
        {
            get => this.seatNumber;
            set
            {
                this.seatNumber = value;
                OnPropertyChanged(nameof(SeatNumber));
            }
        }

        public bool IsSelector
        {
            get => this.isSelector;
            set
            {
                this.isSelector = value;
                OnPropertyChanged(nameof(IsSelector));
            }
        }

        public void ClearForm()
        {
            SeatID = string.Empty;
            SeatNumber = -1;
            IsSelector = false;
            SeatStatus = 0;
        }
    }
}
