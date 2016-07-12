
namespace RoomReservationWPF.Contracts
{
    using System.Runtime.Serialization;
    using RoomReservationWPF.Common;
    using RoomReservationWPF.Models;

    internal interface IDepartmentManager: ISerializable
    {
        string Department { get; }
    }
}
