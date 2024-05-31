using System.ComponentModel.DataAnnotations;

namespace UserManager.Domain.Models;

public class AuthSession : BaseModel
{
    public int AccountId { get; set; }
    public DateTime CreateDate { get; set; }
    public AuthSessionStatus Status { get; set; }
    
    [Timestamp]
    public byte[] Version { get; set; }
}

public enum AuthSessionStatus
{
    Active,
    Finished,
    Expired
}