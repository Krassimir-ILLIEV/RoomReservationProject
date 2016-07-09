namespace RoomReservationWPF.Exceptions
{
    using System;


    public class MultimediaExceptions : ApplicationException
    {

       public MultimediaExceptions (string message) : base(message)
        {
        }

        public MultimediaExceptions(string message, int minScreenm, int maxScreen ) : this(message)
        {
            this.MinScreen = minScreenm;
            this.MaxScreen = maxScreen;
        }

        public MultimediaExceptions(string message, int defaultBrightness) : this(message)
        {
            this.DefaultBrightness = defaultBrightness;
          
        }

        public int DefaultBrightness { get; set; }
        public int MinScreen { get; set; }
        public int MaxScreen { get; set; }
    }
}
