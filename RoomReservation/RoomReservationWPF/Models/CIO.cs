namespace RoomReservationWPF.Models
{
    using System;
    using System.Text;
    using System.Runtime.Serialization;
    using RoomReservationWPF.Contracts;
    using RoomReservationWPF.Common;

    [Serializable]
    public class CIO : DepartmentManager, IRegularEmployee, ISerializable
    {
        public CIO() : base()
        {
            //default
        }

        public CIO(string name, string title, Location location, int yearsOfExperience, string unit, string department)
            : base(name, title, location, yearsOfExperience, unit, department)
        {
        }

        public CIO(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        //additional property

        public override enumEmployeePriority Priority
        {
            get
            {
                return enumEmployeePriority.VeryHigh;
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
