namespace RoomReservation.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using RoomReservationWPF.Exceptions;

   internal class RoomManager
    {
        private Dictionary<int, Room> rooms;
        private List<Room> listOfRooms;
        private Dictionary<int, HashSet<Timeslot>> roomSchedule; // int is roomId
        private Dictionary<int, SortedSet<Timeslot>> roomScheduleTest;

        // SORTED SET<t> SORTED BY TIMESLOT begintime is better
        // private Scheduler scheduler;
        public RoomManager()
        {
            this.listOfRooms = new List<Room>();
            this.roomSchedule = new Dictionary<int, HashSet<Timeslot>>();

            // or hashtable<timeslot,beginTime>
            // roomSchedule_test = new Dictionary<int, SortedSet<Timeslot>>();
        }

        public List<int> GetListOfRecommendedRooms(Request request)   // roomID can be a class on its own
        {
            // roomSchedule_test;
            return null;
        }

        public List<int> GetListOfRoomsForTimeSlot(Timeslot timeslot)
        {
            List<int> availableRooms = new List<int>();
            foreach (KeyValuePair<int, HashSet<Timeslot>> pair in this.roomSchedule)
            {
                bool isFree = true;
                foreach (Timeslot ts in pair.Value)
                {
                    if (ts.BeginTime.Equals(timeslot.BeginTime))

                    // if a timeslot can span several half hour periods
                    // we will check if timeslot.begin time is b/n ts begin and end time 
                    {
                        isFree = false;
                        break;
                    }
                }

                if (isFree)
                {
                    availableRooms.Add(pair.Key);
                }
            }

            return availableRooms;
        }

        public void BookRoom(int roomID)
        {
        }

        public void CancelReservation(int roomID)
        {
        }

        public void AddNewRoom(Room room)
        {
            this.rooms.Add(room.roomId, room);
            this.roomSchedule.Add(room.roomId, new HashSet<Timeslot>());
        }

        public string GetRoomSchedule(int roomId)
        {
            if (!this.roomSchedule.ContainsKey(roomId))
            {
                throw new RoomExceptions("The room is not appear int room schedule");
            }

            HashSet<Timeslot> roomTimeslots = this.roomSchedule[roomId];
            StringBuilder timeslotResult = new StringBuilder();
            foreach (Timeslot t in roomTimeslots)
            {
                timeslotResult.Append(t + ";");
            }

            return timeslotResult.ToString();
        }

        // ADD GET OPTIMAL ROOM BASED ON ALL EVENT ATTENDEES' LOCATIONS AND THEIR RELATIVE WEIGHT 
        // DETERMINED BY STATUS

        /* - getListOfRecommendedRooms // called via a button, returns a list of room objects;
 - pickRoom (via button);
 - cancelReservation;
 - clearForm;
 - notifyEmployeeIfRoomRequestWasOverriden (via email);
 - suggestNewRoom (to the employee whose booking was overridden);
         */
    }
}
