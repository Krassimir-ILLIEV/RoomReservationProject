namespace RoomReservation.Models
{
    using System;

    using RoomReservationWPF.Common;

    public class Building
    {
        // Fields
        private int buildingID;
        private EnumBuildingTypes buildingType;
        private EnumBuildingLocation buildingLocation;
        private int roomCount;
        private int floors;
        private Coordinates coordianates;

        // Constructor
        public Building(
            int buildingID,
        EnumBuildingLocation buildingLocation,
        EnumBuildingTypes buildingType,
<<<<<<< HEAD
        int capacity,
=======
        int roomCount,
>>>>>>> master
        int floors,
        Coordinates coordinates)
        {
            this.BuildingID = buildingID;
            this.BuildingLocation = buildingLocation;
            this.BuildingType = buildingType;
<<<<<<< HEAD
            this.Capacity = capacity;
            this.Floors = floors;
            this.Coordinates = coordinates;
        }

        public Coordinates Coordinates { get; set; }

        public int BuildingID { get; set; }
=======
            this.RoomCount = roomCount;
            this.Floors = floors;
            this.Coordinate = coordinates;
        }

        // Properties
        public int BuildingID { get; private set; }
>>>>>>> master

        public EnumBuildingTypes BuildingType { get; private set; }
        
        public Coordinates Coordinate { get; private set; }

<<<<<<< HEAD
        public EnumBuildingLocation BuildingLocation
        {
            get
            {
                return this.buildingLocation;
            }

            set
            {
                this.buildingLocation = value;
            }
        }

        public int Capacity { get; set; }

        public int Floors { get; set; }
=======
        public EnumBuildingLocation BuildingLocation { get; private set; }
        
        public int RoomCount { get; private set; }
>>>>>>> master

        public int Floors { get; private set; }
        
        public override string ToString()
        {
            return string.Format(
                "Building Id: {0}{1} Location: {2}{3} Type: {4}{5} Capacity: {6}{7} Floors: {8}{9} Coordinates: {10}{11}",
                this.buildingID,
                Environment.NewLine,
                this.buildingLocation,
                Environment.NewLine,
                this.buildingType,
                Environment.NewLine,
<<<<<<< HEAD
                this.capacity,
=======
                this.roomCount,
>>>>>>> master
                Environment.NewLine,
                this.floors,
                Environment.NewLine,
                this.coordianates,
                Environment.NewLine);
        }
    }
}
