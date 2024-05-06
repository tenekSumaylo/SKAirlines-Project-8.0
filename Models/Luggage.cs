using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAirlines_Project.Models
{
    public class Luggage : BaseModel
    {
        private string luggageID = string.Empty;
        private string flightID;
        private double luggageWeight;
        private int sequenceNumber;
        private double chargePerLuggage;

        public Luggage( string id, string theFlight, double weight, int sequence, double charge)
        {
            LuggageID = id;
            FlightID = theFlight;
            LuggageWeight = weight;
            SequenceNumber = sequence;
            ChargePerLuggage = charge;
        }

        public string LuggageID
        {
            get => this.luggageID;
            set
            {
                this.luggageID = value;
                OnPropertyChanged( nameof(LuggageID ) );    
            }
        }

        public string FlightID
        {
            get => this.flightID;
            set
            {
                this.flightID = value;
                OnPropertyChanged( nameof( FlightID ) );
            }
        }
        
        public double LuggageWeight
        {
            get => this.luggageWeight;
            set
            {
                this.luggageWeight = value;
                OnPropertyChanged( nameof(LuggageWeight ) );
            }
        } 
        
        public int SequenceNumber
        {
            get => this.sequenceNumber;
            set
            {
                this.sequenceNumber = value;
                OnPropertyChanged( nameof( SequenceNumber ) );
            }
        }

        public double ChargePerLuggage
        {
            get => this.chargePerLuggage;
            set
            {
                this.chargePerLuggage = value;
                OnPropertyChanged(nameof(ChargePerLuggage) );
            }
        }

        public void ClearAll()
        {
            LuggageID = string.Empty;
            LuggageWeight = -1;
            ChargePerLuggage = -1;
            SequenceNumber = -1;
        }

        public Luggage SaveLuggage() => new Luggage( LuggageID, FlightID, LuggageWeight, SequenceNumber, ChargePerLuggage );
        
    }
}
