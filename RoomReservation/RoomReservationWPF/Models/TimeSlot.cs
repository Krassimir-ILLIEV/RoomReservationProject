namespace RoomReservation.Models
{
    using System;

    internal class Timeslot // :IComparable
    {
        public DateTime BeginTime { get; set; }

        public DateTime Date { get; set; }

        public OrganizedEvent OrganizEvent { get; set; }

        public int CompareTo(Timeslot timeslot)
        {
            return (this.BeginTime.CompareTo(timeslot.BeginTime));
        }
    }
}
