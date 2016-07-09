namespace RoomReservation.Models
{
    using System;

    public class MultimediaDevice
    {
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
                    throw new ArgumentException("Brightness must be greater than 0");
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
                    throw new ArgumentException("Suported screen size should be between 40 and 500 inches");
                }

                this.suportedScreenSize = value;
            }
        }
    }
}
