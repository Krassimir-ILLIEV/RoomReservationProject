namespace RoomReservation.Models
{
    using System;

    using RoomReservationWPF.Common;

    public class Building
    {
        // Fields
        private int buildingID;
        private BuildingType buildingType;
        private BuildingLocationType buildingLocation;
        private int roomCount;
        private int floors;
        private Coordinates coordianates;

        // Constructor
        public Building(
        BuildingLocationType buildingLocation,
        BuildingType buildingType,
        int roomCount,
        int floors,
        Coordinates coordinates)
        {
            this.BuildingID = buildingID;
            this.BuildingLocation = buildingLocation;
            this.BuildingType = buildingType;
            this.RoomCount = roomCount;
            this.Floors = floors;
            this.Coordinate = coordinates;
        }

        // Properties
        public int BuildingID { get; private set; }

        public BuildingType BuildingType { get; private set; }
        
        public Coordinates Coordinate { get; private set; }

        public BuildingLocationType BuildingLocation { get; private set; }
        
        public int RoomCount { get; private set; }

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
                this.roomCount,
                Environment.NewLine,
                this.floors,
                Environment.NewLine,
                this.coordianates,
                Environment.NewLine);
        }
    }
}
