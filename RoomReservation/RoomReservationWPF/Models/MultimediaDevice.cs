namespace RoomReservationWPF.Models
{
    using System;

    using RoomReservationWPF.Exceptions;
    using System.Runtime.Serialization;
    using RoomReservationWPF.Common;
    using System.Collections.Generic;

    [Serializable]
    public class MultimediaDevice : ISerializable
    {
        private const int defaultBrightness = 0;
        private const int minScreenSize = 40;
        private const int maxScreenSize = 500;

        private string model;
        private int brightness;
        private int suportedScreenSize;
        private MultimediaType mType;

        public MultimediaDevice()
        {
        }
        public MultimediaDevice(SerializationInfo info, StreamingContext context)
        {
            this.model = (string)info.GetValue("model", typeof(string));
            this.brightness = (int)info.GetValue("brightness", typeof(int));
            this.suportedScreenSize = (int)info.GetValue("suportedScreenSize", typeof(int));
            this.mType = (MultimediaType)info.GetValue("mType", typeof(MultimediaType));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("model", this.model, typeof(string));
            info.AddValue("brightness", this.brightness, typeof(int));
            info.AddValue("suportedScreenSize", this.suportedScreenSize, typeof(int));
            info.AddValue("mType", this.mType, typeof(MultimediaType));
        }
        public static List<MultimediaDevice> createListMMD(string csvStr)
        {
            List<MultimediaDevice> listMMD = null;
            //csvStr = csvStr.Replace("[", "").Replace("]", "");
            string[] scvMMDs = csvStr.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (scvMMDs.Length != 0)
            {
                listMMD = new List<MultimediaDevice>();
                foreach (string scvMMD in scvMMDs)
                {
                    listMMD.Add(new MultimediaDevice(scvMMD));
                }

            }
            return listMMD;
        }
        public MultimediaDevice(string csvStr)
        {
            csvStr = csvStr.Replace("{", "").Replace("}", "");
            string[] Data = csvStr.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            this.MType = ClassGeneral.GetEnumByName<MultimediaType>(Data[0]);
            this.Model = Data[1];
            this.Brightness = int.Parse(Data[2]);
            this.SuportedScreenSize = int.Parse(Data[3]);
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
                    throw new MultimediaExceptions(string.Format("Brightness must be greater than {0}", defaultBrightness));
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
                    throw new MultimediaExceptions(string.Format("Suported screen size should be between {0} and {1} inches", minScreenSize, maxScreenSize));
                }

                this.suportedScreenSize = value;
            }
        }
        public MultimediaType MType
        {
            get
            {
                return this.mType;
            }
            set
            {
                this.mType = value;
            }
        }
        public override string ToString()
        {
            return string.Format("Type: {0}; Model: {1}; Brightness: {2}; SuportedScreenSize: {3}",
             this.MType, this.Model, this.Brightness, this.SuportedScreenSize);
        }
    }
}
