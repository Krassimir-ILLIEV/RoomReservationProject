using System;

namespace RoomReservation.Models
{
        public class Coordinates
        {
            private double latitude;
            private double longitude;
            
            public double Latitude { get; private set; }
            public double Longitude { get; private set; }

            public Coordinates(double latitude, double longitude)
            {
                this.Latitude = latitude;
                this.Longitude = longitude;
            }


        //I am not sure how GeoCoordinate class works. Somebody can implement it
    }
}