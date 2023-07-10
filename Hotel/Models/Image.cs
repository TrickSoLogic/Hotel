using Hotel.Models.Abstractions;

namespace Hotel.Models
{
    public class Image : Entity
    {
        public string Name { get; set; }

        public bool IsMain { get; set; }

        public int RoomId { get; set; }

        public Room Room { get; set; }
    }
}
