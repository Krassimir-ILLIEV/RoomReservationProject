namespace RoomReservation.Models
{
    using System;
    using System.Collections.Generic;
    using RoomReservationWPF.Exceptions;
    using RoomReservationWPF.Common;
    using RoomReservationWPF.Contracts;
    using RoomReservationWPF.Models;
    using System.Text;

    internal class Room : IRoom
    {
        // Constants
        private const int MinCapacity = 0;
        private const int MaxCapacity = 500;
        private const int MinFloor = 0;
        private const int MaxFloor = 13;

        private static int roomIdGenerator = 1;
        private readonly int roomID;
        private int capacity;
        private int floor;
        private List<MultimediaDevice> listMultimedia;
        private EnumRoomTypes roomType;
        private CapacityRangeType capacityRange;
        private RentPriceRangeType rentPriceRange;
        private decimal rentPricePerHour;
        private Location location;

        public Room(
            int capacity,
            int floor,
            List<MultimediaDevice> listMultimedia,
        EnumRoomTypes roomType,
        CapacityRangeType capacityRnage,
        RentPriceRangeType rentPriceRnage,
        decimal rentPricePerHour,
        Location location)
        {
            this.roomID = roomId;
            this.Capacity = capacity;
            this.Floor = floor;
            this.ListMultimedia = listMultimedia;
            this.RoomType = roomType;
            this.CapacityRange = capacityRange;
            this.RentPriceRange = rentPriceRange;
            this.RentPricePerHour = rentPricePerHour;
            this.Location = location;
            this.RoomID = roomIdGenerator;
            roomIdGenerator++;
        }

        public int roomId { get; private set; }

        public CapacityRangeType CapacityRange { get; set; }

        public EnumRoomTypes RoomType { get; set; }

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
                    throw new RoomExceptions("Capacity must be equal or more then {0}", MinCapacity);
                }
                else if (value > MaxCapacity)
                {
                    throw new RoomExceptions("Capacity must be less than {0}", MaxCapacity);
                }

                this.capacity = value;
            }
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
                    throw new RoomExceptions("List of multimedia divices must be set!");
                }

                this.listMultimedia = value;
            }
        }

        public RentPriceRangeType RentPriceRange { get; set; }

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
                    throw new RoomExceptions("Floor must be greater then {0}", MinFloor);
                }
                else if (value > MaxFloor)
                {
                    throw new RoomExceptions("Floor must be smaller then {0}", MaxFloor);
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

        public int RoomID { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine(string.Format("Room ID: {0}", this.roomId));
            sb.AppendLine(string.Format("Capacity: {0}", this.Capacity));
            sb.AppendLine(string.Format("Floor: {0}", this.Floor));
            sb.AppendLine(string.Format("Multimedia: {0}", this.ListMultimedia));
            sb.AppendLine(string.Format("Room Type: {0}", this.RoomType));
            sb.AppendLine(string.Format("Capacity range: {0}", this.CapacityRange));
            sb.AppendLine(string.Format("Rent price range: {0}", this.RentPriceRange));
            sb.AppendLine(string.Format("Rent price per hour: {0}", this.RentPricePerHour));
            sb.AppendLine(string.Format("Location: {0}", this.Location));
            return sb.ToString();
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