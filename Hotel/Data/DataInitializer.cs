using Hotel.Models;
using Hotel.Models.Constants;
using Hotel.Models.InterfaceModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Data
{
    public class DataInitializer
    {
        private readonly AppDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;

        public DataInitializer(AppDbContext dbContext, RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task SeedData()
        {
            _dbContext.Database.Migrate();

            if (!_dbContext.Roles.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole(RoleConstants.Admin));
                await _roleManager.CreateAsync(new IdentityRole(RoleConstants.Moderator));
                await _roleManager.CreateAsync(new IdentityRole(RoleConstants.User));
            }

            if (!_dbContext.Mains.Any())
            {
                await _dbContext.Mains.AddAsync(new Main
                {
                    Rating = 5,
                    Description = "Welcome Coders to TrickSoLogic",
                    Title = "Welcome to my website!",
                    Image = "bg.jpg"
                });
            }

            if (!_dbContext.Abouts.Any())
            {
                await _dbContext.Abouts.AddRangeAsync(
                        new About { Image = "t1.jpg", Title = "We have 17+ years of experience.", Description = "Welcome.", ButtonName = "Read More" },
                        new About { Image = "t2.jpg", Title = "Start your incredible adventure!", Description = "Welcome.", ButtonName = "Choose a Room" }
                    );
            }

            if (!_dbContext.Features.Any())
            {
                await _dbContext.Features.AddRangeAsync(
                        new Feature { Image = "1.svg", Description = "Airport transfer", Order = 1, IsMain = true },
                        new Feature { Image = "2.svg", Description = "All-inclusive", Order = 2, IsMain = true },
                        new Feature { Image = "3.svg", Description = "Air conditioning", Order = 3, IsMain = true },
                        new Feature { Image = "4.svg", Description = "Security", Order = 4, IsMain = true },
                        new Feature { Image = "5.svg", Description = "Indoor pool", Order = 5, IsMain = false },
                        new Feature { Image = "6.svg", Description = "Wi-Fi", Order = 6, IsMain = false },
                        new Feature { Image = "7.svg", Description = "Smart TV", Order = 7, IsMain = false },
                        new Feature { Image = "8.svg", Description = "Laundry", Order = 8, IsMain = false }
                    );
            }

            if (!_dbContext.SliderImages.Any())
            {
                await _dbContext.SliderImages.AddRangeAsync(
                        new SliderImage { Image = "1.jpg", Order = 1 },
                        new SliderImage { Image = "2.jpg", Order = 2 },
                        new SliderImage { Image = "3.jpg", Order = 3 },
                        new SliderImage { Image = "4.jpg", Order = 4 },
                        new SliderImage { Image = "5.jpg", Order = 5 },
                        new SliderImage { Image = "6.jpg", Order = 6 }
                    );
            }

            if (!_dbContext.NumberInfos.Any())
            {
                await _dbContext.NumberInfos.AddRangeAsync(
                        new NumberInfo { Number = 4, Description = "Text 1" },
                        new NumberInfo { Number = 127, Description = "Text 2" },
                        new NumberInfo { Number = 6, Description = "Text 3" },
                        new NumberInfo { Number = 4586, Description = "Text 4" }
                    );
            }

            if (!_dbContext.Testimonials.Any())
            {
                await _dbContext.Testimonials.AddRangeAsync(
                         new Testimonial { FullName = "Mr. Karan", City = "Baku", Description = "Welcome", Image = "1.jpg", Rating = 3 },
                         new Testimonial { FullName = "Mr. Rahul", City = "Sheki", Description = "Welcome", Image = "2.jpg", Rating = 5 },
                         new Testimonial { FullName = "Ali Isaxanli", City = "Ganja", Description = "Welcome", Image = "3.jpg", Rating = 3 },
                         new Testimonial { FullName = "Metin Isaxanli", City = "Gabala", Description = "Welcome", Image = "4.jpg", Rating = 4 }
                    );
            }

            if (!_dbContext.Hotels.Any())
            {
                await _dbContext.Hotels.AddRangeAsync(
                        new Hotell { Name = "Taj Hotel", Rating = 2, Description = "Welcome  ,", Image = "hotel-1.jpg" },
                        new Hotell { Name = "Dennissons Hotel", Rating = 5, Description = "Welcome  ,", Image = "hotel-2.jpg" },
                        new Hotell { Name = "Ramana Hotel", Rating = 3, Description = "Welcome  ,", Image = "hotel-3.jpg" },
                        new Hotell { Name = "Four Seasons Hotel", Rating = 5, Description = "Welcome  ,", Image = "hotel-4.jpg" }
                    );
            }

            _dbContext.SaveChanges();

            if (!_dbContext.Rooms.Any())
            {
                await _dbContext.Rooms.AddRangeAsync(
                        new Room { Name = "Economy Room", HotelId = 1, Cost = 475, Square = 95, PersonCount = 3, Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Optio veniam quibusdam fugit aspernatur ratione rerum necessitatibus ipsa eligendi? Laudantium beatae aut earum ab doloribus tempore veritatis repellat natus illo, veniam quibusdam fugit aspernatur cumque harumquos esse libero nesciunt, molestiae saepe, possimus a suscipit! Minima aspernatur quod maxime quis facere facilis magnam, animi, quia id nihil reiciendis laboriosam, suscipit explicabo amet quasi recusandae at" },
                        new Room { Name = "Premium Room", HotelId = 1, Cost = 500, Square = 75, PersonCount = 2, Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Optio veniam quibusdam fugit aspernatur ratione rerum necessitatibus ipsa eligendi? Laudantium beatae aut earum ab doloribus tempore veritatis repellat natus illo, veniam quibusdam fugit aspernatur cumque harum quos esse libero nesciunt, molestiae saepe, possimus a suscipit! Minima aspernatur quod maxime quis facere facilis magnam, animi, quia id nihil reiciendis laboriosam, suscipit explicabo amet quasi recusandae at" },
                        new Room { Name = "Economy Room", HotelId = 2, Cost = 350, Square = 90, PersonCount = 1, Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Optio veniam quibusdam fugit aspernatur ratione rerum necessitatibus ipsa eligendi? Laudantium beatae aut earum ab doloribus tempore veritatis repellat natus illo, veniam quibusdam fugit aspernatur cumque harum quos esse libero nesciunt, molestiae saepe, possimus a suscipit! Minima aspernatur quod maxime quis facere facilis magnam, animi, quia id nihil reiciendis laboriosam, suscipit explicabo amet quasi recusandae at" },
                        new Room { Name = "Economy Room", HotelId = 3, Cost = 375, Square = 85, PersonCount = 2, Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Optio veniam quibusdam fugit aspernatur ratione rerum necessitatibus ipsa eligendi? Laudantium beatae aut earum ab doloribus tempore veritatis repellat natus illo, veniam quibusdam fugit aspernatur cumque harum quos esse libero nesciunt, molestiae saepe, possimus a suscipit! Minima aspernatur quod maxime quis facere facilis magnam, animi, quia id nihil reiciendis laboriosam, suscipit explicabo amet quasi recusandae at" },
                        new Room { Name = "Economy Room", HotelId = 4, Cost = 400, Square = 70, PersonCount = 3, Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Optio veniam quibusdam fugit aspernatur ratione rerum necessitatibus ipsa eligendi? Laudantium beatae aut earum ab doloribus tempore veritatis repellat natus illo, veniam quibusdam fugit aspernatur cumque harum quos esse libero nesciunt, molestiae saepe, possimus a suscipit! Minima aspernatur quod maxime quis facere facilis magnam, animi, quia id nihil reiciendis laboriosam, suscipit explicabo amet quasi recusandae at" }
                    );
            }

            _dbContext.SaveChanges();

            if (!_dbContext.Images.Any())
            {
                await _dbContext.Images.AddRangeAsync(
                        new Image { Name = "1.jpg", IsMain = true, RoomId = 1 },
                        new Image { Name = "2.jpg", IsMain = false, RoomId = 1 },
                        new Image { Name = "3.jpg", IsMain = false, RoomId = 1 },
                        new Image { Name = "4.jpg", IsMain = false, RoomId = 1 },
                        new Image { Name = "5.jpg", IsMain = false, RoomId = 1 },

                        new Image { Name = "1.jpg", IsMain = false, RoomId = 2 },
                        new Image { Name = "2.jpg", IsMain = true, RoomId = 2 },
                        new Image { Name = "3.jpg", IsMain = false, RoomId = 2 },
                        new Image { Name = "4.jpg", IsMain = false, RoomId = 2 },
                        new Image { Name = "5.jpg", IsMain = false, RoomId = 2 },

                        new Image { Name = "1.jpg", IsMain = false, RoomId = 3 },
                        new Image { Name = "2.jpg", IsMain = false, RoomId = 3 },
                        new Image { Name = "3.jpg", IsMain = true, RoomId = 3 },
                        new Image { Name = "4.jpg", IsMain = false, RoomId = 3 },
                        new Image { Name = "5.jpg", IsMain = false, RoomId = 3 },

                        new Image { Name = "1.jpg", IsMain = false, RoomId = 4 },
                        new Image { Name = "2.jpg", IsMain = false, RoomId = 4 },
                        new Image { Name = "3.jpg", IsMain = false, RoomId = 4 },
                        new Image { Name = "4.jpg", IsMain = true, RoomId = 4 },
                        new Image { Name = "5.jpg", IsMain = false, RoomId = 4 },

                        new Image { Name = "1.jpg", IsMain = false, RoomId = 5 },
                        new Image { Name = "2.jpg", IsMain = false, RoomId = 5 },
                        new Image { Name = "3.jpg", IsMain = false, RoomId = 5 },
                        new Image { Name = "4.jpg", IsMain = false, RoomId = 5 },
                        new Image { Name = "5.jpg", IsMain = true, RoomId = 5 }
                    );
            }

            if (!_dbContext.RoomsFeatures.Any())
            {
                await _dbContext.RoomsFeatures.AddRangeAsync(
                        new RoomsFeatures { FeatureId = 1, RoomId = 1 },
                        new RoomsFeatures { FeatureId = 2, RoomId = 1 },
                        new RoomsFeatures { FeatureId = 3, RoomId = 1 },
                        new RoomsFeatures { FeatureId = 4, RoomId = 1 },

                        new RoomsFeatures { FeatureId = 1, RoomId = 2 },
                        new RoomsFeatures { FeatureId = 5, RoomId = 2 },
                        new RoomsFeatures { FeatureId = 7, RoomId = 2 },
                        new RoomsFeatures { FeatureId = 8, RoomId = 2 },

                        new RoomsFeatures { FeatureId = 1, RoomId = 3 },
                        new RoomsFeatures { FeatureId = 3, RoomId = 3 },
                        new RoomsFeatures { FeatureId = 6, RoomId = 3 },
                       new RoomsFeatures { FeatureId = 8, RoomId = 3 },

                        new RoomsFeatures { FeatureId = 6, RoomId = 4 },
                        new RoomsFeatures { FeatureId = 7, RoomId = 4 },
                        new RoomsFeatures { FeatureId = 3, RoomId = 4 },
                        new RoomsFeatures { FeatureId = 5, RoomId = 4 },

                        new RoomsFeatures { FeatureId = 1, RoomId = 5 },
                        new RoomsFeatures { FeatureId = 2, RoomId = 5 },
                        new RoomsFeatures { FeatureId = 3, RoomId = 5 },
                        new RoomsFeatures { FeatureId = 4, RoomId = 5 }
                    );
            }


            if (!_dbContext.Users.Any())
            {
                User admin = new User
                {
                    Name = "Black",
                    Surname = "Coder",
                    Email = "admin@gmail.com",
                    UserName = "Admin123"
                };

                await _userManager.CreateAsync(admin, "Admin@123");
                await _userManager.AddToRoleAsync(admin, RoleConstants.Admin);
            }
        }
    }
}
