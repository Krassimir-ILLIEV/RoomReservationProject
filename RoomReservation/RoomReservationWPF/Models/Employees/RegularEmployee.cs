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
        private readonly int employeeID;

        public RegularEmployee(string name, string title, Location location)
        {
            this.Name = name;
            this.Title = title;
            this.EmployeeLocation = location;
            this.employeeID = (employeeIdGenerator++);
        }

        public RegularEmployee(SerializationInfo info, StreamingContext context)
        {
            this.Name = (string)info.GetValue("EmployeeName", typeof(string));
            this.Title = (string)info.GetValue("EmployeeTitle", typeof(string));

            // Id
            // location
        }

        public RegularEmployee()
        {
            // default constructor 
        }

        public int EmployeeID
        {
            get
            {
                return this.employeeID;
            }
        }

        public string Name { get; set; }

        public abstract EmployeePriorityType Priority { get; }

        public string Title { get; private set; }

        public Location EmployeeLocation { get; private set; }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("EmployeeName", this.Name, typeof(string));
            info.AddValue("EmployeeTitle", this.Title, typeof(string));

            // Id
            // location
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(this.Name);
            builder.AppendLine(string.Format("Position: {0}", this.GetType().Name));
            builder.AppendLine(string.Format("Title: {0}", this.Title));
            builder.AppendLine(string.Format("ID: {0}", this.EmployeeID));
            builder.AppendLine(string.Format("Priority: {0}", this.Priority));

            // location
            return builder.ToString();
        }
    }
}
