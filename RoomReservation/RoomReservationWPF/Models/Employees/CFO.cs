namespace RoomReservationWPF.Models.Employees
{
    using System;
    using System.Runtime.Serialization;
    using System.Text;
    using RoomReservationWPF.Common;
    using RoomReservationWPF.Contracts;

    [Serializable]
    public class CFO : DepartmentManager, IRegularEmployee, ISerializable
    {
        public CFO(string name, string title, Location location, int yearsOfExperience, string unit, string department)
            : base(name, title, location, yearsOfExperience, unit, department)
        {
        }

        public CFO(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public CFO(string csvStr)
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
