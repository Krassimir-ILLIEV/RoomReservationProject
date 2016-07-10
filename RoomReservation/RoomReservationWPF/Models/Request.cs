namespace RoomReservation.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using RoomReservationWPF.Common;
    using RoomReservationWPF.Contracts;
    using RoomReservationWPF.Exceptions;
    using RoomReservationWPF.Models;

    public class Request : IRoom
    {
        // Constants
        private const int MinCapacity = 0;
        private const int MinFloor = 0;

        private int capacity;
        private CapacityRangeType capacityRange;
        private int floor;
        private List<MultimediaDevice> listMultimedia;
        private Location location;
        private decimal rentPricePerHour;
        private RentPriceRangeType rentPriceRange;
        private EnumRoomTypes roomType;

        public Request(
            int capacity,
            CapacityRangeType capacityRange,
            int floor,
            List<MultimediaDevice> listMultimedia,
            Location location,
            decimal rentPricePerHour,
            RentPriceRangeType rentPriceRange,
            EnumRoomTypes roomType)
        {
            // Room modelDesiredRoom = new Room(roomType, capacity, listMultimedia, rentPriceRange, location);
            this.Capacity = capacity;
            this.CapacityRange = capacityRange;
            this.Floor = floor;
            this.ListMultimedia = listMultimedia;
            this.Location = location;
            this.RentPricePerHour = rentPricePerHour;
            this.RentPriceRange = rentPriceRange;
            this.RoomType = roomType;
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }

            set
            {
                if (value < 0)
                {
                    throw new RoomExceptions("Capacity must be greater then {0}", MinCapacity);
                }

                this.capacity = value;
            }
        }

        public CapacityRangeType CapacityRange
        {
            get
            {
                return this.capacityRange;
            }

            set
            {
                // implement validation if needed
                this.capacityRange = value;
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
                if (value < 0)
                {
                    throw new RoomExceptions("Floor must be greater then {0}", MinFloor);
                }

                this.floor = value;
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

        public decimal RentPricePerHour
        {
            get
            {
                return this.rentPricePerHour;
            }

            set
            {
                if (value < 0)
                {
                    throw new PricesException("RentPricePerHour must be greater then {0}", 1);
                }

                this.rentPricePerHour = value;
            }
        }

        public RentPriceRangeType RentPriceRange
        {
            get
            {
                return this.rentPriceRange;
            }

            set
            {
                // implement validation if needed
                this.rentPriceRange = value;
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
                // impelement validation if needed
                this.roomType = value;
            }
        }
    }
}
