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
        public CFO() : base()
        {
            // default
        }

        public CFO(string name, string title, Location location, int yearsOfExperience, string unit, string department)
            : base(name, title, location, yearsOfExperience, unit, department)
        {
        }

        public CFO(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        // additional property
        public override EnumEmployeePriority Priority
        {
            get
            {
                return EnumEmployeePriority.VeryHigh;
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
