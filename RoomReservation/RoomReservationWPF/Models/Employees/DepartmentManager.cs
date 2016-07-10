namespace RoomReservationWPF.Models.Employees
{
    using System;
    using System.Runtime.Serialization;
    using System.Text;

    using RoomReservationWPF.Common;
    using RoomReservationWPF.Contracts;

    [Serializable]
    public class DepartmentManager : UnitManager, IRegularEmployee, ISerializable
    {
        private string department;

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

        public DepartmentManager(string csvStr)
            :base(csvStr)
        {
            string[] data = csvStr.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            this.Department = data[5];
        }

        public override EmployeePriorityType Priority
        {
            get
            {
                return EmployeePriorityType.VeryHigh;
            }
        }

        public string Department
        {
            get
            {
                return this.department;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The department cannot be null or empty.");
                }
                this.department = value;
            }
        }

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
