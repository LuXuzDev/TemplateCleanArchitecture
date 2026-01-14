namespace Application.Auth;

public class UserClaims
{
    public int UserId { get; set; }
    
    public string? UserName { get; set; }
    
    public string? UserEmail { get; set; }
    
    public string? Role { get; set; }
    
    public bool HasRole(string role)=> Role?.Equals(role,StringComparison.OrdinalIgnoreCase) == true;
    
    public bool IsAdmin => HasRole("Admin");
    
    public bool IsClient => HasRole("Client");
    
}