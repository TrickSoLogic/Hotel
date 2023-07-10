using Hotel.Data;
using Hotel.Models;
using Hotel.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hotel.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }



        public IActionResult Index()
        {
            var Main = _context.Mains.FirstOrDefault();
            var Abouts = _context.Abouts.ToList();
            var Features = _context.Features.Where(f => f.IsMain).OrderBy(f => f.Order).ToList();
            var NumberInfos = _context.NumberInfos.ToList();
            var SliderImages = _context.SliderImages.ToList();
            var Testimonials = _context.Testimonials.ToList();
            var RoomVms = _context.Rooms.Take(8).Select(r => new RoomViewModel
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description,
                Cost = r.Cost,
                PersonCount = r.PersonCount,
                Square = r.Square,
                Image = _context.Images.FirstOrDefault(i => i.IsMain == true && i.RoomId == r.Id).Name
            }).ToList();
            var mainVm = new HomeViewModel()
            {
                Abouts = Abouts,
                Features = Features,
                NumberInfos = NumberInfos,
                SliderImages = SliderImages,
                Testimonials = Testimonials,
                Main = Main,
                RoomViewModels = RoomVms
            };
            return View(mainVm);
        }
    }
}