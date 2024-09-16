using KSR_Docker.Models.Models;

namespace KSR_Docker.Models.Repositories
{
    public class RoomRepository
    {
        private static RoomRepository Instance;

        public List<Room> Rooms { get; set; }
        public int idCounter;

        public static RoomRepository GetInstance()
        {
            if (Instance == null)
            {
                Instance = new RoomRepository();
            }
            return Instance;
        }

        private RoomRepository()
        {
            int idCounter = 0;
            Rooms = new List<Room>();
        }

        //public void Init()
        //{
        //    Room temp = new Room();
        //    Rooms.Add(temp);
        //}

        public List<Room> GetRooms()
        {
            //todo: fetch from server
            return Rooms;
        }

        public void Add(string name, string status, int roomType)
        {
            idCounter += 1;
            Rooms.Add(new Room(idCounter, name, roomType, status));
        }

        public void Remove(int roomId)
        {
            //todo: send remove request
            try
            {
                Rooms.Remove(Rooms.Find(x => x.Id == roomId));
            }
            catch (Exception ex)
            {
                //pass
            }
        }
    }
}
