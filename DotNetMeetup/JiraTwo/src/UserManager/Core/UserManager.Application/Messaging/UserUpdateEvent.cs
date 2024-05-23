using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.Domain.Models;

namespace UserManager.Application.Messaging;

public class UserUpdateEvent
{
    public int UserId { get; set; }
    public AccountStatus AccountStatus { get; set; }
    public UserStatus UserStatus { get; set; }
}