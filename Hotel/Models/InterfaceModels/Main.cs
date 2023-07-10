using Hotel.Models.Abstractions;

namespace Hotel.Models.InterfaceModels
{
    public class Main : Entity
    {
        public int Rating { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }
    }
}
