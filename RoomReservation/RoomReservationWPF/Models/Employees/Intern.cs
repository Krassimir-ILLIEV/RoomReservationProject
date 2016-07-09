namespace RoomReservationWPF.Models.Employees
{
    using System;
    using System.Runtime.Serialization;
    using System.Text;

    using RoomReservationWPF.Common;
    using RoomReservationWPF.Contracts;

    [Serializable]
    public class Intern : RegularEmployee, IRegularEmployee, ISerializable
    {
        private int internshipPeriodInMonths;

        public Intern() : base()
        {
            // default
        }

        public Intern(string name, string title, Location location, int internshipPeriod)
            : base(name, title, location)
        {
            this.InternshipPeriodInMonths = internshipPeriod;
        }

        public Intern(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.InternshipPeriodInMonths = (int)info.GetValue("InternshipPeriod", typeof(int));
        }

        public override EnumEmployeePriority Priority
        {
            get
            {
                return EnumEmployeePriority.VeryLow;
            }
        }

        public int InternshipPeriodInMonths
        {
            get
            {
                return this.internshipPeriodInMonths;
            }

            private set
            {
                if (value < 0 || value > 24)
                {
                    throw new ArgumentException("The internship period should be between 0 and 24 months.");
                }

                this.internshipPeriodInMonths = value;
            }
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("InternshipPeriod", this.InternshipPeriodInMonths, typeof(int));
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
