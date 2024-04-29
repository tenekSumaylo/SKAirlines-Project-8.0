using SKAirlines_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAirlines_Project.ServiceModel
{
    public class DataPasser
    {
        public UserDomain TheUser { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string ReturnOrigin { get; set; }
        public string ReturnDestination { get; set; }
        public DateTime OneWay { get; set;}
        public DateTime TwoWay { get; set;}
        public bool IsRoundTrip {  get; set;}
        public DataPasser() { }
        public DataPasser( UserDomain theUser,string origin, string destination, DateTime oneway, DateTime twoway, bool roundtrip )
        {
            TheUser = theUser;
            Origin = origin;
            Destination = destination;
            OneWay = oneway;
            TwoWay = twoway;
            IsRoundTrip = roundtrip;
        }

        public DataPasser( UserDomain theUser,string origin, string destination, DateTime oneway, DateTime twoway, bool roundtrip, string returnDestination, string returnOrigin)
        {
            TheUser = theUser;
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
