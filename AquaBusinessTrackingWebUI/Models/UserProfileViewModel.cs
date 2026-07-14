using DTOLayer.Dtos.UserDtos;
using DTOLayer.Dtos.UserDtos.UserProfileDtos;

namespace AquaBusinessTrackingWebUI.Models
{
    public class UserProfileViewModel
    {
        public UpdateUserDto UpdateUser { get; set; }

        public PasswordDto Password { get; set; }
    }
}
