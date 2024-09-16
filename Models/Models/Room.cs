namespace KSR_Docker.Models.Models
{
    public class Room
    {
        public string Name { get; set; }

        public string Status { get; set; }

        public int RoomId { get; set; }

        public int RoomType { get; set; }

        public Room(string name, string status, int roomType, int roomId)
        {
            Name = name;
            Status = status;
            RoomId = roomId;
            RoomType = roomType;
        }
    }
}
