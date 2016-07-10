namespace RoomReservationWPF.Models.Employees
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Threading.Tasks;

    using RoomReservationWPF.Common;
    using RoomReservationWPF.Contracts;

    [Serializable]
    public abstract class RegularEmployee : IRegularEmployee, ISerializable
    {
        private static int employeeIdGenerator = 1;
        private string name;
        private string title;
        private Location employeeLocation;

        public RegularEmployee(string name, string title, Location location)
        {
            RegularEmployeeInit(name, title, location);
        }

        public RegularEmployee(SerializationInfo info, StreamingContext context)
        {
            this.Name = (string)info.GetValue("EmployeeName", typeof(string));
            this.Title = (string)info.GetValue("EmployeeTitle", typeof(string));
            this.EmployeeLocation = (Location)info.GetValue("EmployeeLocation", typeof(Location));
        }

        public RegularEmployee(string csvStr)
        {
            string[] data = csvStr.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            Location location = new Location(data[2]);
            RegularEmployeeInit(data[0], data[1], location);
        }

        private void RegularEmployeeInit(string name, string title, Location location)
        {
            this.Name = name;
            this.Title = title;
            this.EmployeeLocation = location;
            this.EmployeeID = employeeIdGenerator++;
        }

        public int EmployeeID { get; private set; }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The employee name cannot be null or empty");
                }

                this.name = value;
            }
        }

        public abstract EmployeePriorityType Priority { get; }

        public string Title
        {
            get
            {
                return this.title;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The employee title cannot be null or empty.");
                }
                this.title = value;
            }
        }

        public Location EmployeeLocation
        {
            get
            {
                return this.employeeLocation;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Location must be set.");
                }
                this.employeeLocation = value;
            }
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("EmployeeName", this.Name, typeof(string));
            info.AddValue("EmployeeTitle", this.Title, typeof(string));
            info.AddValue("EmployeeLocation", this.EmployeeLocation, typeof(Location));
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(this.Name);
            builder.AppendLine(string.Format("Position: {0}", this.GetType().Name));
            builder.AppendLine(string.Format("Title: {0}", this.Title));
            builder.AppendLine(string.Format("ID: {0}", this.EmployeeID));
            builder.AppendLine(string.Format("Priority: {0}", this.Priority));
            builder.AppendLine(string.Format("Location: {0}", this.EmployeeLocation.ToString()));
            return builder.ToString();
        }
    }
}
