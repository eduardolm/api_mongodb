using System;
using MongoDB.Driver.GeoJsonObjectModel;

namespace API.Data.Collection
{
    public class Infected
    {
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public GeoJson2DGeographicCoordinates Locale { get; set; }
        
        public Infected(DateTime birthday, string gender, double latitude, double longitude)
        {
            this.Birthday = birthday;
            this.Gender = gender;
            this.Locale = new GeoJson2DGeographicCoordinates(longitude, latitude);
        }
    }
}