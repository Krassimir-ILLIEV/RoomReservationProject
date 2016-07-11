namespace RoomReservationWPF.Models
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class RoomManager
    {
        // private Dictionary<int, Room> rooms;
        private IList<Room> listOfRooms;
        private Dictionary<int, HashSet<Timeslot>> roomSchedule; //int is roomId
        //private Dictionary<int, SortedSet<Timeslot>> roomSchedule_test;

        //SORTED SET<t> SORTED BY TIMESLOT begintime is better

        //private Scheduler scheduler;

        public RoomManager()
        {
            listOfRooms = new List<Room>();
            roomSchedule = new Dictionary<int, HashSet<Timeslot>>();
            //or hashtable<timeslot,beginTime>
            //roomSchedule_test = new Dictionary<int, SortedSet<Timeslot>>();
        }
        public RoomManager(string FileName)
            : base()
        {
            // FileName = @"C:\Users\DerKaiser\Desktop\project GUi\RoomReservation\RoomReservationWPF\RoomData.csv";
            var csvlines = File.ReadAllLines(FileName);
            IEnumerable<Room> csv = from line in File.ReadAllLines(FileName).Skip(1) //ignore first line
                                    select new Room(line);

            listOfRooms = new List<Room>(csv);
            roomSchedule = new Dictionary<int, HashSet<Timeslot>>();
            foreach (Room room in listOfRooms)
            {
                roomSchedule.Add(room.RoomID, new HashSet<Timeslot>());
            }
        }
        private bool isRoomAvailable(int RoomID, Timeslot ocuppation)
        {
            bool result = true;
            HashSet<Timeslot> timeSlots = roomSchedule[RoomID];
            foreach (Timeslot ts in timeSlots)
            {
                if (ts.IsThereConflict(ocuppation))
                {
                    result = false;
                    break;
                }
            }
            return result;
        }
        public List<Room> GetListOfRecommendedRooms(Request request)   //roomID can be a class on its own
        {
            List<Room> result = new List<Room>();
            foreach (Room room in listOfRooms)
            {
                if (isRoomAvailable(room.RoomID, request.Occupation))// && room.IsCompatible(request)) 
                {
                    result.Add(room);
                }
            }

            return result;
        }
        public Room getRoomByID(int roomID)
        {
            return listOfRooms.Where(s => s.RoomID == roomID).FirstOrDefault();
        }
        public List<int> GetListOfRoomsForTimeSlot(Timeslot timeslot)
        {
            List<int> availableRooms = new List<int>();
            foreach (KeyValuePair<int, HashSet<Timeslot>> pair in roomSchedule)
            {
                bool isFree = true;
                foreach (Timeslot ts in pair.Value)
                {
                    if (ts.IsThereConflict(timeslot))

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

        public void BookRoom(int RoomID, Timeslot ts)
        {
            roomSchedule[RoomID].Add(ts);
        }

        public void CancelReservation(int RoomID, DateTime eventMoment)
        {
            roomSchedule[RoomID].RemoveWhere(s => s.IsThereConflict(new Timeslot(eventMoment, 0)));
        }

        public void AddNewRoom(Room room)
        {
            //rooms.Add(room.RoomId, room);
            listOfRooms.Add(room);
            roomSchedule.Add(room.RoomID, new HashSet<Timeslot>());
        }
        public IList<Room> ListOfRooms
        {
            get
            {
                return this.listOfRooms;
            }
        }
        public string getRoomSchedule(int roomId)
        {
            //throw exception if it does not exist in roomSchedule

            if (!roomSchedule.ContainsKey(roomId))
            {
                throw new ArgumentException("TO DO WRITE A MEANINGFUL EXCEPTION");
            }
            HashSet<Timeslot> roomTimeslots = roomSchedule[roomId];
            StringBuilder timeslotResult = new StringBuilder();
            foreach (Timeslot t in roomTimeslots)
            {
                timeslotResult.Append(t + ";");
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
