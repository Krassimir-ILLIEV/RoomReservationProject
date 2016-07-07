namespace RoomReservation.Models
{
    using RoomReservationWPF.Common;
    using RoomReservationWPF.Contracts;
    using RoomReservationWPF.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Room : IRoom
    {
        private static int roomIdGenerator = 1;
        private readonly int roomID;
        private int capacity;
        private int floor;
        private List<MultimediaDevice> listMultimedia;
        private enumRoomTypes roomType;
        private enumCapacityRange capacityRange;
        private enumRentPriceRange rentPriceRange;
        private decimal rentPricePerHour;
        private Location location;

        public Room()
        {
        }

        public Room(int capacity, int floor, List<MultimediaDevice> listMultimedia,
        enumRoomTypes roomType, enumCapacityRange capacityRnage, enumRentPriceRange rentPriceRnage,
        decimal rentPricePerHour, Location location)
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

        public int RoomId
        {
            get
            {
                return this.roomID;
            }
        }

        public enumCapacityRange CapacityRange
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

        public enumRoomTypes RoomType
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
                if (value < 0)
                {
                    throw new ArgumentException("Capacity must be greater then 0");
                }
                else if (value > 500)
                {
                    throw new ArgumentException("Capacity must be less than 500");
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
                    throw new ArgumentNullException("List of multimedia divices must be set!");
                }

                this.listMultimedia = value;
            }
        }

        public enumRentPriceRange RentPriceRange
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
                if (value < 0)
                {
                    throw new ArgumentException("Floor must be greater then 0");
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
                    throw new ArgumentNullException("Location must be set!");
                }

                this.location = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Room Id: {0}{1}Capacity: {2}{3}Floor: {4}{5}",
            this.roomID, Environment.NewLine, this.capacity, Environment.NewLine, this.floor, Environment.NewLine);
        }
        /*roomId;
-	roomType (conference, cinema,etc, type Enum);
-	capacity (in terms of people);
-	list(MultimediaDevice) //some inheritance here, perhaps //PATTERN COMPOSITE
-	rentPerHour //rent that depends on time of day so that analysis and optimizations could be made;
-	rentPriceCategory (derived from rentPerHour, e.g. price category 1,2,3,4 having some ranges);
-	location (type Building);
-	floor;
-	ToString(); //prints all information about a room.
*/
    }


}