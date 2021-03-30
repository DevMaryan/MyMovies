using MyMovies.Models;
using MyMovies.ViewModels;

namespace MyMovies.Mappings
{
    public static class ViewModelExtensions
    {
        public static Movie ToModel(this MovieCreateModel viewModel)
        {
            return new Movie
            {
                Title = viewModel.Title,
                ImageUrl = viewModel.ImageUrl,
                Description = viewModel.Description,
                Genre = viewModel.Genre,
            };
        }

        public static Movie ToModel(this MovieUpdateModel viewModel)
        {
            return new Movie
            {
                Id = viewModel.Id,
                Title = viewModel.Title,
                ImageUrl = viewModel.ImageUrl,
                Description = viewModel.Description,
                Genre = viewModel.Genre,
            };
        }
        public static User ToModel(this UserUpdateModel viewModel)
        {
            return new User
            {
                Id = viewModel.Id,
                Address = viewModel.Address,
                Email = viewModel.Email,
                IsAdmin = viewModel.IsAdmin,
            };
        }

        public static User ToModel(this SignUpModel user)
        {
            return new User()
            {
                Password = user.Password,
                Address = user.Address,
                Email = user.Email,
                Username = user.Username
            };
        }

        public static User ToModel(this UserAdminModel user)
        {
            return new User()
            {
                Id = user.Id,
                Address = user.Address,
                Email = user.Email,
                Username = user.Username,
                IsAdmin = user.IsAdmin,
                DateCreated = user.DateCreated,
            };

        }
    }
}
