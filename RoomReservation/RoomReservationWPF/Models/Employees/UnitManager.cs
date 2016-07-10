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
        private string unit;

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

        public UnitManager(string csvStr)
            :base(csvStr)
        {
            string[] data = csvStr.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            this.Unit = data[4];
        }

        public override EmployeePriorityType Priority
        {
            get
            {
                return EmployeePriorityType.High;
            }
        }

        public string Unit
        {
            get
            {
                return this.unit;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The unit cannot be null or empty");
                }
                this.unit = value;
            }
        }

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
