namespace RoomReservationWPF.Models.Employees
{
    using System;
    using System.Runtime.Serialization;
    using System.Text;

    using RoomReservationWPF.Common;
    using RoomReservationWPF.Contracts;

    [Serializable]
    public class CEO : DepartmentManager, IRegularEmployee, ISerializable
    {
        public CEO() : base()
        {
            // default
        }

        public CEO(string name, string title, Location location, int yearsOfExperience, string unit, string department)
            : base(name, title, location, yearsOfExperience, unit, department)
        {
        }

        public CEO(SerializationInfo info, StreamingContext context)
            : base(info, context)
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

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
