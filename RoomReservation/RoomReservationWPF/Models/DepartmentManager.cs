namespace RoomReservationWPF.Models
{
    using System;
    using System.Text;
    using System.Runtime.Serialization;
    using RoomReservationWPF.Contracts;
    using RoomReservationWPF.Common;

    [Serializable]
    public class DepartmentManager : UnitManager, IRegularEmployee, ISerializable
    {
        public DepartmentManager() : base()
        {
            //default
        }

        public DepartmentManager(string name, string title, Location location, int yearsOfExperience, string unit, string department)
            : base(name, title, location, yearsOfExperience, unit)
        {
            this.Department = department;
        }

        public DepartmentManager(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.Department = (string)info.GetValue("Department", typeof(string));
        }

        public override enumEmployeePriority Priority
        {
            get
            {
                return enumEmployeePriority.High;
            }
        }

        public string Department { get; private set; }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Department", this.Department, typeof(string));
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(base.ToString());
            builder.AppendLine(string.Format("Department: {0}", this.Department));
            return builder.ToString();
        }
    }
}

