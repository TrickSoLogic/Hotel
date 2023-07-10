using Hotel.Models.Abstractions;

namespace Hotel.Models.InterfaceModels
{
    public class SliderImage : Entity
    {
        public string Image { get; set; }

        public int Order { get; set; }
    }
}
