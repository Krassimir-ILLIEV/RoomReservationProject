namespace RoomReservationWPF.Models.Employees
{
    using System;
    using System.Runtime.Serialization;
    using System.Text;

    using RoomReservationWPF.Common;
    using RoomReservationWPF.Contracts;

    [Serializable]
    public class CIO : DepartmentManager, IRegularEmployee, ISerializable
    {
        public CIO(string name, string title, Location location, int yearsOfExperience, string unit, string department)
            : base(name, title, location, yearsOfExperience, unit, department)
        {
        }

        public CIO(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public CIO(string csvStr)
            :base(csvStr)
        {
        }

        // additional property
        public override EmployeePriorityType Priority
        {
            get
            {
                return EmployeePriorityType.UltraHigh;
            }
        }
    }
}
