using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomReservation.Models
{
    class Timeslot: IComparable
    {

        public DateTime BeginTime{get;set;}
        public DateTime Date { get; set; }
        public OrganizedEvent organizedEvent { get; set; }

        public OrganizedEvent organizedEvent { get; set; }

        public int CompareTo(Timeslot timeslot)
        {
            return (this.BeginTime.CompareTo(timeslot.BeginTime));
        }
        
    }


}
