using Hotel.Data;
using Hotel.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Controllers
{
    public class HistoryController : Controller
    {

        private readonly AppDbContext _context;

        public HistoryController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var userID = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name).Id;
            var reservations = _context.Rezervations.Include(r => r.Room).Where(r => r.UserId == userID).ToList();

            var RoomVms = reservations.Select(r => new RoomViewModel
            {
                Id = r.Room.Id,
                Name = r.Room.Name,
                Description = r.Room.Description,
                Cost = r.Room.Cost,
                PersonCount = r.Room.PersonCount,
                Square = r.Room.Square,
                Image = _context.Images.FirstOrDefault(i => i.IsMain == true && i.RoomId == r.Room.Id).Name
            }).ToList();

            return View(RoomVms);
        }
    }
}
