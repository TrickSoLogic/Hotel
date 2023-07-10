using Hotel.Models.Abstractions;

namespace Hotel.Models.InterfaceModels
{
    public class Testimonial : Entity
    {
        public string FullName { get; set; }

        public string City { get; set; }

        public string Description { get; set; }

        public int Rating { get; set; }

        public string Image { get; set; }
    }
}
