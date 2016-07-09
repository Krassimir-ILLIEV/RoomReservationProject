namespace RoomReservationWPF.Models.Employees
{
    using System;
    using System.Runtime.Serialization;
    using System.Text;

    using RoomReservationWPF.Common;
    using RoomReservationWPF.Contracts;

    [Serializable]
    public class UnitManager : Manager, IRegularEmployee, ISerializable
    {
        public UnitManager() : base()
        {
            // default
        }

        public UnitManager(string name, string title, Location location, int yearsOfExperience, string unit)
            : base(name, title, location, yearsOfExperience)
        {
            this.Unit = unit;
        }

        public UnitManager(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.Unit = (string)info.GetValue("Unit", typeof(string));
        }

        public override EnumEmployeePriority Priority
        {
            get
            {
                return EnumEmployeePriority.High;
            }
        }
        public string Unit { get; private set; }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Unit", this.Unit, typeof(string));
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(base.ToString());
            builder.AppendLine(string.Format("Unit: {0}", this.Unit));
            return builder.ToString();
        }
    }
}
