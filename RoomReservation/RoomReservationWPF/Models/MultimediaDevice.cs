namespace RoomReservation.Models
{
    using System;

    using RoomReservationWPF.Exceptions;

    public class MultimediaDevice
    {
        private const int defaultBrightness = 0;
        private const int minScreenSize = 40;
        private const int maxScreenSize = 500;

        private string model;
        private int brightness;
        private int suportedScreenSize;

        public MultimediaDevice()
        {
        }

        public MultimediaDevice(string model, int brightness, int suportedScreen)
        {
            this.Model = model;
            this.Brightness = brightness;
            this.SuportedScreenSize = suportedScreen;
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                this.model = value;
            }
        }

        public int Brightness
        {
            get
            {
                return this.brightness;
            }

            set
            {
                if (value < 0)
                {
                    throw new MultimediaExceptions("Brightness must be greater than {0}", defaultBrightness);
                }

                this.brightness = value;
            }
        }

        public int SuportedScreenSize
        {
            get
            {
                return this.suportedScreenSize;
            }

            set
            {
                if (value < 40 || value > 500)
                {
                    throw new MultimediaExceptions("Suported screen size should be between {0} and {1} inches", minScreenSize, maxScreenSize);
                }

                this.suportedScreenSize = value;
            }
        }
    }
}
