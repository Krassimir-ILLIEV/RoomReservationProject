using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomReservation.Models
{
    class Building
    {
        private int buildingID;
        private enumBuildingTypes buildingType;
        private enumBuildingLocation buildingLocation;
        private int capacity;
        private Coordinates coordianates;

        public enumBuildingTypes BuildingType
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

        public enumBuildingLocation BuildingLocation
        {
            get
            {
                return this.buildingLocation;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Location must be set!");
                }

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

        /*public Building(enumBuildingTypes buildingType,
        enumBuildingLocation buildingLocation,
        int capacity,
        Coordinates coordinates)
        {
            this.buildingType = BuildingType;
            this.buildingLocation = BuildingLocation;
            this.capacity = Capacity;
            */

    }
}
