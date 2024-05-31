namespace UserManager.Application.InfrastructureInterfaces;

public interface IMessagePublisher
{
    void Publish(string message);
}