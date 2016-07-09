namespace RoomReservation.Models
{
    using System;

    using RoomReservationWPF.Common;

    public class Building
    {
        private int buildingID;
        private EnumBuildingTypes buildingType;
        private EnumBuildingLocation buildingLocation;
        private int capacity;
        private int floors;
        private Coordinates coordianates;

        public Building()
        {
        }

        public Building(
            int buildingID,
        EnumBuildingLocation buildingLocation,
        EnumBuildingTypes buildingType,
        int capacity,
        int floors,
        Coordinates coordinates)
        {
            this.buildingID = BuildingID;
            this.buildingLocation = BuildingLocation;
            this.buildingType = BuildingType;
            this.capacity = Capacity;
            this.floors = Floors;
            this.coordianates = coordinates;
        }

        public int BuildingID
        {
            get
            {
                return this.buildingID;
            }
        }

        public EnumBuildingTypes BuildingType
        {
            get
            {
                return this.buildingType;
            }

            set
            {
                this.buildingType = value;
            }
        }

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

        public int Capacity
        {
            get
            {
                return capacity;
            }
        }

        public int Floors
        {
            get
            {
                return this.floors;
            }
        }

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
                this.capacity,
                Environment.NewLine,
                this.floors,
                Environment.NewLine,
                this.coordianates,
                Environment.NewLine);
        }
    }
}
