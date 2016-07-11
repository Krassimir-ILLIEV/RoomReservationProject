namespace RoomReservationWPF.Models.Employees
{
    using System;
    using System.Runtime.Serialization;
    using RoomReservationWPF.Common;
    using RoomReservationWPF.Contracts;

    [Serializable]
    public abstract class ChiefOfficer : DepartmentManager,IRegularEmployee, ISerializable
    {
        public ChiefOfficer(string name, string title, Location location, int yearsOfExperience, string unit, string department)
            : base(name, title, location, yearsOfExperience, unit, department)
        {
        }

        public ChiefOfficer(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public ChiefOfficer(string csvStr)
            :base(csvStr)
        {
        }

        public override EmployeePriorityType Priority
        {
            get
            {
                return EmployeePriorityType.UltraHigh;
            }
        }
    }
}
