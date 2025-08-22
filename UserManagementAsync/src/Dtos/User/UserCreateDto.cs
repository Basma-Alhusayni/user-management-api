using UserManagementApi.Dtos.Profile;
namespace UserManagementApi.Dtos.User
{
    public class UserCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public ProfileCreateDto? Profile { get; set; }
    }
}
