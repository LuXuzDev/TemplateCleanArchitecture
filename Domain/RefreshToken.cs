namespace Domain;

public class RefreshToken
{
    public Guid Id{get;set;}
    public int UserId{get;set;}
    public string TokenHash { get; set; } = null!;
    public DateTime CreatedAt{get;set;}
    public DateTime ExpiresAt{get;set;}
    public DateTime? RevokedAt{get;set;}
    public string? ReplacedByTokenHash{get;set;}
    public string? CreatedByIP{get;set;}
    public string? RevokedByIP{get;set;}
   
}