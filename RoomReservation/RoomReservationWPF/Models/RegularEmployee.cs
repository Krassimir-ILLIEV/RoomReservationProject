using RoomReservationWPF.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomReservationWPF.Common;
using System.Runtime.Serialization;

namespace RoomReservationWPF.Models
{
    [Serializable]
    public abstract class RegularEmployee : IRegularEmployee, ISerializable
    {
        private static int employeeIdGenerator = 1;
        private readonly int employeeID;

        public RegularEmployee()
        {
            //default constructor 
        }

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
            //Id
            //location
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("EmployeeName", this.Name, typeof(string));
            info.AddValue("EmployeeTitle", this.Title, typeof(string));
            //Id
            //location
        }

        public int EmployeeID
        {
            get
            {
                return this.employeeID;
            }
        }
     
        public string Name { get; set; }

        public abstract enumEmployeePriority Priority { get; }

        public string Title { get; private set; }

        public Location EmployeeLocation {  get; private set; }

        
    }
}
