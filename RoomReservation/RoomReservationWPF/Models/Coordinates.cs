namespace RoomReservation.Models
{
    public class Coordinates
    {
        //private double latitude;
        //private double longitude;

        public Coordinates(double latitude, double longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        public double Latitude { get; private set; }

        public double Longitude { get; private set; }

        
    }
}