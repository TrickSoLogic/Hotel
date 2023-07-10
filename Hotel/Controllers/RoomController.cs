using Hotel.Data;
using Hotel.Models;
using Hotel.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Controllers
{

    [Authorize]
    public class RoomController : Controller
    {
        private readonly AppDbContext _dbContext;

        public RoomController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index(int? id)
        {
            var Room = await _dbContext.Rooms.Include(r => r.Images.OrderByDescending(i => i.IsMain)).Include(r => r.RoomsFeatures)
                .ThenInclude(rf => rf.Feature).FirstOrDefaultAsync(r => r.Id == id);

            RezervationViewModel rezervationViewModel = new RezervationViewModel { Room = Room };

            if (Room == null)
            {
                return NotFound();
            }

            return View(rezervationViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Rezerv([Bind("Rezervation")] RezervationViewModel rv)
        {
            var rezervation = rv.Rezervation;

            if (rezervation.CheckIn >= rezervation.CheckOut)
            {
                TempData["Error"] = "Invalid dates";
                return Redirect("/Room/Index/" + rezervation.RoomId);
            }

            var reservedDates = await _dbContext.Rezervations.Where(r => r.RoomId == rezervation.RoomId).ToListAsync();

            foreach (var date in reservedDates)
            {
                if ((rezervation.CheckIn > date.CheckIn && rezervation.CheckIn < date.CheckOut) || 
                    (rezervation.CheckOut > date.CheckIn && rezervation.CheckOut < date.CheckOut) ||
                    (rezervation.CheckIn <= date.CheckIn && rezervation.CheckOut >= date.CheckOut))
                {
                    TempData["Error"] = "Room is reserved for this dates";
                    return Redirect("/Room/Index/" + rezervation.RoomId);
                }
            }

            rezervation.UserId = (await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name)).Id;

            await _dbContext.Rezervations.AddAsync(rezervation);
            await _dbContext.SaveChangesAsync();

            TempData["Success"] = "Reserved Successfully";
            return Redirect("/Room/Index/" + rezervation.RoomId);
        }
    }
}
