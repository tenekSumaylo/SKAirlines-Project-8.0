using Microsoft.Maui.Animations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAirlines_Project.Models
{
    public class BoardingPass : BaseModel
    {
        private BookedFlight bookedFlight;
        private int gateNumber;
        private bool isBoarded;
        private string userID = string.Empty;
        private string boardingPassID = string.Empty;
        public BoardingPass() { }

        public BookedFlight BookedFlight
        {
            get => this.bookedFlight;
            set
            {
                this.bookedFlight = value;
                OnPropertyChanged(nameof(BookedFlight));
            }
        }

        public int GateNumber
        {
            get => this.gateNumber;
            set
            {
                this.gateNumber = value;
                OnPropertyChanged(nameof(GateNumber));
            }
        }

        public bool IsBoarded
        {
            get => this.isBoarded;
            set
            {
                this.isBoarded = value;
                OnPropertyChanged(nameof(IsBoarded));
            }
        }
        public string UserID
        {
            get => this.userID;
            set
            {
                this.userID = value;
                OnPropertyChanged(nameof(UserID));
            }
        }

        public string BoardingPassID
        {
            get => this.boardingPassID;
            set
            {
                this.boardingPassID = value;
                OnPropertyChanged(nameof(BoardingPassID));
            }
        }

    }
}
