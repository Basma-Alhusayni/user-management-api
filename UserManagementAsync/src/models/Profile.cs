namespace UserManagementApi.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string Bio { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
