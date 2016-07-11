namespace RoomReservationWPF.Models.Employees
{
    using System;
    using System.Runtime.Serialization;
    using System.Text;

    using RoomReservationWPF.Common;
    using RoomReservationWPF.Contracts;

    [Serializable]
    public class CEO : ChiefOfficer, IRegularEmployee, ISerializable
    {
        public CEO(string name, string title, Location location, int yearsOfExperience, string unit, string department)
            : base(name, title, location, yearsOfExperience, unit, department)
        {
        }

        public CEO(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public CEO(string csvStr)
            :base(csvStr)
        {
        }


    }
}
