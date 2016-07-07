using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using RoomReservationWPF.Common;
using RoomReservationWPF.Models;

namespace RoomReservationWPF.Contracts
{
    interface IRegularEmployee: ISerializable
    {
        int EmployeeID { get; }
        string Title { get; }
        string Name { get; }
        enumEmployeePriority Priority { get; }
        Location EmployeeLocation { get; }
    }
}
