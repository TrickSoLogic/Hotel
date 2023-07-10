using Hotel.Models.Abstractions;

namespace Hotel.Models
{
    public class Room : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int PersonCount { get; set; }

        public int Square { get; set; }

        public double Cost { get; set; }

        public List<RoomsFeatures> RoomsFeatures { get; set; }

        public int HotelId { get; set; }

        public Hotell Hotel { get; set; }

        public List<Image> Images { get; set; }

        public List<Rezervation> Rezervations { get; set; }
    }
}
