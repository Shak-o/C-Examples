using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace UserManager.Application.Commands.AccountCommands;

public class ChangeStatusRequest : IRequest<bool>
{
    public int AccountId { get; set; }
}