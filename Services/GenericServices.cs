using Microsoft.Maui.Controls.Platform;
using SKAirlines_Project.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SKAirlines_Project.Services
{
    public class GenericServices
    {
        private string filePath = FileSystem.Current.AppDataDirectory;

        public GenericServices() { }
        public GenericServices( string name )
        {
            filePath += name;
        }

        public async Task<ObservableCollection<Flight>> SearchFlights( string destination, string origin, DateTime theDate)
        {
            ObservableCollection<Flight> searchedFlights = new ObservableCollection<Flight>();
            var info = new FileInfo(filePath);
            if (info.Length == 0)
                return new ObservableCollection<Flight>();

            string jsonString = await File.ReadAllTextAsync(filePath);
            var flights = JsonSerializer.Deserialize<ObservableCollection<Flight>>(jsonString);
            foreach ( var k in flights )
            {
                if ( k.OriginPlace == origin && k.DestinationPlace == destination && k.FlightDate.Day == theDate.Day && k.FlightDate.Month == theDate.Month && k.FlightDate.Year == theDate.Year )
                {
                    searchedFlights.Add(k);
                }
            }
            return searchedFlights;

        }
    }
}
