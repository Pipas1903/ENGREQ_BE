namespace AMAP_FARM.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public required string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int RoleId { get; set; }
    }
}
