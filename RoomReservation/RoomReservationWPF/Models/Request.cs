using RoomReservationWPF.Models;
namespace RoomReservation.Models
{
    using RoomReservationWPF.Common;
    using RoomReservationWPF.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class Request:IRoom
    {       

        public Request(enumRoomTypes roomType, 
            int capacity, 
            List<MultimediaDevice> listMultimedia, 
            enumRentPriceRange rentPriceRange, Location location)
        {
            Room modelDesiredRoom = new Room();
        }

    }
}
