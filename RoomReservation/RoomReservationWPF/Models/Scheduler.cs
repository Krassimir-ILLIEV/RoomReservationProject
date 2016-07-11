namespace RoomReservationWPF.Models
{
    using System;
    using System.Collections.Generic;

    public class Scheduler
    {
        public int RoomID { get; private set; }
        public DateTime BeginTime
        {
            get
            {
                return timeslot.BeginTime;
            }
        }
        public string Timing
        {
            get
            {
                return string.Format("{0:yyyy-MM-dd HH:mm} for {1} hours", this.timeslot.BeginTime, this.timeslot.DurationMin / 60.0);
            }
        }

        private Timeslot timeslot;
        public Scheduler(int roomID, Timeslot timeslot)
        {
            this.RoomID = roomID;
            this.timeslot = timeslot;
        }

    }
}
