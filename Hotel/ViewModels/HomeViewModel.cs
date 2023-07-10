using Hotel.Models.InterfaceModels;

namespace Hotel.ViewModels
{
    public class HomeViewModel
    {
        public List<About> Abouts { get; set; }

        public List<Feature> Features { get; set; }

        public Main Main { get; set; }

        public List<NumberInfo> NumberInfos { get; set; }

        public List<SliderImage> SliderImages { get; set; }

        public List<Testimonial> Testimonials { get; set; }

        public List<RoomViewModel> RoomViewModels { get; set; }
    }
}
