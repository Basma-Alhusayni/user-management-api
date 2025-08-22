namespace UserManagementApi.Dtos.Profile
{
    public class ProfileDto
    {
        public int Id { get; set; }
        public string Bio { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
