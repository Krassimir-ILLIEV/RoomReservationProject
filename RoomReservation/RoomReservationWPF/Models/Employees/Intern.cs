namespace RoomReservationWPF.Models.Employees
{
    using System;
    using System.Runtime.Serialization;
    using System.Text;

    using Exceptions;
    using RoomReservationWPF.Common;
    using RoomReservationWPF.Contracts;

    [Serializable]
    public class Intern : RegularEmployee, IRegularEmployee, ISerializable, IIntern
    {
        private const int minPeriod = 0;
        private const int maxPeriod = 24;
        private int internshipPeriodInMonths;

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

        public Intern(string csvStr)
            : base(csvStr)
        {
            string[] data = csvStr.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            this.InternshipPeriodInMonths = int.Parse(data[3]);
        }

        public override EmployeePriorityType Priority
        {
            get
            {
                return EmployeePriorityType.VeryLow;
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
                if (value < minPeriod || value > maxPeriod)
                {
                    throw new DateExceptions(string.Format("The internship period should be between {0} and {1} months.", minPeriod, maxPeriod));
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
