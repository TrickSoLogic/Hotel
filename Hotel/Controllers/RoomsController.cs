using Hotel.Data;
using Hotel.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class RoomsController : Controller
    {
        private readonly AppDbContext _dbContext;

        public RoomsController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var RoomVms = _dbContext.Rooms.Take(5).Select(r => new RoomViewModel
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description,
                Cost = r.Cost,
                PersonCount = r.PersonCount,
                Square = r.Square,
                Image = _dbContext.Images.FirstOrDefault(i => i.IsMain == true && i.RoomId == r.Id).Name
            }).ToList();
            return View(RoomVms);
        }
    }
}
