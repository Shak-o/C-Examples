using System.ComponentModel.DataAnnotations;

namespace UserManager.Domain.Models;

public class AuthCount : BaseModel
{
    public int AccountId { get; set; }
    public int AuthSessionId { get; set; }
    public int Count { get; set; }
    
    [Timestamp]
    public byte[] Version { get; set; }
}

public enum AuthCountStatus
{
    CanRetry,
    Failed
}