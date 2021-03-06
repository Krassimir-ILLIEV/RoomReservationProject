﻿namespace RoomReservationWPF.Contracts
{
    using System.Collections.Generic;

    // using RoomReservation.Models;
    using RoomReservationWPF.Common;
    using RoomReservationWPF.Models;

    internal interface IRoom
    {
        CapacityRangeType CapacityRange { get; set; }

        // add corresponding fields
        RoomType RoomTypeProp { get; set; }

        int Capacity { get; set; }

        List<MultimediaDevice> ListMultimedia { get; set; }

        RentPriceRangeType RentPriceRangeTypeProp { get; set; }

        decimal RentPricePerHour { get; set; }

        Location Location { get; set; }

        int Floor { get; set; }

        /* - roomId;
- roomType (conference, cinema,etc, type Enum);
- capacity (in terms of people);
- list(MultimediaDevice) //some inheritance here, perhaps //PATTERN COMPOSITE
- rentPerHour //rent that depends on time of day so that analysis and optimizations could be made;
- rentPriceCategory (derived from rentPerHour, e.g. price category 1,2,3,4 having some ranges);
- location (type Building);
- floor;
        */
    }
}
