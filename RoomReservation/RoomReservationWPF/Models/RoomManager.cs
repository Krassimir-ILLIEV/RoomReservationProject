namespace RoomReservationWPF.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Threading.Tasks;
    using System.Runtime.Serialization;

    [Serializable]

    public class RoomManager
    {
        public static string FileName = @"../../RoomData.csv";

        private static RoomManager instance;
        private static readonly object padlock = new object();

        private IList<Room> listOfRooms;
        private Dictionary<int, HashSet<Timeslot>> roomSchedule; //int is roomId

        private RoomManager(string FileName)
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


        public static RoomManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new RoomManager(FileName);
                        }
                    }
                }

                return instance;
            }
        }


        public RoomManager(SerializationInfo info, StreamingContext context)
        {
            this.listOfRooms = (List<Room>)info.GetValue("listOfRooms", typeof(List<Room>));
            this.roomSchedule = (Dictionary<int, HashSet<Timeslot>>)info.GetValue("roomSchedule", typeof(Dictionary<int, HashSet<Timeslot>>));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("listOfRooms", this.listOfRooms, typeof(List<Room>));
            info.AddValue("roomSchedule", this.roomSchedule, typeof(Dictionary<int, HashSet<Timeslot>>));
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
            roomSchedule[RoomID].RemoveWhere(s => s.IsThereConflict(new Timeslot(eventMoment, 1)));
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
                throw new ArgumentException("This room is not included in the timetable (we have no such room)");
            }
            HashSet<Timeslot> roomTimeslots = roomSchedule[roomId];
            StringBuilder timeslotResult = new StringBuilder();
            foreach (Timeslot t in roomTimeslots)
            {
                timeslotResult.Append(t + ";");
            }

            return timeslotResult.ToString();
        }
        public List<Scheduler> GetSchedules()
        {
            List<Scheduler> result = new List<Scheduler>();
            foreach (KeyValuePair<int, HashSet<Timeslot>> item in roomSchedule)
            {
                foreach (Timeslot timeslot in item.Value)
                {
                    result.Add(new Scheduler(item.Key, timeslot));
                }
            }
            return result.OrderBy(s => s.Timing).ToList();
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
