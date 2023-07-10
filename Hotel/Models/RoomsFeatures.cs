using Hotel.Models.Abstractions;
using Hotel.Models.InterfaceModels;

namespace Hotel.Models
{
    public class RoomsFeatures : Entity
    {
        public int FeatureId { get; set; }

        public Feature Feature { get; set; }

        public int RoomId { get; set; }

        public Room Room { get; set; }
    }
}
