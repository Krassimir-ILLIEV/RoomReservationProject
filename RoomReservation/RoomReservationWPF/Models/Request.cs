
namespace RoomReservationWPF.Models
{
    using RoomReservationWPF.Common;
    using RoomReservationWPF.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Request : IRoom
    {
        private int capacity;
        private int floor;
        private List<MultimediaDevice> listMultimedia;
        private Location location;
        private decimal rentPricePerHour;
        private RoomType roomType;
        private RentPriceRangeType rentPriceRange;
        private CapacityRangeType capacityRange;
        private MultimediaType multimediaType;
        public int RoomTypePriority { get; set; }
        public int RentPriceRangePriority { get; set; }
        public int CapacityRangePriority { get; set; }
        public int MultimediaTypePriority { get; set; }
        public Request(DateTime beginTime, int durationMin)
        {
            this.Occupation = new Timeslot(beginTime, durationMin);
        }
        public Request(DateTime beginTime, int durationMin, RoomType roomType, RentPriceRangeType rentPriceRange, CapacityRangeType capacityRange, MultimediaType multimediaType,
            int roomTypePriority = 1, int rentPriceRangePriority = 1, int capacityRangePriority = 1, int multimediaTypePriority = 1)
        {
            this.Occupation = new Timeslot(beginTime, durationMin);
            this.RoomTypeProp = roomType;
            this.RentPriceRangeTypeProp = rentPriceRange;
            this.CapacityRange = capacityRange;
            this.MultimediaTypeProp = multimediaType;
            this.RoomTypePriority = roomTypePriority;
            this.RentPriceRangePriority = rentPriceRangePriority;
            this.CapacityRangePriority = capacityRangePriority;
            this.MultimediaTypePriority = multimediaTypePriority;
        }

        public Request(
            DateTime beginTime, int durationMin,
            int capacity,
            CapacityRangeType capacityRange,
            int floor,
            List<MultimediaDevice> listMultimedia,
            Location location,
            decimal RentPricePerHour,
            RentPriceRangeType rentPriceRange,
            RoomType roomType)
        {
            //Room modelDesiredRoom = new Room(roomType, capacity, listMultimedia, rentPriceRange, location);
            this.Occupation = new Timeslot(beginTime, durationMin);
            this.Capacity = capacity;
            this.CapacityRange = capacityRange;
            this.Floor = floor;
            this.ListMultimedia = listMultimedia;
            this.Location = location;
            this.RentPricePerHour = rentPricePerHour;
            this.RentPriceRangeTypeProp = rentPriceRange;
            this.RoomTypeProp = roomType;
        }

        public Timeslot Occupation { get; set; }
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
                    throw new ArgumentException("Capacity must be greater then 0");
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
                    throw new ArgumentException("Floor must be greater then 0");
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
                    throw new ArgumentNullException("List of multimedia divices must be set!");
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
                    throw new ArgumentNullException("Location must be set!");
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
                    throw new ArgumentException("RentPricePerHour must be greater then zero");
                }

                this.rentPricePerHour = value;
            }
        }

         public RentPriceRangeType RentPriceRangeTypeProp
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

        public RoomType RoomTypeProp
        {
            get
            {
                return this.roomType;
            }

            set
            {
                //impelement validation if needed
                this.roomType = value;
            }
        }
        public MultimediaType MultimediaTypeProp
        {
            get
            {
                return this.multimediaType;
            }

            set
            {
                //impelement validation if needed
                this.multimediaType = value;
            }
        }
    }
}
