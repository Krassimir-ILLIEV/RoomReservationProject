namespace RoomReservation.Models
{
    using System;
    using System.Collections.Generic;
    using RoomReservationWPF.Exceptions;
    using RoomReservationWPF.Common;
    using RoomReservationWPF.Contracts;
    using RoomReservationWPF.Models;

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
        private EnumCapacityRange capacityRange;
        private EnumRentPriceRange rentPriceRange;
        private decimal rentPricePerHour;
        private Location location;

        public Room(
            int capacity,
            int floor,
            List<MultimediaDevice> listMultimedia,
        EnumRoomTypes roomType,
        EnumCapacityRange capacityRnage,
        EnumRentPriceRange rentPriceRnage,
        decimal rentPricePerHour,
        Location location)
        {
            this.roomID = RoomId;
            this.capacity = Capacity;
            this.floor = Floor;
            this.listMultimedia = ListMultimedia;
            this.roomType = RoomType;
            this.capacityRange = CapacityRange;
            this.rentPriceRange = RentPriceRange;
            this.rentPricePerHour = RentPricePerHour;
            this.location = Location;
            this.roomID = roomIdGenerator;
            roomIdGenerator++;
        }

        public Room()
        {
        }

        public int RoomId
        {
            get
            {
                return this.roomID;
            }
        }

        public EnumCapacityRange CapacityRange
        {
            get
            {
                return this.capacityRange;
            }

            set
            {
                this.capacityRange = value;
            }
        }

        public EnumRoomTypes RoomType
        {
            get
            {
                return this.roomType;
            }

            set
            {
                this.roomType = value;
            }
        }

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

        public EnumRentPriceRange RentPriceRange
        {
            get
            {
                return this.rentPriceRange;
            }

            set
            {
                this.rentPriceRange = value;
            }
        }

        public decimal RentPricePerHour
        {
            get
            {
                return this.rentPricePerHour;
            }

            set
            {
                this.rentPricePerHour = value;
            }
        }

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

        public override string ToString()
        {
            return string.Format("Room Id: {0}{1}Capacity: {2}{3}Floor: {4}{5}", this.roomID, Environment.NewLine, this.capacity, Environment.NewLine, this.floor, Environment.NewLine);
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