using Hotel.Models.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class Rezervation : Entity
    {
        
        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public int Elders { get; set; }

        public int Children { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public int RoomId { get; set; }

        public Room Room { get; set; }
    }
}
