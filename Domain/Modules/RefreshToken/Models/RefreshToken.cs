using Domain.Shared;

namespace Domain;

public class RefreshToken: BaseEntity
{
    public int UserId{get;set;}
    public string TokenHash { get; set; } = null!;
    public DateTime ExpiresAt{get;set;}
    public DateTime? RevokedAt{get;set;}
    public string? ReplacedByTokenHash{get;set;}
    public string? CreatedByIp{get;set;}
    public string? RevokedByIp{get;set;}
   
}