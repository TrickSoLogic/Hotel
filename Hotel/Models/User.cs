using Microsoft.AspNetCore.Identity;

namespace Hotel.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public List<Rezervation> Rezervations { get; set; }

    }
}
