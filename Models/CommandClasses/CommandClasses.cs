using MessageTypes;

namespace KSR_Docker.Models.CommandClasses
{
    public class RoomUpdateCommand : IRoomUpdate
    {
        public string Name { get; set; }
        public int RoomType { get; set; }
        public string Status { get; set; }
        public int RoomId { get; set; }
    }

    public class RoomDeleteCommand : IRoomDelete
    {
        public int RoomId { get; set; }
    }
}
