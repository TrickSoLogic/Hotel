using Hotel.Models.Abstractions;

namespace Hotel.Models
{
    public class Hotell : Entity
    {
        public string Name { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public int Rating { get; set; }

        public List<Room> Rooms { get; set; }
    }
}
