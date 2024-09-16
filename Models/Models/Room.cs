namespace KSR_Docker.Models.Models
{
    public class Room
    {
        public string Name { get; set; }

        public string Status { get; set; }

        public int Id { get; set; }

        public int TypeId { get; set; }

        public Room(int roomId, string name, int roomType, string status)
        {
            Name = name;
            Status = status;
            Id = roomId;
            TypeId = roomType;
        }
    }
}
