namespace RoomReservationWPF.Models
{
    using System;
    using System.Linq;
    using System.Text;
    using RoomReservationWPF.Common;
    using RoomReservationWPF.Contracts;
    using System.Runtime.Serialization;

    [Serializable]
    public class Employee : RegularEmployee, IRegularEmployee, ISerializable
    {
        public Employee() : base()
        {
            //default
        }

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

        public string Team { get; private set; }
        //or another property?

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Team", this.Team, typeof(string));
        }
       
        public override enumEmployeePriority Priority
        {
            get
            {
                return enumEmployeePriority.Low;
            }
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
