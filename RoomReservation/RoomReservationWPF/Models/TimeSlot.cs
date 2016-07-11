namespace RoomReservationWPF.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using RoomReservationWPF.Models;
    using RoomReservationWPF.Models.Employees;
    using System.Runtime.Serialization;

    [Serializable]
    public class Timeslot : ISerializable
    {
        public DateTime BeginTime { get; set; }
        public int DurationMin { get; set; }
        public OrganizedEvent organizedEvent { get; set; }
        public RegularEmployee contactEmployee { get; set; }
        public Timeslot(SerializationInfo info, StreamingContext context)
        {
            this.BeginTime = (DateTime)info.GetValue("BeginTime", typeof(DateTime));
            this.DurationMin = (int)info.GetValue("DurationMin", typeof(int));
            this.organizedEvent = (OrganizedEvent)info.GetValue("organizedEvent", typeof(OrganizedEvent));
            this.contactEmployee = (RegularEmployee)info.GetValue("contactEmployee", typeof(RegularEmployee));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("BeginTime", this.BeginTime, typeof(DateTime));
            info.AddValue("DurationMin", this.DurationMin, typeof(int));
            info.AddValue("organizedEvent", this.organizedEvent, typeof(OrganizedEvent));
            info.AddValue("contactEmployee", this.contactEmployee, typeof(RegularEmployee));
        }

        public Timeslot(DateTime beginTime, int durationMin)
        {
            this.BeginTime = beginTime;
            this.DurationMin = durationMin;
            this.organizedEvent = null;
        }

        public bool IsThereConflict(Timeslot timeslot)
        {
            return !(timeslot.BeginTime.AddMinutes(timeslot.DurationMin) < this.BeginTime ||
                this.BeginTime.AddMinutes(this.DurationMin) < timeslot.BeginTime);
        }

    }


}
