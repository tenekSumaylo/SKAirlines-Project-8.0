using SKAirlines_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAirlines_Project
{
    public class ClassPics : BaseModel
    {
        public ClassPics() { }
        public ClassPics( string url )
        {
            ImageUrl = url;
        }
        private string imageUrl;

        public string ImageUrl
        {
            get => imageUrl;
            set
            {
                imageUrl = value;
                OnPropertyChanged( nameof( ImageUrl) );
            }
        }
    }
}
