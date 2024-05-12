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
    public class AdminService
    {
        private string filePath = FileSystem.Current.AppDataDirectory;

        public AdminService(string fileName)
        {
            filePath += fileName;
            CheckOrCreateFile();
        }

        public void CheckOrCreateFile()
        {
            if (File.Exists(filePath))
                return;
            File.Create(filePath);
        }

        public async Task<ObservableCollection<Flight>> GetFlights()
        {
            var info = new FileInfo(filePath);
            if (info.Length == 0)
                return new ObservableCollection<Flight>();

            string jsonString = await File.ReadAllTextAsync(filePath);
            var flights = JsonSerializer.Deserialize<ObservableCollection<Flight>>(jsonString);
            return flights;

        }

        public async Task<int> GetNumberOfFLights()
        {
            var info = new FileInfo(filePath);
            return (int)info.Length/1024;
        }
        public async void SaveToFile(ObservableCollection<Flight> flights)
        {
            if (flights == null)
                return;
            string jsonString = JsonSerializer.Serialize(flights);
            await File.WriteAllTextAsync(filePath, jsonString);
        }

        public void DeleteFile()
        {
            File.Delete(filePath);
        }
    }
}
