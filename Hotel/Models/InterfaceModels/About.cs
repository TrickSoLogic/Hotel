using Hotel.Models.Abstractions;

namespace Hotel.Models.InterfaceModels
{
    public class About : Entity
    {
        public string Image { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ButtonName { get; set; }
    }
}
