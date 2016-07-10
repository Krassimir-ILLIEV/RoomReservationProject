namespace RoomReservationWPF.Contracts
{
    using System.Runtime.Serialization;
    using RoomReservationWPF.Common;
    using RoomReservationWPF.Models;

    internal interface IRegularEmployee : ISerializable
    {
        int EmployeeID { get; }

        string Title { get; }

        string Name { get; }

        EmployeePriorityType Priority { get; }

        Location EmployeeLocation { get; }
    }
}
