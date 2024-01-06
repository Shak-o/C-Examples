namespace OOP.Console.OpenClosed;

public class MailMessageSender : IMessageSender
{
    public void SendMessage()
    {
        System.Console.WriteLine("Sending message to mail");
    }
}