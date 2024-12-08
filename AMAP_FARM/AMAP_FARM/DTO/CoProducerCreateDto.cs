namespace AMAP_FARM.DTO
{
    public class CoProducerCreateDto
    {
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public required string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public required int RoleId { get; set; }

        public required string FarmName { get; set; }
        public required string Location { get; set; }
        public required string ContactNumber { get; set; }
    }
}
