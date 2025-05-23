namespace CarRental.Identity.Services
{
    public interface IJwtService
    {
        string GenerateToken(string userId, string role);
    }
}