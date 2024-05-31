using MediatR;
using TaskManager.Application.Messaging.Models;

namespace TaskManager.Application.Commands;

public class HandleUserUpdateRequest : IRequest
{
    public UserUpdateEvent UpdateRequest { get; set; }
}