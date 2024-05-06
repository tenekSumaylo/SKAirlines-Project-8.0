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
        private bool isOccupied;

        public Seat() { }
        public Seat( string id, int number, bool occupy)
        {
            SeatID = id + "-" + number;
            SeatNumber = number;
            IsOccupied = occupy;
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

        public bool IsOccupied
        {
            get => this.isOccupied;
            set
            {
                this.isOccupied = value;
                OnPropertyChanged(nameof(IsOccupied));
            }
        }

        public void ClearForm()
        {
            SeatID = string.Empty;
            SeatNumber = -1;
            IsOccupied = false;
        }
    }
}
