namespace RoomReservationWPF.Models.Employees
{
    using System;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;

    using RoomReservationWPF.Common;
    using RoomReservationWPF.Contracts;

    [Serializable]
    public class Employee : RegularEmployee, IRegularEmployee, ISerializable
    {
        private string team;

        public Employee(string name, string title, Location location, string team)
            : base(name, title, location)
        {
            this.Team = team;
        }

        public Employee(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.Team = (string)info.GetValue("Team", typeof(string));
        }

        public Employee(string csvStr)
            :base(csvStr)
        {
            string[] data = csvStr.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            this.Team = data[3];
        }

        public string Team
        {
            get
            {
                return this.team;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The employee team cannot be null or empty");
                }
                this.team = value;
            }
        }

        public override EmployeePriorityType Priority
        {
            get
            {
                return EmployeePriorityType.Low;
            }
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Team", this.Team, typeof(string));
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(base.ToString());
            builder.AppendLine(string.Format("Employee team: {0}", this.Team));
            return builder.ToString();
        }
    }
}
