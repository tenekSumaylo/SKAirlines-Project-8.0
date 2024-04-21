using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAirlines_Project.ServiceModel
{
    public class DataPasser
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string ReturnOrigin { get; set; }
        public string ReturnDestination { get; set; }
        public DateTime OneWay { get; set;}
        public DateTime TwoWay { get; set;}
        public bool IsRoundTrip {  get; set;}
        public DataPasser() { }
        public DataPasser( string origin, string destination, DateTime oneway, DateTime twoway, bool roundtrip )
        {
            Origin = origin;
            Destination = destination;
            OneWay = oneway;
            TwoWay = twoway;
            IsRoundTrip = roundtrip;
        }

        public DataPasser(string origin, string destination, DateTime oneway, DateTime twoway, bool roundtrip, string returnDestination, string returnOrigin)
        {
            Origin = origin;
            Destination = destination;
            OneWay = oneway;
            TwoWay = twoway;
            IsRoundTrip = roundtrip;
            ReturnOrigin = returnOrigin;
            ReturnDestination = returnDestination;
        }
    }
}
