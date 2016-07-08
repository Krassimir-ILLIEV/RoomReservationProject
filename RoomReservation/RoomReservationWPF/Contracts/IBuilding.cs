//Need some guidelines about this interface
using RoomReservation.Models;

namespace RoomReservation.Contracts
{
    interface IBuilding
    {

        enumBuildingTypes BuildingType { get; set; }

        enumBuildingLocation BuildingLocation { get; set; }

        int Capacity { get; set; }

        int Floors { get; set; }

        Coordinates coordinates { get; set; }
    }
}
