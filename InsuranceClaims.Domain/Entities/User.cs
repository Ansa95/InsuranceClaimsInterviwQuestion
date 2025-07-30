namespace InsuranceClaims.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = "Hospital";  // or "Admin"
        public ICollection<Claim> SubmittedClaims { get; set; } = new List<Claim>();
    }
}
