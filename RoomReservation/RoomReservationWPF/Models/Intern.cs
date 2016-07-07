namespace RoomReservationWPF.Models
{
    using System;
    using System.Text;
    using RoomReservationWPF.Common;
    using RoomReservationWPF.Contracts;
    using System.Runtime.Serialization;
    
    [Serializable]
    public class Intern : RegularEmployee, IRegularEmployee, ISerializable
    {
        private int internshipPeriodInMonths;

        public Intern() : base()
        {
            //default
        }

        public Intern(string name, string title, Location location, int internshipPeriod)
            :base(name, title, location)
        {
            this.InternshipPeriodInMonths = internshipPeriod;
        }

        public Intern(SerializationInfo info, StreamingContext context)
            :base(info, context)
        {
            this.InternshipPeriodInMonths = (int)info.GetValue("InternshipPeriod", typeof(int));
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("InternshipPeriod", this.InternshipPeriodInMonths, typeof(int));
        }

        public int InternshipPeriodInMonths
        {
            get
            {
                return this.internshipPeriodInMonths;
            }
            private set
            {
                if(value < 0 || value > 24)
                {
                    throw new ArgumentException("The internship period should be between 0 and 24 months.");
                }
                this.internshipPeriodInMonths = value;
            }
        }

        public override enumEmployeePriority Priority
        {
            get
            {
                return enumEmployeePriority.VeryLow;
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(base.ToString());
            builder.AppendLine(string.Format("Internship period: {0} months", this.InternshipPeriodInMonths));
            return builder.ToString();
        }
    }
}
