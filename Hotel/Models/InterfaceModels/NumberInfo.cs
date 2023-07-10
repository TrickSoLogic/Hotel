using Hotel.Models.Abstractions;

namespace Hotel.Models.InterfaceModels
{
    public class NumberInfo : Entity
    {
        public int Number { get; set; }

        public string Description { get; set; }
    }
}
