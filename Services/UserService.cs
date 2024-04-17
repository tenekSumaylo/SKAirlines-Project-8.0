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
    public class UserService
    {
        private string filePath = FileSystem.Current.AppDataDirectory;

        public UserService( string fileName )
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

        public async Task<ObservableCollection<UserDomain>> GetUsers()
        {
            var info = new FileInfo(filePath);
            if (info.Length == 0)
                return new ObservableCollection<UserDomain>();

            string jsonString = await File.ReadAllTextAsync(filePath);
            var users = JsonSerializer.Deserialize<ObservableCollection<UserDomain>>(jsonString);
            return users;

        }

        public async void SaveToFile( ObservableCollection<UserDomain> users )
        {
            if (users == null)
                return;
            string jsonString = JsonSerializer.Serialize(users);
            await File.WriteAllTextAsync(filePath, jsonString);
        }
    }
}
