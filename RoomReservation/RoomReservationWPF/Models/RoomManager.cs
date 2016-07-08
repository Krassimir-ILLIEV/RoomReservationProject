using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomReservation.Models
{
    class RoomManager
    {
        private Dictionary<int, Room> rooms;
        private List<Room> listOfRooms;
        private Dictionary<int, HashSet<Timeslot>> roomSchedule; //int is roomId
        private Dictionary<int, SortedSet<Timeslot>> roomSchedule_test;
       
        //SORTED SET<t> SORTED BY TIMESLOT begintime is better

        //private Scheduler scheduler;

        public RoomManager()
        {
            listOfRooms = new List<Room>();
            roomSchedule = new Dictionary<int, HashSet<Timeslot>>();
            //or hashtable<timeslot,beginTime>
            //roomSchedule_test = new Dictionary<int, SortedSet<Timeslot>>();
             
        }

        public List<int> GetListOfRecommendedRooms(Request request)   //roomID can be a class on its own
        {
            //roomSchedule_test;

            return null;
        }

        public List<int> GetListOfRoomsForTimeSlot(Timeslot timeslot)
        {
            List<int> availableRooms = new List<int>();
            foreach (KeyValuePair<int, HashSet<Timeslot>> pair in roomSchedule)
            {
                bool isFree = true;
                foreach (Timeslot ts in pair.Value)
                {
                    if (ts.BeginTime.Equals(timeslot.BeginTime)) 
                        //if a timeslot can span several half hour periods
                        //we will check if timeslot.begin time is b/n ts begin and end time 
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

        public void BookRoom(int RoomID)
        {

        }

        public void CancelReservation(int RoomID)
        {

        }

        public void AddNewRoom(Room room)
        {
            rooms.Add(room.RoomId,room);
            roomSchedule.Add(room.RoomId, new HashSet<Timeslot>());
        }

        public string getRoomSchedule(int roomId)
        {
            //throw exception if it does not exist in roomSchedule

            if(!roomSchedule.ContainsKey(roomId))
            {
                throw new ArgumentException("TO DO WRITE A MEANINGFUL EXCEPTION");
            }
            HashSet<Timeslot> roomTimeslots=roomSchedule[roomId];
            StringBuilder timeslotResult=new StringBuilder();
            foreach(Timeslot t in roomTimeslots){
                timeslotResult.Append(t+";");
            }

            return timeslotResult.ToString();
        }

        //ADD GET OPTIMAL ROOM BASED ON ALL EVENT ATTENDEES' LOCATIONS AND THEIR RELATIVE WEIGHT 
        //DETERMINED BY STATUS

        /* -	getListOfRecommendedRooms //called via a button, returns a list of room objects;
 -	pickRoom (via button);
 -	cancelReservation;
 -	clearForm;
 -	notifyEmployeeIfRoomRequestWasOverriden (via email);
 -	suggestNewRoom (to the employee whose booking was overridden);
         */
    }
}
