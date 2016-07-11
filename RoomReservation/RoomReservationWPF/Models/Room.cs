namespace RoomReservationWPF.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using RoomReservationWPF.Exceptions;
    using RoomReservationWPF.Common;
    using RoomReservationWPF.Contracts;
    using RoomReservationWPF.Models;
    using System.Text;
    using System.Runtime.Serialization;

    [Serializable]
    public class Room : IRoom, ISerializable
    {
        // Constants
        private const int MinCapacity = 0;
        private const int MaxCapacity = 500;
        private const int MinFloor = 0;
        private const int MaxFloor = 13;

        private static int roomIdGenerator = 1;
        private int roomID;
        private int capacity;
        private int floor;
        private List<MultimediaDevice> listMultimedia;
        private RoomType roomType;
        private CapacityRangeType capacityRange;
        private RentPriceRangeType rentPriceRangeType;
        private decimal rentPricePerHour;
        private Location location;
        private int lastScore;

        public Room(SerializationInfo info, StreamingContext context)
        {
            this.rentPricePerHour = (decimal)info.GetValue("rentPricePerHour", typeof(decimal));
            this.capacity = (int)info.GetValue("capacity", typeof(int));
            this.floor = (int)info.GetValue("floor", typeof(int));
            this.roomType = (RoomType)info.GetValue("roomType", typeof(RoomType));
            this.capacityRange = (CapacityRangeType)info.GetValue("capacityRange", typeof(CapacityRangeType));
            this.rentPriceRangeType = (RentPriceRangeType)info.GetValue("rentPriceRangeType", typeof(RentPriceRangeType));
            //this.listMultimedia = new List<MultimediaDevice>();
            this.listMultimedia = (List<MultimediaDevice>)info.GetValue("listMultimedia", typeof(List<MultimediaDevice>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("rentPricePerHour", this.rentPricePerHour, typeof(decimal));
            info.AddValue("capacity", this.capacity, typeof(int));
            info.AddValue("floor", this.floor, typeof(int));
            info.AddValue("roomType", this.roomType, typeof(RoomType));
            info.AddValue("capacityRange", this.capacityRange, typeof(CapacityRangeType));
            info.AddValue("rentPriceRangeType", this.rentPriceRangeType, typeof(RentPriceRangeType));
            info.AddValue("listMultimedia", this.listMultimedia, typeof(List<MultimediaDevice>));
        }

        private void RoomInit(int capacity, int floor, List<MultimediaDevice> listMultimedia,
        RoomType roomType, CapacityRangeType capacityRange, RentPriceRangeType RentPriceRangeType,
        decimal rentPricePerHour, Location location)
        {
            this.Capacity = capacity;
            this.Floor = floor;
            this.ListMultimedia = listMultimedia;
            this.RoomTypeProp = roomType;
            this.CapacityRange = capacityRange;
            this.RentPriceRangeTypeProp = RentPriceRangeType;
            this.RentPricePerHour = rentPricePerHour;
            this.Location = location;
            this.RoomID = roomIdGenerator++;
        }

        public Room(string csvStr)
        {
            string[] temp = csvStr.Split(new[] { '[', ']' });
            csvStr = temp[0] + temp[2].Remove(0, 1).Trim(); //first ","
            string[] RoomData = csvStr.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            RoomType eRoomType = ClassGeneral.GetEnumByName<RoomType>(RoomData[2]);
            CapacityRangeType eCapacityRange = ClassGeneral.GetEnumByName<CapacityRangeType>(RoomData[3]);
            RentPriceRangeType eRentPriceRangeType = ClassGeneral.GetEnumByName<RentPriceRangeType>(RoomData[4]);

            RoomInit(int.Parse(RoomData[0]),
                int.Parse(RoomData[1]),
                MultimediaDevice.createListMMD(temp[1]),
            eRoomType, eCapacityRange, eRentPriceRangeType,
            decimal.Parse(RoomData[5]), new Location());
        }

        public Room(int capacity, int floor, List<MultimediaDevice> listMultimedia,
        RoomType roomType, CapacityRangeType capacityRnage, RentPriceRangeType rentPriceRange,
        decimal rentPricePerHour, Location location)
        {
            RoomInit(capacity, floor, listMultimedia, roomType, capacityRange, rentPriceRange, rentPricePerHour, location);
        }

        public decimal CalculatedPrice //depends on duration
        {
            get
            {
                return this.RentPricePerHour * (decimal)(MainWindow.EventDuration / 60.0);
            }
        }

        public string CalculatedMedia //depends on choice
        {
            get
            {
                return (this.isMultimediaAvailable(MainWindow.MMDType) ? "Yes" : "No");
            }
        }

        public int RoomID { 
            get { return this.roomID; }
            private set {this.roomID = value; }
        }

        public CapacityRangeType CapacityRange { get; set; }

        public RoomType RoomTypeProp { get; set; }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }

            set
            {
                if (value < MinCapacity)
                {
                    throw new RoomExceptions(string.Format("Capacity must be equal or more then {0}", MinCapacity));
                }
                else if (value > MaxCapacity)
                {
                    throw new RoomExceptions(string.Format("Capacity must be less than {0}", MaxCapacity));
                }

                this.capacity = value;
            }
        }

        public string MMDListToPrint()
        {
            string str = "[";
            if (this.listMultimedia != null)
            {
                foreach (MultimediaDevice MMD in this.listMultimedia)
                {
                    str += "{" + MMD.ToString() + "},";
                }
                str = str.Remove(str.Length - 1);
            }
            return str + "]";
        }

        public List<MultimediaDevice> ListMultimedia
        {
            get
            {
                return this.listMultimedia;
            }

            set
            {
                if (value == null)
                {
                    //throw new RoomExceptions("List of multimedia divices must be set!");
                }

                this.listMultimedia = value;
            }
        }

        public RentPriceRangeType RentPriceRangeTypeProp { get; set; }

        public decimal RentPricePerHour { get; set; }

        public int Floor
        {
            get
            {
                return this.floor;
            }

            set
            {
                if (value < MinFloor)
                {
                    throw new RoomExceptions(string.Format("Floor must be greater then {0}", MinFloor));
                }
                else if (value > MaxFloor)
                {
                    throw new RoomExceptions(string.Format("Floor must be smaller then {0}", MaxFloor));
                }

                this.floor = value;
            }
        }

        public Location Location
        {
            get
            {
                return this.location;
            }

            set
            {
                if (value == null)
                {
                    throw new RoomExceptions("Location must be set!");
                }

                this.location = value;
            }
        }

      
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine(string.Format("Room ID: {0}", this.roomID));
            sb.AppendLine(string.Format("Capacity: {0}", this.Capacity));
            sb.AppendLine(string.Format("Floor: {0}", this.Floor));
            sb.AppendLine(string.Format("Multimedia: {0}", this.ListMultimedia));
            sb.AppendLine(string.Format("Room Type: {0}", this.RoomTypeProp));
            sb.AppendLine(string.Format("Capacity range: {0}", this.CapacityRange));
            sb.AppendLine(string.Format("Rent price range: {0}", this.RentPriceRangeTypeProp));
            sb.AppendLine(string.Format("Rent price per hour: {0}", this.RentPricePerHour));
            sb.AppendLine(string.Format("Location: {0}", this.Location));
            return sb.ToString();
        }

        private bool isMultimediaAvailable(MultimediaType multimediaType)
        {
            if (this.ListMultimedia != null)
            {
                if (this.ListMultimedia.Where(m => m.MType == multimediaType).FirstOrDefault() != null)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsCompatible(Request request)
        {
            bool result = false;
            if (request.RoomTypeProp != RoomType.not_selected && this.RoomTypeProp != request.RoomTypeProp)
            {
                return result;
            }

            if (request.RentPriceRangeTypeProp != RentPriceRangeType.not_selected)
            {
                if ((double)this.RentPricePerHour * request.Occupation.DurationMin / 60.0 > (int)request.RentPriceRangeTypeProp)
                {
                    return result;
                }
            }

            if (request.CapacityRange != CapacityRangeType.not_selected && this.CapacityRange < request.CapacityRange)
            {
                return result;
            }

            if (request.MultimediaTypeProp != MultimediaType.not_selected && !isMultimediaAvailable(request.MultimediaTypeProp))
            {
                return result;

            }
            return true;
        }
        public int ScoreCompatible(Request request)
        {
            int result = 0;
            if (this.RoomTypeProp == request.RoomTypeProp)
            {
                result += request.RoomTypePriority;
            }

            if (request.RentPriceRangeTypeProp != RentPriceRangeType.not_selected)
            {
                if ((double)this.RentPricePerHour * request.Occupation.DurationMin / 60.0 <= (int)request.RentPriceRangeTypeProp)
                {
                    result += request.RentPriceRangePriority;
                }
            }

            if (request.CapacityRange != CapacityRangeType.not_selected && this.CapacityRange > request.CapacityRange)
            {
                result += request.CapacityRangePriority;
            }

            if (request.MultimediaTypeProp != MultimediaType.not_selected && isMultimediaAvailable(request.MultimediaTypeProp))
            {
                result += request.MultimediaTypePriority;

            }

            lastScore = result;
            return result;
        }

        public int Score
        {
            get { return this.lastScore; }
        }

        /* roomId;
- roomType (conference, cinema,etc, type Enum);
- capacity (in terms of people);
- list(MultimediaDevice) //some inheritance here, perhaps //PATTERN COMPOSITE
- rentPerHour //rent that depends on time of day so that analysis and optimizations could be made;
- rentPriceCategory (derived from rentPerHour, e.g. price category 1,2,3,4 having some ranges);
- location (type Building);
- floor;
- ToString(); //prints all information about a room.
*/
    }
}