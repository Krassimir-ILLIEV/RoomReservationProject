

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
    class Room:IRoom
    {
        private static int roomIdGenerator = 1;
        private readonly int roomID;
        private enumRoomTypes roomType;

        public Room()
        {
           //for model room
        }

        public Room(enumRoomTypes roomType, 
            int capacity, 
            List<MultimediaDevice> listMultimedia, 
            enumRentPriceRange rentPriceRange,
            Location location)
        {
            this.roomID = (roomIdGenerator++); //assigns current value to id and increments roomIdGen for next call
        }

        public int RoomId 
        {
            get
            {
                return this.roomID;
            }
        } //set in constructor
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
