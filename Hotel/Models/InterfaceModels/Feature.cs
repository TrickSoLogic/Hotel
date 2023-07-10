using Hotel.Models.Abstractions;

namespace Hotel.Models.InterfaceModels
{
    public class Feature : Entity
    {
        public string Image { get; set; }

        public string? Title { get; set; }

        public string Description { get; set; }

        public int Order { get; set; }

        public bool IsMain { get; set; }

        public List<RoomsFeatures> RoomsFeatures { get; set; }

    }
}
